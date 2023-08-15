import { useNavigate } from 'react-router-dom';
import classes from './CreateListing.module.scss';
import { SaveListing } from '../../types/SaveListing';
import { useState } from 'react';
import { PostalAddress } from '../../types/PostalAddress';
import { useMutation } from 'react-query';
import { Listing } from '../../types/Listing';

const initialValue: SaveListing = {
  name: '',
  building_type: '',
  latest_price_eur: '',
  bedrooms_count: '',
  rooms_count: '',
  contact_phone_number: '',
  description: '',
  surface_area_m2: '',
  postal_address: {
    city: '',
    country: '',
    postal_code: '',
    street_address: ''
  }
};

const CreateListing = () => {
  const [request, setRequestParams] = useState<SaveListing>(initialValue);
  const navigate = useNavigate();

  const sendRequest = async () => {
    const requestBody = JSON.stringify(request);
    return await fetch(import.meta.env.VITE_API_URL + '/listings', {
      method: 'POST',
      body: requestBody,
      headers: {
        'Content-Type': 'application/json'
      }
    });
  };

  const mutation = useMutation({
    mutationFn: sendRequest,
    onError: (error: Error) => {
      alert(`${error}`);
    },
    onSuccess: async (response) => {
      if (response.status < 400) {
        navigate('/');
      }

      const data = await response.json();
      alert(data[0].errors[0]);
    }
  });

  const submit = async (event: React.FormEvent) => {
    event.preventDefault();
    await mutation.mutateAsync();
  };

  const updateRequest = (
    event: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement
    >,
    key: keyof SaveListing | keyof PostalAddress
  ) => {
    const value = event.target.value;
    setRequestParams((prev: SaveListing) => {
      if (['city', 'postal_code', 'street_address', 'country'].includes(key)) {
        console.log(key, value);
        return {
          ...prev,
          postal_address: {
            ...prev.postal_address,
            [key]: value
          }
        };
      }

      return {
        ...prev,
        [key]: value
      };
    });
  };

  return (
    <form onSubmit={submit} className={classes.Form}>
      <button>Save</button>
      <div className={classes.FormBlock}>
        <div className={classes.FormElement}>
          <label>Name:</label>
          <input
            onChange={(e) => updateRequest(e, 'name')}
            value={request['name']}
            required
          />
        </div>

        <div className={classes.FormElement}>
          <label>Price:</label>
          <input
            type="number"
            onChange={(e) => updateRequest(e, 'latest_price_eur')}
            value={request['latest_price_eur']}
            required
          />
        </div>

        <div className={classes.FormElement}>
          <label>Building Type:</label>
          <select
            placeholder="Type"
            onChange={(e) => updateRequest(e, 'building_type')}
            value={request['building_type']}
            required>
            <option value="">Select type...</option>
            <option value="HOUSE">House</option>
            <option value="STUDIO">Studio</option>
            <option value="APARTMENT">Apartment</option>
          </select>
        </div>

        <div className={classes.FormElement}>
          <label>Area:</label>
          <input
            type="number"
            onChange={(e) => updateRequest(e, 'surface_area_m2')}
            value={request['surface_area_m2']}
          />
        </div>

        <div className={classes.FormElement}>
          <label>Rooms Count:</label>
          <input
            type="number"
            onChange={(e) => updateRequest(e, 'rooms_count')}
            value={request['rooms_count']}
            required
          />
        </div>

        <div className={classes.FormElement}>
          <label>Bedrooms Count:</label>
          <input
            type="number"
            onChange={(e) => updateRequest(e, 'bedrooms_count')}
            value={request['bedrooms_count']}
            required
          />
        </div>

        <div className={classes.FormElement}>
          <label>Contact phone:</label>
          <input
            onChange={(e) => updateRequest(e, 'contact_phone_number')}
            value={request['contact_phone_number']}
            pattern="\+{0,1}[0-9]{7,15}"
            required
          />
        </div>

        <div className={classes.FormElement}>
          <label>Street:</label>
          <input
            onChange={(e) => updateRequest(e, 'street_address')}
            value={request['postal_address'].street_address}
            required
          />
        </div>

        <div className={classes.FormElement}>
          <label>Postal Code:</label>
          <input
            onChange={(e) => updateRequest(e, 'postal_code')}
            value={request['postal_address'].postal_code}
            minLength={4}
            required
          />
        </div>

        <div className={classes.FormElement}>
          <label>City:</label>
          <input
            onChange={(e) => updateRequest(e, 'city')}
            value={request['postal_address'].city}
            required
          />
        </div>

        <div className={classes.FormElement}>
          <label>Country:</label>
          <input
            onChange={(e) => updateRequest(e, 'country')}
            value={request['postal_address'].country}
            required
          />
        </div>
      </div>
      <div className={classes.FormBlock}>
        <div className={classes.FormElement}>
          <label>Description:</label>
          <textarea
            onChange={(e) => updateRequest(e, 'description')}
            value={request['description']}
          />
        </div>
      </div>
    </form>
  );
};

export default CreateListing;
