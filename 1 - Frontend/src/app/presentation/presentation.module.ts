import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ViewModule } from './view/view.module';

import { IConsultaController } from '../core/interfaces/controllers/iconsulta-controller';
import { ConsultaControllerService } from './controllers/consulta/consulta-controller.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ViewModule
  ],
  exports: [ViewModule],
  providers: [
    { provide: IConsultaController, useClass: ConsultaControllerService },
  ]
})
export class PresentationModule { }
