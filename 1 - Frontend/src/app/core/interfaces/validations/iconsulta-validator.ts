import { ValidationResult } from 'ts.validator.fluent/dist';
import { ConsultaModel } from '../../domain/entity/consulta-model';

export abstract class IConsultaValidator {
  abstract validateFields(param: ConsultaModel): ValidationResult;
}
