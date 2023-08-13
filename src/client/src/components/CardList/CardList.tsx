import { Listing } from '../../types/Listing';
import Card from '../Card/Card';
import classes from './CardList.module.scss';

const CardList: React.FC<{ listings: Listing[] }> = ({ listings }) => (
  <div className={classes.CardList}>
    {listings.map((l) => (
      <Card listing={l} key={l.id} />
    ))}
  </div>
);

export default CardList;
