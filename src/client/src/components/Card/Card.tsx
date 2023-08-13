import { Listing } from '../../types/Listing';
import classes from './Card.module.scss';

const Card: React.FC<{ listing: Listing }> = ({ listing }) => (
  <div className={classes.Card}>
    <h2>{listing.name}</h2>
    <p>{listing.building_type}</p>
    <p className={classes.Price}>
      {new Intl.NumberFormat('de-DE', {
        style: 'currency',
        currency: 'EUR'
      }).format(listing.latest_price_eur / 100)}
    </p>
    <hr />
    <div className={classes.BuildingDetails}>
      <div>Rooms: {listing.rooms_count}</div>
      <span className={classes.Spacer}>|</span>
      <div>Bedrooms: {listing.bedrooms_count}</div>
    </div>
    <hr />
    <article>
      <h4>Description</h4>
      <section>{listing.description}</section>
    </article>
  </div>
);

export default Card;
