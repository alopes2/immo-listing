import { Listing } from '../../../types/Listing';
import classes from './ListingRead.module.scss';

type ListingsReadProps = {
  listing: Listing;
};

const ListingRead: React.FC<ListingsReadProps> = ({ listing }) => {
  return (
    <div className={classes.Container}>
      <div className={classes.Block}>
        <div className={classes.Element}>
          <p>Name:</p>
          <p>{listing.name}</p>
        </div>

        <div className={classes.Element}>
          <p>Price:</p>
          <p>${(listing.latest_price_eur / 100).toFixed(2)}</p>
        </div>

        <div className={classes.Element}>
          <p>Building Type:</p>
          <p>{listing.building_type}</p>
        </div>

        <div className={classes.Element}>
          <p>Area:</p>
          <p>{listing.surface_area_m2}</p>
        </div>

        <div className={classes.Element}>
          <p>Rooms Count:</p>
          <p>{listing.rooms_count}</p>
        </div>

        <div className={classes.Element}>
          <p>Bedrooms Count:</p>
          <p>{listing.bedrooms_count}</p>
        </div>

        <div className={classes.Element}>
          <p>Contact phone:</p>
          <p>{listing.contact_phone_number}</p>
        </div>

        <div className={classes.Element}>
          <p>Street:</p>
          <p>{listing.postal_address.street_address}</p>
        </div>

        <div className={classes.Element}>
          <p>Postal Code:</p>
          <p>{listing.postal_address.postal_code}</p>
        </div>

        <div className={classes.Element}>
          <p>City:</p>
          <p>{listing.postal_address.city}</p>
        </div>

        <div className={classes.Element}>
          <p>Country:</p>
          <p>{listing.postal_address.country}</p>
        </div>
      </div>
      <div className={classes.Block}>
        <div className={classes.Element}>
          <p>Description:</p>
          <p>{listing.description}</p>
        </div>
      </div>
    </div>
  );
};

export default ListingRead;
