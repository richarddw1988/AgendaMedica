import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaMedicaComponent } from './consulta-medica.component';
import { AppMaterialModule } from 'src/app/app-material.module';
import { of } from 'rxjs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '../../shared/shared.module';
import { MatDialog } from '@angular/material';

class MatDialogMock {
  // When the component calls this.dialog.open(...) we'll return an object
  // with an afterClosed method that allows to subscribe to the dialog result observable.
  open() {
    return {
      afterClosed: () => of(true)
    };
  }
}

describe('ConsultaMedicaComponent', () => {
  let component: ConsultaMedicaComponent;
  let fixture: ComponentFixture<ConsultaMedicaComponent>;
  let dialog: MatDialogMock;

  beforeEach(async(() => {
    const controllerSpy = jasmine.createSpyObj('IUsuarioController', ['get', 'insert', 'update', 'disableEnable']);

    TestBed.configureTestingModule({
      declarations: [ ConsultaMedicaComponent ],
      imports: [
        AppMaterialModule,
        BrowserAnimationsModule,
        SharedModule
      ],
      providers: [
        { provide: MatDialog, useClass: MatDialogMock }
      ]
    })
    .compileComponents()
    .then(() => {
      fixture = TestBed.createComponent(ConsultaMedicaComponent);
      component = fixture.componentInstance;
      dialog = TestBed.get(MatDialog);
    });
  }));

  it('deve criar', () => {
    expect(component).toBeTruthy();
  });
});
