import * as automapper from 'automapper-ts';

import { Mapper } from '../../base/mapper';
import { IPessoaRequestEntity } from './ipessoa-request-entity';
import { IPessoaResponseEntity } from './ipessoa-response-entity';
import { PessoaModel } from 'src/app/core/domain/entity/pessoa-model';


export class PessoaMapper extends Mapper<IPessoaRequestEntity, IPessoaResponseEntity, PessoaModel> {
  mapFrom(param: IPessoaResponseEntity): PessoaModel {
    automapper.createMap('PessoaModel', PessoaModel);

    return automapper.map('PessoaModel', PessoaModel, param);
  }

  mapTo(param: PessoaModel): IPessoaRequestEntity {
    automapper
      .createMap('IPessoaRequestEntity', IPessoaRequestEntity);

    return automapper.map('IPessoaRequestEntity', IPessoaRequestEntity, param);
  }

}
