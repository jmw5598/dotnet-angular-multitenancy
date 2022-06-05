import { TestBed } from '@angular/core/testing';

import { IsLoadedFromSubdomainGuard } from './is-loaded-from-subdomain.guard';

describe('IsLoadedFromSubdomainGuard', () => {
  let guard: IsLoadedFromSubdomainGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsLoadedFromSubdomainGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
