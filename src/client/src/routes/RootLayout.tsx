import { Outlet } from 'react-router-dom';

const RootLayout = () => (
  <>
    <h1>Immo Listing</h1>
    <Outlet />
  </>
);

export default RootLayout;
