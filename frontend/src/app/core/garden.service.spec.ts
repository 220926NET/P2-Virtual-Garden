import { TestBed } from '@angular/core/testing';


import { AuthService } from './auth.service';

describe('AuthService', () => {
  let service: AuthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthService);
  });
});

import { GardenService } from './garden.service';

describe('GardenService', () => {
  let service: GardenService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GardenService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
