import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { CalendarModule } from 'primeng/calendar';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ToastModule } from 'primeng/toast';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ConfirmationService, MessageService } from 'primeng/api';

import { AppMaterialModule } from 'src/app/app-material.module';
import { ConsultaMedicaComponent } from './consulta-medica.component';
import { ConsultaMedicaRoutingModule } from './consulta-medica-routing.module';
import { ConsultaMedicaDetalheComponent } from './consulta-medica-detalhe/consulta-medica-detalhe.component';

@NgModule({
  declarations: [
    ConsultaMedicaComponent,
    ConsultaMedicaDetalheComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    AppMaterialModule,
    ConsultaMedicaRoutingModule,
    TableModule,
    InputTextModule,
    ButtonModule,
    DialogModule,
    CalendarModule,
    FormsModule,
    InputTextareaModule,
    ToastModule,
    ConfirmDialogModule,
    MessagesModule,
    ReactiveFormsModule,
    MessageModule
  ],
  exports: [
    ConsultaMedicaComponent,
    ConsultaMedicaDetalheComponent
  ],
  providers: [ConfirmationService, MessageService]
})
export class ConsultaMedicaModule { }
