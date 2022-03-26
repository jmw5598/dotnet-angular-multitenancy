import { TestBed } from '@angular/core/testing';

import { AvailablePlansLoadedGuard } from './available-plans-loaded.guard';

describe('AvailablePlansLoadedGuard', () => {
  let guard: AvailablePlansLoadedGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AvailablePlansLoadedGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
