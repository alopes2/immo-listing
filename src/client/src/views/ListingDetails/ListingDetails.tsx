import { useMutation, useQuery } from 'react-query';
import { useNavigate, useParams } from 'react-router-dom';
import { Listing } from '../../types/Listing';
import ListingRead from './ListingRead/ListingRead';
import { FormEvent, useState } from 'react';
import ListingEdit from './ListingEdit/ListingEdit';
import { SaveListing } from '../../types/SaveListing';

import classes from './ListingDetails.module.scss';

const ListingDetails = () => {
  const { listingId } = useParams();
  const [isEditing, setEditing] = useState<boolean>(false);
  const navigate = useNavigate();

  const { data, refetch } = useQuery<Listing>(
    `listings/${listingId}`,
    fetchStuff,
    {
      refetchOnWindowFocus: false
    }
  );

  const updateMutation = useMutation({
    mutationKey: `listings/${listingId}/update`,
    mutationFn: sendUpdateRequest
  });

  async function fetchStuff(): Promise<Listing> {
    const getListing = await fetch(
      import.meta.env.VITE_API_URL + '/listings/' + listingId
    );

    return await getListing.json();
  }

  async function sendUpdateRequest(
    saveListing: SaveListing
  ): Promise<Response> {
    const body = JSON.stringify(saveListing);

    const updateRequest = await fetch(
      import.meta.env.VITE_API_URL + '/listings/' + listingId,
      {
        method: 'PUT',
        body: body,
        headers: {
          'Content-Type': 'application/json'
        }
      }
    );

    return updateRequest;
  }

  async function sendDeleteRequest() {
    await fetch(import.meta.env.VITE_API_URL + '/listings/' + listingId, {
      method: 'DELETE'
    });

    navigate('/');
  }

  function setEdit() {
    setEditing((prev) => !prev);
  }

  async function updateListing(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    const eventTarget = event.currentTarget;
    const price = (Number.parseFloat(eventTarget.price.value) * 100).toFixed(0);
    const listToEdit: SaveListing = {
      bedrooms_count: eventTarget.bedrooms_count.value,
      building_type: eventTarget.building_type.value,
      contact_phone_number: eventTarget.contact_phone.value,
      description: eventTarget.description.value,
      latest_price_eur: price,
      name: eventTarget.listing_name.value,
      postal_address: {
        city: eventTarget.city.value,
        country: eventTarget.country.value,
        postal_code: eventTarget.postal_code.value,
        street_address: eventTarget.street.value
      },
      rooms_count: eventTarget.rooms_count.value,
      surface_area_m2: eventTarget.area.value
    };

    console.log(listToEdit);

    await updateMutation.mutateAsync(listToEdit);
    setEditing(false);
    await refetch();
  }

  let render = <p>Listing not found...</p>;

  if (data) {
    render = (
      <>
        <div className={classes.Buttons}>
          <button onClick={setEdit}>{isEditing ? 'Cancel' : 'Edit'}</button>
          <button onClick={sendDeleteRequest} className={classes.Delete}>
            Delete
          </button>
        </div>
        {isEditing ? (
          <ListingEdit listing={data} submit={updateListing} />
        ) : (
          <ListingRead listing={data} />
        )}
      </>
    );
  }

  return render;
};

export default ListingDetails;
