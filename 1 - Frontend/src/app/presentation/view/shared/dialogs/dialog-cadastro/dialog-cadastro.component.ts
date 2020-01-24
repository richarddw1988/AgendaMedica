import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { finalize } from 'rxjs/operators';
import { MatDialogRef } from '@angular/material';
import * as _ from 'lodash';
import { NotificationService } from '../../notification/notification.service';

@Component({
  selector: 'app-dialog-cadastro',
  templateUrl: './dialog-cadastro.component.html',
  styleUrls: ['./dialog-cadastro.component.scss']
})
export class DialogCadastroComponent implements OnInit {

  form: FormGroup;
  documents: FormArray;
  isLoading: boolean;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<DialogCadastroComponent>,
    private notification: NotificationService
  ) {  }

  ngOnInit() {

  }
}
