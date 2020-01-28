import { IPessoaResponseEntity } from '../pessoa/ipessoa-response-entity';

export class IConsultaResponseEntity {
  id?: number = null;
  dataHoraInicio?: Date = null;
  dataHoraFinal?: Date = null;
  observacoes?: string = null;
  paciente?: IPessoaResponseEntity = null;
}
