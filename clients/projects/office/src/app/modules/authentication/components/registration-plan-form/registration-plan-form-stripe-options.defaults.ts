import { StripeCardElementOptions, StripeElementsOptions } from "@stripe/stripe-js";

export const defaultStripeCardElementOptions: StripeCardElementOptions = {
  classes: {
    base: 'ant-input py-1'
  },
  hidePostalCode: true
};

export const defaultStripElementsOptions: StripeElementsOptions  = {
  locale: 'en'
};
