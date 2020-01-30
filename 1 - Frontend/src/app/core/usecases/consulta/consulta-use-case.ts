import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { IConsultaUseCase } from '../../interfaces/usecases/iconsulta-use-case';
import { IConsultaRepository } from '../../interfaces/repository/iconsulta-repository';
import { ConsultaModel } from '../../domain/entity/consulta-model';


@Injectable({
  providedIn: 'root'
})
export class ConsultaUseCase implements IConsultaUseCase {

  constructor(
    private consultaRepository: IConsultaRepository,
  ) { }

  insert(param: ConsultaModel): Observable<any> {
    return this.consultaRepository.insert(param);
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
    return this.consultaRepository.update(id, param);
  }
}


