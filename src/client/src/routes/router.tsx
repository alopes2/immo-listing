import { Navigate, createBrowserRouter } from 'react-router-dom';
import ListingsView from '../views/Listings/ListingsView';
import RootLayout from './RootLayout';
import CreateListing from '../views/CreateListing/CreateListing';
import ListingDetails from '../views/ListingDetails/ListingDetails';

const router = createBrowserRouter([
  {
    path: '/',
    element: <RootLayout />,
    children: [
      { path: '/', element: <ListingsView /> },
      { path: '/create-listing', element: <CreateListing /> },
      { path: '/:listingId', element: <ListingDetails /> },
      { path: '*', element: <Navigate to="/" /> }
    ]
  }
]);

export default router;
