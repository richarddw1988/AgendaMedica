import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { PresentationModule } from './presentation/presentation.module';
import { CoreModule } from './core/core.module';
import { InfraModule } from './infra/infra.module';
import { DataModule } from './data/data.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CoreModule,
    DataModule,
    InfraModule,
    PresentationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
