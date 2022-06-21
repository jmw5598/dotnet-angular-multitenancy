import { Component, ChangeDetectionStrategy, Input, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ControlContainer, FormControl, FormGroup, Validators } from '@angular/forms';
import { StripeCardElementOptions, StripeElementsOptions, StripeElementClasses, StripeCardElementChangeEvent, Token, CreateTokenCardData } from '@stripe/stripe-js';

import { Plan } from '@xyz/office/modules/core/entities/multitenancy';
import { RegistrationPaymentDetails } from '@xyz/office/modules/core/models/authentication/registration-payment-details.model';
import { StripeCardComponent, StripeCardNumberComponent, StripeService } from 'ngx-stripe';
import { defaultStripeCardElementOptions, defaultStripElementsOptions } from './registration-plan-form-stripe-options.defaults';

@Component({
  selector: 'xyz-registration-plan-form',
  templateUrl: './registration-plan-form.component.html',
  styleUrls: ['./registration-plan-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationPlanFormComponent {
  @ViewChild(StripeCardComponent, { static: false }) 
  public card!: StripeCardNumberComponent;

  @Input()
  public plans: Plan[] | null = null;

  public parentForm: FormGroup;
  public formGroup: FormGroup;

  public selectedPlan: Plan | null = null;

  public cardOptions: StripeCardElementOptions = defaultStripeCardElementOptions;
  public elementsOptions: StripeElementsOptions = defaultStripElementsOptions;    

  constructor(
    private _controlContainer: ControlContainer,
    private _changeDetectorRef: ChangeDetectorRef,
    private _stripeService: StripeService
  ) {
    this.parentForm = this._controlContainer.control as FormGroup as FormGroup;
    this.formGroup = (this._controlContainer.control as FormGroup).get('plan') as FormGroup;
  }

  public get paymentDetailsFormGroup(): FormGroup {
    return this.parentForm?.get('paymentDetails') as FormGroup;
  }

  public onSelectedPlanChange(planId: string): void {
    const selectedPlan = this.plans?.find(plan => plan.id === planId) || null;

    if (selectedPlan?.paymentRequired) {
      this.parentForm.addControl(
        'paymentDetails', 
        this._buildPaymentDetailsFormGroup()
      );
    } else {
      this.parentForm.removeControl('paymentDetails');
    }

    this.selectedPlan = selectedPlan;
    setTimeout(() => this._changeDetectorRef.markForCheck(), 100);
  }

  public onCardInformationChange(event: StripeCardElementChangeEvent): void {
    if (event.complete && !event.error) {
      const paymentDetails: RegistrationPaymentDetails = this.paymentDetailsFormGroup.value;
      this._stripeService.createToken(
          this.card.element, {
            name: `${paymentDetails.firstName} ${paymentDetails.lastName}`,
            address_line1: paymentDetails.address,
            address_city: paymentDetails.city,
            address_state: paymentDetails.state,
            address_zip: paymentDetails.zip,
            address_country: 'United States'
          } as CreateTokenCardData
        )
        .subscribe(({token, error}) => {
          if (error) {
            this._resetPaymentDetailsFormGroup();
          } else {
            console.log("token is ", token);
            this.paymentDetailsFormGroup.get('cardDetails')?.patchValue({
              isValid: true,
              brand: token?.card?.brand || null,
              token: token?.id || null
            });
            setTimeout(() => this._changeDetectorRef.markForCheck(), 100);
          }
        });
    } else {
      this._resetPaymentDetailsFormGroup();
    }
  }

  private _resetPaymentDetailsFormGroup(): void {
    this.paymentDetailsFormGroup.patchValue({
      cardDetails: {
        isValid: null,
        brand: null,
        token: null
      }
    });
  }

  private _buildPaymentDetailsFormGroup(): FormGroup {
    return new FormGroup({
      firstName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      address: new FormControl(null, [Validators.required]),
      city: new FormControl(null, [Validators.required]),
      state: new FormControl(null, [Validators.required]),
      zip: new FormControl(null, [Validators.required]),
      cardDetails: new FormGroup({
        isValid: new FormControl(null, [Validators.required]),
        brand: new FormControl(null, [Validators.required]),
        token: new FormControl(null, [Validators.required])
      })
    });
  }
}
