import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeComponent } from './home.component';
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

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let dialog: MatDialogMock;

  beforeEach(async(() => {
    const controllerSpy = jasmine.createSpyObj('IUsuarioController', ['get', 'insert', 'update', 'disableEnable']);

    TestBed.configureTestingModule({
      declarations: [ HomeComponent ],
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
      fixture = TestBed.createComponent(HomeComponent);
      component = fixture.componentInstance;
      dialog = TestBed.get(MatDialog);
    });
  }));

  it('deve criar', () => {
    expect(component).toBeTruthy();
  });
});
