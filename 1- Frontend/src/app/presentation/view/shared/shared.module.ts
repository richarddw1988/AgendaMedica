import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NotificationComponent } from './notification/notification.component';
import { AppMaterialModule } from 'src/app/app-material.module';
import { InputComponent } from './components/input/input.component';
import { DialogCadastroComponent } from './dialogs/dialog-cadastro/dialog-cadastro.component';

@NgModule({
  declarations: [
    InputComponent,
    DialogCadastroComponent,
    NotificationComponent
  ],
  exports: [InputComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AppMaterialModule
  ],
  entryComponents: [
    DialogCadastroComponent,
    NotificationComponent
  ]
})
export class SharedModule { }
