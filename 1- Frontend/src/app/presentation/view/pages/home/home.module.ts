import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppMaterialModule } from 'src/app/app-material.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    AppMaterialModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
