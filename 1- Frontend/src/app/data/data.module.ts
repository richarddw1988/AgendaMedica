import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { IUsuarioRepository } from '../core/interfaces/repository/iusuario-repository';
import { UsuarioRepository } from './repository/usuario/usuario-repository';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    { provide: IUsuarioRepository, useClass: UsuarioRepository },
  ]
})
export class DataModule { }
