import { TestBed } from '@angular/core/testing';

import { SecretServiceService } from './secret-service.service';

describe('SecretServiceService', () => {
  let service: SecretServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SecretServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
