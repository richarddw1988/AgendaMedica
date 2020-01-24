import { Injectable } from '@angular/core';
import { IValidatorMessage } from '../interfaces/message/ivalidator-message';

@Injectable({
  providedIn: 'root'
})
export class ValidatorMessageService implements IValidatorMessage {

  constructor(
  ) { }

  required(field: string) {
    return '';
  }
  maximumSize(field: string, characters: string) {
    return '';
  }
}
