import { Observable } from 'rxjs';
import { ConsultaModel } from '../../domain/entity/consulta-model';

export abstract class IConsultaController {
  abstract insert(param: ConsultaModel);
  abstract update(id: number, param: ConsultaModel);
  abstract get(id: number): Observable<ConsultaModel>;
  abstract getAll(): Observable<ConsultaModel[]>;
  abstract delete(id: number);
}
