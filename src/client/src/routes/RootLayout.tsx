import { Link, Outlet } from 'react-router-dom';

const RootLayout = () => (
  <>
    <h1>
      <Link to="/">Immo Listing</Link>
    </h1>
    <Outlet />
  </>
);

export default RootLayout;
