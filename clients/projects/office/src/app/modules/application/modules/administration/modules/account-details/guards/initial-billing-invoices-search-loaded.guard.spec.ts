import { TestBed } from '@angular/core/testing';

import { InitialBillingInvoicesSearchLoadedGuard } from './initial-billing-invoices-search-loaded.guard';

describe('InitialBillingInvoicesSearchLoadedGuard', () => {
  let guard: InitialBillingInvoicesSearchLoadedGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(InitialBillingInvoicesSearchLoadedGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
