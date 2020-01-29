import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

import { map } from 'rxjs/operators';

import { ConsultaMapper } from './consulta-mapper';
import { IConsultaRepository } from 'src/app/core/interfaces/repository/iconsulta-repository';
import { ConsultaModel } from 'src/app/core/domain/entity/consulta-model';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})
export class ConsultaRepository implements IConsultaRepository {

  private mapper = new ConsultaMapper();

  // Por algum motivo não está pegando o valor do environments, definido localhost na mão

  constructor(
    private http: HttpClient
  ) { }

  get(id: number): Observable<ConsultaModel> {
    return this.http.get<ConsultaModel>(`http://localhost:5000/api/consulta/${id}`);
  }

  getAll(): Observable<ConsultaModel[]> {
    return this.http.get<ConsultaModel[]>(`http://localhost:5000/api/consulta/getList`);
  }

  insert(param: ConsultaModel): Observable<any>{
    return this.http.post("http://localhost:5000/api/consulta", param);
  }

  update(id: number, param: ConsultaModel) : Observable<any> {
    return this.http.put(`http://localhost:5000/api/consulta/${id}`, param);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`http://localhost:5000/api/consulta/${id}`);
  }
}
