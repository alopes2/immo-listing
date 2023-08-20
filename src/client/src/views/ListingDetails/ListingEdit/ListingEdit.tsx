import { FormEvent } from 'react';
import { Listing } from '../../../types/Listing';
import classes from './ListingEdit.module.scss';

type ListingsEditProps = {
  listing: Listing;
  submit: (event: FormEvent<HTMLFormElement>) => void;
};

const ListingEdit: React.FC<ListingsEditProps> = ({ listing, submit }) => {
  return (
    <form onSubmit={submit} className={classes.Form}>
      <button>Save</button>
      <div className={classes.FormBlock}>
        <div className={classes.FormElement}>
          <label>Name:</label>
          <input name="listing_name" defaultValue={listing['name']} required />
        </div>

        <div className={classes.FormElement}>
          <label>Price:</label>
          <input
            type="number"
            defaultValue={(listing['latest_price_eur'] / 100).toFixed(2)}
            required
            name="price"
            step={0.01}
          />
        </div>

        <div className={classes.FormElement}>
          <label>Building Type:</label>
          <select
            placeholder="Type"
            defaultValue={listing['building_type']}
            required
            name="building_type">
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
            defaultValue={listing['surface_area_m2']}
            name="area"
          />
        </div>

        <div className={classes.FormElement}>
          <label>Rooms Count:</label>
          <input
            type="number"
            defaultValue={listing['rooms_count']}
            required
            name="rooms_count"
          />
        </div>

        <div className={classes.FormElement}>
          <label>Bedrooms Count:</label>
          <input
            type="number"
            defaultValue={listing['bedrooms_count']}
            required
            name="bedrooms_count"
          />
        </div>

        <div className={classes.FormElement}>
          <label>Contact phone:</label>
          <input
            defaultValue={listing['contact_phone_number']}
            pattern="\+{0,1}[0-9]{7,15}"
            required
            name="contact_phone"
          />
        </div>

        <div className={classes.FormElement}>
          <label>Street:</label>
          <input
            defaultValue={listing['postal_address'].street_address}
            required
            name="street"
          />
        </div>

        <div className={classes.FormElement}>
          <label>Postal Code:</label>
          <input
            defaultValue={listing['postal_address'].postal_code}
            minLength={4}
            required
            name="postal_code"
          />
        </div>

        <div className={classes.FormElement}>
          <label>City:</label>
          <input
            defaultValue={listing['postal_address'].city}
            required
            name="city"
          />
        </div>

        <div className={classes.FormElement}>
          <label>Country:</label>
          <input
            defaultValue={listing['postal_address'].country}
            required
            name="country"
          />
        </div>
      </div>
      <div className={classes.FormBlock}>
        <div className={classes.FormElement}>
          <label>Description:</label>
          <textarea defaultValue={listing['description']} name="description" />
        </div>
      </div>
    </form>
  );
};

export default ListingEdit;
