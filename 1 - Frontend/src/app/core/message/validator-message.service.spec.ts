import { TestBed } from '@angular/core/testing';
import { ValidatorMessageService } from './validator-message.service';

describe('ValidatorMessageService:', () => {
  let validatorMessageService: ValidatorMessageService;

  beforeEach(() => TestBed.configureTestingModule({
    providers: []
  }));

  beforeEach(() => {
    validatorMessageService = TestBed.get(ValidatorMessageService);
  });

  xit('deve ser criado', () => {
    const service: ValidatorMessageService = TestBed.get(ValidatorMessageService);
    expect(service).toBeTruthy();
  });

  xit('deve retornar um texto do tipo required', () => {
    validatorMessageService.required('Usuário');
  });
});
