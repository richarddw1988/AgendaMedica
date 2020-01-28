import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppMaterialModule } from 'src/app/app-material.module';
import { ConsultaMedicaRoutingModule } from './consulta-medica-routing.module';
import { ConsultaMedicaComponent } from './consulta-medica.component';
import {TableModule} from 'primeng/table';
import {InputTextModule} from 'primeng/inputtext';
import {ButtonModule} from 'primeng/button';

@NgModule({
  declarations: [ConsultaMedicaComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    AppMaterialModule,
    ConsultaMedicaRoutingModule,
    TableModule,
    InputTextModule,
    ButtonModule,
  ]
})
export class ConsultaMedicaModule { }
