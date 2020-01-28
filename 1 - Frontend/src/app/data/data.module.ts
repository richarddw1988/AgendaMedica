import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { IConsultaRepository } from '../core/interfaces/repository/iconsulta-repository';
import { ConsultaRepository } from './repository/consulta/consulta-repository';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    { provide: IConsultaRepository, useClass: ConsultaRepository },
  ]
})
export class DataModule { }
