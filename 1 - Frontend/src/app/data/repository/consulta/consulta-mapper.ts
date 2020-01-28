import * as automapper from 'automapper-ts';

import { Mapper } from '../../base/mapper';
import { IConsultaRequestEntity } from './iconsulta-request-entity';
import { IConsultaResponseEntity } from './iconsulta-response-entity';
import { ConsultaModel } from 'src/app/core/domain/entity/consulta-model';

export class ConsultaMapper extends Mapper<IConsultaRequestEntity, IConsultaResponseEntity, ConsultaModel> {
  mapFrom(param: IConsultaResponseEntity): ConsultaModel {
    automapper.createMap('ConsultaModel', ConsultaModel);

    return automapper.map('ConsultaModel', ConsultaModel, param);
  }

  mapTo(param: ConsultaModel): IConsultaRequestEntity {
    automapper
      .createMap('IConsultaRequestEntity', IConsultaRequestEntity);

    return automapper.map('IConsultaRequestEntity', IConsultaRequestEntity, param);
  }

}
