import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

import { ConsultaMapper } from './consulta-mapper';
import { IConsultaRepository } from 'src/app/core/interfaces/repository/iconsulta-repository';
import { ConsultaModel } from 'src/app/core/domain/entity/consulta-model';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root',
})
export class ConsultaRepository implements IConsultaRepository {


  private mapper = new ConsultaMapper();

  constructor(
    private http: HttpClient
  ) { }

  get(id: number): Observable<ConsultaModel> {
    return this.http
      .get<ConsultaModel>(environment.serverUrl + `/consulta/${id}`)
      .pipe(map((item) => {
        if (item[0]) {
          return this.mapper.mapFrom(item[0]);
        }
        return null;
      }));
  }

  getAll(): Observable<ConsultaModel[]> {
    const objs: ConsultaModel[] = [];
    this.http.get<ConsultaModel[]>(environment.serverUrl + `/consulta/getAll`)
    .pipe(map((itens) => {
      if (itens[0]) {
        itens.forEach((item) => {
          objs.push(this.mapper.mapFrom(item[0]));
        });
        return objs;
      }
      return null;
    }));
    return null;
  }

  insert(param: ConsultaModel) {
    this.http.post(environment.serverUrl + `/consulta`, param);
  }

  update(id: number, param: ConsultaModel) {
    this.http.put(environment.serverUrl + `/consulta/${id}`, param);
  }

  delete(id: number) {
    this.http.delete(environment.serverUrl + `/consulta/${id}`);
  }
}
