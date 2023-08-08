import { useEffect, useState } from 'react';
import './App.css';

import { Listing } from './types/Listing';
import CardList from './components/CardList/CardList';

function App() {
  const [listings, setListings] = useState<Listing[]>([]);

  useEffect(() => {
    fetchStuff();
  }, []);

  async function fetchStuff() {
    const getListings = await fetch(import.meta.env.VITE_API_URL + '/listings');

    const response = await getListings.json();

    setListings(response);
  }

  return (
    <>
      <h1>Immo Listing</h1>
      <div className="card">
        <CardList listings={listings} />
      </div>
    </>
  );
}

export default App;
