import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { ConsultaMedicaModule } from './consulta-medica/consulta-medica.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ConsultaMedicaModule,
    PagesRoutingModule
  ],
  exports: [PagesRoutingModule]
})
export class PagesModule { }
