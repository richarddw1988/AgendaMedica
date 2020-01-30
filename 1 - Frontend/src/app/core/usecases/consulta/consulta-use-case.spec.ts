import { ConsultaUseCase } from './consulta-use-case';
import { TestBed } from '@angular/core/testing';
import { IConsultaRepository } from '../../interfaces/repository/iconsulta-repository';

describe('ConsultaUseCase', () => {
  let consultaUseCase: ConsultaUseCase;
  let consultaRepository: jasmine.SpyObj<IConsultaRepository>;


  beforeEach(() => {
    const repositorySpy = jasmine.createSpyObj('IConsultaRepository', ['insert', 'update', 'get', 'getAll', 'delete']);

    TestBed.configureTestingModule({
      providers: [
        { provide: IConsultaRepository, useValue: repositorySpy }
      ]
    })
    .compileComponents();

    consultaUseCase = TestBed.get(ConsultaUseCase);
    consultaRepository = TestBed.get(IConsultaRepository);
  });

  it('deve ser criado', () => {
    expect(consultaUseCase).toBeTruthy();
  });
});
