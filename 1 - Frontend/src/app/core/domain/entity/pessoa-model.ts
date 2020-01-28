import { DomainModel } from './base/domain-model';
export class PessoaModel extends DomainModel {
  nome?: string = null;
  dataNascimento?: Date = null;
}
