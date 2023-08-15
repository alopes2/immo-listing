import { Navigate, createBrowserRouter } from 'react-router-dom';
import ListingsView from '../views/Listings/ListingsView';
import RootLayout from './RootLayout';
import CreateListing from '../views/CreateListing/CreateListing';

const router = createBrowserRouter([
  {
    path: '/',
    element: <RootLayout />,
    children: [
      { path: '/', element: <ListingsView /> },
      { path: '/create-listing', element: <CreateListing /> },
      { path: '*', element: <Navigate to="/" /> }
    ]
  }
]);

export default router;
