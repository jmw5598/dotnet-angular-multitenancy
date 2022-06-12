import { TestBed } from '@angular/core/testing';

import { TenantStatisticsLoadedGuard } from './tenant-statistics-loaded.guard';

describe('TenantStatisticsLoadedGuard', () => {
  let guard: TenantStatisticsLoadedGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(TenantStatisticsLoadedGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
