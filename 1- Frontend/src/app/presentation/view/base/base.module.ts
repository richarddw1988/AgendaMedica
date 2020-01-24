import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { BaseComponent } from './base.component';
import { AppMaterialModule } from 'src/app/app-material.module';

@NgModule({
  declarations: [BaseComponent],
  imports: [
    CommonModule,
    RouterModule,
    AppMaterialModule
  ]
})
export class BaseModule { }
