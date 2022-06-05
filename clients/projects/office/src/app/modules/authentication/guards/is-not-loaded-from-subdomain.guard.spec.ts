import { TestBed } from '@angular/core/testing';

import { IsNotLoadedFromSubdomainGuard } from './is-not-loaded-from-subdomain.guard';

describe('IsNotLoadedFromSubdomainGuard', () => {
  let guard: IsNotLoadedFromSubdomainGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsNotLoadedFromSubdomainGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
