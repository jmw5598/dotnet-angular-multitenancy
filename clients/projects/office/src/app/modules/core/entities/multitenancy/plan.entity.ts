export interface Plan {
  id: string,
  name: string;
  price: number,
  paymentRequired: boolean,
  renewalRate: string,
  maxUserCount: number
}
