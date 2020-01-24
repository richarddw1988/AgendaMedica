import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

import { UsuarioMapper } from './usuario-mapper';
import { IUsuarioRepository } from 'src/app/core/interfaces/repository/iusuario-repository';
import { UsuarioModel } from 'src/app/core/domain/entity/usuario-model';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UsuarioRepository implements IUsuarioRepository {

  private mapper = new UsuarioMapper();

  constructor(
    private http: HttpClient
  ) { }

  login(param: UsuarioModel): Observable<UsuarioModel> {
    const usuario = this.mapper.mapTo(param);

    return this.http
      .get<UsuarioModel>(environment.serverUrl + '/usuario?username=' + usuario.username + '&password=' + usuario.password + '')
      .pipe(map((item) => {
        if (item[0]) {
          return this.mapper.mapFrom(item[0]);
        }

        return null;
      }));
  }

  logout(): Observable<boolean> {
    return of(true);
  }


}
