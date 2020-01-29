import { Injectable } from '@angular/core';
import { ValidationResult, Validator, IValidator } from 'ts.validator.fluent/dist';

import { IValidatorMessage } from '../../interfaces/message/ivalidator-message';
import { IConsultaValidator } from '../../interfaces/validations/iconsulta-validator';
import { ConsultaModel } from '../../domain/entity/consulta-model';


@Injectable({
  providedIn: 'root'
})
export class ConsultaValidatorService implements IConsultaValidator {

  constructor(
    protected validatorMessage: IValidatorMessage
  ) { }

  validateFields(param: ConsultaModel): ValidationResult {
    return new Validator(param).Validate(this.validateRules);
  }

  validateRules = (validator: IValidator<ConsultaModel>): ValidationResult => {
    return validator
      .NotNull(m => m.dataHoraInicio, this.validatorMessage.required('Data hora início').value)
      .NotNull(m => m.dataHoraFinal, this.validatorMessage.required('Data hora final').value)
      .NotNull(m => m.pessoa, this.validatorMessage.required('Paciente').value)
      .NotEmpty(m => m.pessoa.nome, this.validatorMessage.required('Nome').value)
      .Length(m => m.pessoa.nome, 1, 200, this.validatorMessage.maximumSize('Nome', '200').value)
      .NotNull(m => m.pessoa.dataNascimento, this.validatorMessage.required('Data nascimento').value)
      .ToResult();
  }
}
