import { IPessoaRequestEntity } from '../pessoa/ipessoa-request-entity';

export class IConsultaRequestEntity {
  dataHoraInicio: Date = null;
  dataHoraFinal: Date = null;
  observacoes: string = null;
  paciente: IPessoaRequestEntity = null;
}
