import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { IConsultaController } from 'src/app/core/interfaces/controllers/Iconsulta-controller';
import { IConsultaUseCase } from 'src/app/core/interfaces/usecases/iconsulta-use-case';
import { ConsultaModel } from 'src/app/core/domain/entity/consulta-model';

@Injectable({
  providedIn: 'root'
})
export class ConsultaControllerService implements IConsultaController {

  constructor(
    private consultaUseCase: IConsultaUseCase
  ) { }

  insert(param: ConsultaModel): Observable<any> {
    return this.consultaUseCase.insert(param);
  }
  update(id: number, param: ConsultaModel): Observable<any> {
    return this.consultaUseCase.update(id, param);
  }
  get(id: number): Observable<ConsultaModel> {
    return this.consultaUseCase.get(id);
  }
  getAll(): Observable<ConsultaModel[]> {
    return this.consultaUseCase.getAll();
  }
  delete(id: number): Observable<any> {
    return this.consultaUseCase.delete(id);
  }
}
