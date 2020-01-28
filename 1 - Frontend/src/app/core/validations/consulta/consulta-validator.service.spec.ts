import { TestBed } from '@angular/core/testing';

import { ConsultaValidatorService } from './consulta-validator.service';

describe('ConsultaValidatorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  xit('should be created', () => {
    const service: ConsultaValidatorService = TestBed.get(ConsultaValidatorService);
    expect(service).toBeTruthy();
  });
});
