import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConsultaUseCase } from './usecases/consulta/consulta-use-case';
import { IConsultaUseCase } from './interfaces/usecases/iconsulta-use-case';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    { provide: IConsultaUseCase, useClass: ConsultaUseCase }
  ],
})
export class CoreModule { }
