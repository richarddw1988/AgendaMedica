import { Observable } from 'rxjs';
import { ConsultaModel } from '../../domain/entity/consulta-model';

export abstract class IConsultaController {
  abstract insert(param: ConsultaModel): Observable<any>;
  abstract update(id: number, param: ConsultaModel): Observable<any>;
  abstract get(id: number): Observable<ConsultaModel>;
  abstract getAll(): Observable<ConsultaModel[]>;
  abstract delete(id: number): Observable<any>;
}
