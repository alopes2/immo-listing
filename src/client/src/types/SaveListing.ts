import { PostalAddress } from './PostalAddress';

export interface SaveListing {
  name: string;
  postal_address: PostalAddress;
  description: string;
  building_type: string;
  latest_price_eur: string;
  surface_area_m2: string;
  rooms_count: string;
  bedrooms_count: string;
  contact_phone_number: string;
}
