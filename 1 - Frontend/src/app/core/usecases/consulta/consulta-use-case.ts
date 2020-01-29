import { Observable, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { IConsultaUseCase } from '../../interfaces/usecases/iconsulta-use-case';
import { IConsultaRepository } from '../../interfaces/repository/iconsulta-repository';
import { IConsultaValidator } from '../../interfaces/validations/iconsulta-validator';
import { ConsultaModel } from '../../domain/entity/consulta-model';


@Injectable({
  providedIn: 'root'
})
export class ConsultaUseCase implements IConsultaUseCase {

  constructor(
    private consultaRepository: IConsultaRepository,
    private consultaValidator: IConsultaValidator
  ) { }

  insert(param: ConsultaModel): Observable<any> {
    const validator = this.consultaValidator.validateFields(param);

    if (validator.IsValid) {
      return this.consultaRepository.insert(param);
    } else {
      throwError(validator.Errors);
    }
  }

  get(id: number): Observable<ConsultaModel> {
      return this.consultaRepository.get(id);
  }

  getAll(): Observable<ConsultaModel[]> {
    return this.consultaRepository.getAll();
  }

  delete(id: number): Observable<any> {
    return this.consultaRepository.delete(id);
  }

  update(id: number, param: ConsultaModel): Observable<any> {
    const validator = this.consultaValidator.validateFields(param);

    if (validator.IsValid) {
      return this.consultaRepository.update(id, param);
    } else {
      throwError(validator.Errors);
    }
  }
}


