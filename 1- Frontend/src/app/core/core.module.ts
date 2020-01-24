import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IValidatorMessage } from './interfaces/message/ivalidator-message';
import { ValidatorMessageService } from './message/validator-message.service';
import { UsuarioValidatorService } from './validations/usuario/usuario-validator.service';
import { IUsuarioValidator } from './interfaces/validations/iusuario-validator';
import { UsuarioUseCase } from './usecases/usuario/usuario-use-case';
import { IUsuarioUseCase } from './interfaces/usecases/iusuario-use-case';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    { provide: IValidatorMessage, useClass: ValidatorMessageService },

    { provide: IUsuarioUseCase, useClass: UsuarioUseCase },
    { provide: IUsuarioValidator, useClass: UsuarioValidatorService },
  ],
})
export class CoreModule { }
