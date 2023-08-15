import { FormEvent } from 'react';
import { GetListingsQuery } from '../../../types/GetListingsQuery';
import classes from './ListingsSearchForm.module.scss';

type ListingsSearchFormProps = {
  query: GetListingsQuery;
  updateQuery: (
    event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>,
    key: keyof GetListingsQuery
  ) => void;
  limitInputToTwoDecimalPoints: (
    event: React.ChangeEvent<HTMLInputElement>,
    key: keyof GetListingsQuery
  ) => void;
  search: (event: FormEvent) => void;
};

const ListingsSearchForm: React.FC<ListingsSearchFormProps> = ({
  query,
  updateQuery,
  search,
  limitInputToTwoDecimalPoints
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
        step="0.01"
        onChange={(e) => updateQuery(e, 'min_price')}
        onBlur={(e) => limitInputToTwoDecimalPoints(e, 'min_price')}
        value={query['min_price']}
      />
    </label>

    <label>
      <input
        type="number"
        placeholder="Max price"
        step="0.01"
        onChange={(e) => updateQuery(e, 'max_price')}
        onBlur={(e) => limitInputToTwoDecimalPoints(e, 'max_price')}
        value={query['max_price']}
      />
    </label>

    <button>Search</button>
  </form>
);

export default ListingsSearchForm;
