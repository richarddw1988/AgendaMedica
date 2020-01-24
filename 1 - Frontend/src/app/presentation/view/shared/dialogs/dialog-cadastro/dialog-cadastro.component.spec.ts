import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCadastroComponent } from './dialog-cadastro.component';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { NotificationService } from '../../notification/notification.service';


describe('DialogCadastroComponent:', () => {
  let component: DialogCadastroComponent;
  let fixture: ComponentFixture<DialogCadastroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogCadastroComponent ],
      providers: [
        FormBuilder,
        MatDialogRef,
        NotificationService
      ],
      imports: []
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('deve criar', () => {
    expect(component).toBeTruthy();
  });

  xit('deve criar o form', () => {

  });
});
