import { Listing } from '../../types/Listing';
import CardList from '../../components/CardList/CardList';
import { useQuery } from 'react-query';
import { FormEvent, useState } from 'react';
import { GetListingsQuery } from '../../types/GetListingsQuery';
import ListingsSearchForm from './ListingsSearchForm/ListingsSearchForm';
import { Link } from 'react-router-dom';
import classes from './Listings.module.scss';

const queryInitialValue: GetListingsQuery = {
  name: '',
  building_type: '',
  min_price: '',
  max_price: ''
};

const ListingsView = () => {
  const [query, setQueryParams] = useState<GetListingsQuery>(queryInitialValue);
  const { data = [], refetch } = useQuery<Listing[]>('listings', fetchStuff, {
    refetchOnWindowFocus: false
  });

  async function fetchStuff(): Promise<Listing[]> {
    const queryValues = Object.keys(query)
      .map((key: string) => {
        let value = query[key as keyof GetListingsQuery];

        if (isPriceKey(key as keyof GetListingsQuery) && value !== '') {
          value = (+value * 100).toFixed(0);
        }

        return value !== '' ? key + '=' + value : '';
      })
      .filter((value: string) => value !== '');

    const queryParams = queryValues.join('&');

    const queryConnector = queryParams ? '?' : '';

    const getListings = await fetch(
      import.meta.env.VITE_API_URL + '/listings' + queryConnector + queryParams
    );

    return await getListings.json();
  }

  const search = async (e: FormEvent) => {
    e.preventDefault();

    await refetch();
  };

  const updateQuery = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>,
    key: keyof GetListingsQuery
  ) => {
    setQueryParams((prev: GetListingsQuery) => {
      return {
        ...prev,
        [key]: e.target.value
      };
    });
  };

  const limitInputToTwoDecimalPoints = (
    e: React.ChangeEvent<HTMLInputElement>,
    key: keyof GetListingsQuery
  ) => {
    let value = e.target.value;
    if (isPriceKey(key) && value.includes('.')) {
      value = (+value).toFixed(2);

      setQueryParams((prev: GetListingsQuery) => {
        return {
          ...prev,
          [key]: value
        };
      });
    }
  };

  function isPriceKey(key: keyof GetListingsQuery) {
    return key === 'min_price' || key === 'max_price';
  }

  return (
    <>
      <Link to="/create-listing" className={classes.NewListing}>
        New Listing
      </Link>
      <ListingsSearchForm
        query={query}
        search={search}
        updateQuery={updateQuery}
        limitInputToTwoDecimalPoints={limitInputToTwoDecimalPoints}
      />
      <CardList listings={data} />
    </>
  );
};

export default ListingsView;
