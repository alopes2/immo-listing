export interface Listing {
  id: number;
  created_date: string;
  updated_date: string;
  name: string;
  postal_address: PostalAddress;
  description: string;
  building_type: string;
  latest_price_eur: number;
  surface_area_m2: string;
  rooms_count: string;
  bedrooms_count: string;
  contact_phone_number: string;
}

export interface PostalAddress {
  street_address: string;
  postal_code: string;
  city: string;
  country: string;
}
