import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IValidatorMessage } from './interfaces/message/ivalidator-message';
import { ValidatorMessageService } from './message/validator-message.service';
import { ConsultaValidatorService } from './validations/consulta/consulta-validator.service';
import { ConsultaUseCase } from './usecases/consulta/consulta-use-case';
import { IConsultaUseCase } from './interfaces/usecases/iconsulta-use-case';
import { IConsultaValidator } from './interfaces/validations/iconsulta-validator';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    { provide: IValidatorMessage, useClass: ValidatorMessageService },

    { provide: IConsultaUseCase, useClass: ConsultaUseCase },
    { provide: IConsultaValidator, useClass: ConsultaValidatorService },
  ],
})
export class CoreModule { }
