import { FormEvent } from 'react';
import { GetListingsQuery } from '../../../types/GetListingsQuery';
import classes from './ListingsSearchForm.module.scss';

type ListingsSearchFormProps = {
  query: GetListingsQuery;
  updateQuery: (
    event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>,
    key: string
  ) => void;
  search: (event: FormEvent) => void;
};

const ListingsSearchForm: React.FC<ListingsSearchFormProps> = ({
  query,
  updateQuery,
  search
}) => (
  <form className={classes.ListingsSearch} onSubmit={search}>
    <label>
      <input
        type="text"
        name="search-listing"
        placeholder="Property name"
        onChange={(e) => updateQuery(e, 'name')}
        value={query['name']}
      />
    </label>

    <label>
      <select
        placeholder="Type"
        onChange={(e) => updateQuery(e, 'building_type')}
        value={query['building_type']}>
        <option value="">Select type...</option>
        <option value="HOUSE">House</option>
        <option value="STUDIO">Studio</option>
        <option value="APARTMENT">Apartment</option>
      </select>
    </label>

    <label>
      <input
        type="number"
        placeholder="Min price"
        onChange={(e) => updateQuery(e, 'min_price')}
        value={query['min_price']}
      />
    </label>

    <label>
      <input
        type="number"
        placeholder="Max price"
        onChange={(e) => updateQuery(e, 'max_price')}
        value={query['max_price']}
      />
    </label>

    <button>Search</button>
  </form>
);

export default ListingsSearchForm;
