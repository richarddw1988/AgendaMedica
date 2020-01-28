import { ConsultaUseCase } from './consulta-use-case';
import { TestBed } from '@angular/core/testing';
import { IConsultaRepository } from '../../interfaces/repository/iconsulta-repository';
import { IConsultaValidator } from '../../interfaces/validations/iconsulta-validator';

describe('ConsultaUseCase', () => {
  let consultaUseCase: ConsultaUseCase;
  let consultaRepository: jasmine.SpyObj<IConsultaRepository>;
  let consultaValidator: jasmine.SpyObj<IConsultaValidator>;

  beforeEach(() => {
    const repositorySpy = jasmine.createSpyObj('IConsultaRepository', ['insert', 'update', 'get', 'getAll', 'delete']);
    const validationSpy = jasmine.createSpyObj('IUsuarioValidator', ['validateFields']);

    TestBed.configureTestingModule({
      providers: [
        { provide: IConsultaRepository, useValue: repositorySpy },
        { provide: IConsultaValidator, useValue: validationSpy }
      ]
    })
    .compileComponents();

    consultaUseCase = TestBed.get(ConsultaUseCase);
    consultaRepository = TestBed.get(IConsultaRepository);
    consultaValidator = TestBed.get(IConsultaValidator);
  });

  it('deve ser criado', () => {
    expect(consultaUseCase).toBeTruthy();
  });

  // xit('deve executar o metodo login e ser valido', () => {
  //   const mock = {
  //     username: 'test',
  //     password: '123'
  //   };

  //   usuarioUseCase.login(mock);
  // });

  // xit('deve executar o metodo login e ser invalido', () => {
  //   const mock = {
  //     username: '',
  //     password: ''
  //   };

  //   usuarioUseCase.login(mock);

  //   expect(usuarioValidator.validateFields(mock)).toBeFalsy();
  // });

  // it('deve executar o metodo logout', () => {
  //   usuarioUseCase.logout();
  //   expect(usuarioRepository.logout.calls.count()).toBe(1);
  // });
});
