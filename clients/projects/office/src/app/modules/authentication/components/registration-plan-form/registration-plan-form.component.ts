import { Component, ChangeDetectionStrategy, Input, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ControlContainer, FormControl, FormGroup, Validators } from '@angular/forms';
import { StripeCardElementOptions, StripeElementsOptions, StripeElementClasses, StripeCardElementChangeEvent } from '@stripe/stripe-js';

import { Plan } from '@xyz/office/modules/core/entities/multitenancy';
import { StripeCardNumberComponent } from 'ngx-stripe';
import { defaultStripeCardElementOptions, defaultStripElementsOptions } from './registration-plan-form-stripe-options.defaults';

@Component({
  selector: 'xyz-registration-plan-form',
  templateUrl: './registration-plan-form.component.html',
  styleUrls: ['./registration-plan-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrationPlanFormComponent {
  @ViewChild(StripeCardNumberComponent, { static: false }) 
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
    private _changeDetectorRef: ChangeDetectorRef
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
      console.log("card change complete, get token", event, this.card);
    } else {
      console.log("setting payment id token to null");
    }
  }

  private _buildPaymentDetailsFormGroup(): FormGroup {
    return new FormGroup({
      firstName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      street: new FormControl(null, [Validators.required]),
      city: new FormControl(null, [Validators.required]),
      state: new FormControl(null, [Validators.required]),
      zip: new FormControl(null, [Validators.required]),
      cardToken: new FormControl(null, [Validators.required])
    });
  }
}
