import { DomainModel } from './base/domain-model';
import { PessoaModel } from './pessoa-model';

export class ConsultaModel extends DomainModel {
  dataHoraInicio?: Date = null;
  dataHoraFinal?: Date = null;
  observacoes?: string = null;
  paciente?: PessoaModel = null;
}
