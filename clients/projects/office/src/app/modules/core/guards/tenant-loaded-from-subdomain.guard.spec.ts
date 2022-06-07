import { TestBed } from '@angular/core/testing';

import { TenantLoadedFromSubdomainGuard } from './tenant-loaded-from-subdomain.guard';

describe('TenantLoadedFromSubdomainGuard', () => {
  let guard: TenantLoadedFromSubdomainGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(TenantLoadedFromSubdomainGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
