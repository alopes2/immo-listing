import { Listing } from '../../types/Listing';
import CardList from '../../components/CardList/CardList';
import { useQuery } from 'react-query';
import { FormEvent, useState } from 'react';
import { GetListingsQuery } from '../../types/GetListingsQuery';
import ListingsSearchForm from './ListingsSearchForm/ListingsSearchForm';

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
      .map((value: string) =>
        query[value as keyof GetListingsQuery] !== ''
          ? value + '=' + query[value as keyof GetListingsQuery]
          : ''
      )
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

    setQueryParams(queryInitialValue);
  };

  const updateQuery = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>,
    key: string
  ) => {
    console.log(e.target.value);
    setQueryParams((prev: GetListingsQuery) => {
      return {
        ...prev,
        [key]: e.target.value
      };
    });
  };

  return (
    <>
      <ListingsSearchForm
        query={query}
        search={search}
        updateQuery={updateQuery}
      />
      <CardList listings={data} />
    </>
  );
};

export default ListingsView;
