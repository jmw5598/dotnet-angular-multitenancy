import { StripeCardElementOptions, StripeElementsOptions } from "@stripe/stripe-js";

export const defaultStripeCardElementOptions: StripeCardElementOptions = {
  classes: {
    base: 'ant-input py-1',
    focus: 'ant-input-focused',
    invalid: 'ant-form-item-has-error'
  },
  hidePostalCode: true
};

export const defaultStripElementsOptions: StripeElementsOptions  = {
  locale: 'en'
};
