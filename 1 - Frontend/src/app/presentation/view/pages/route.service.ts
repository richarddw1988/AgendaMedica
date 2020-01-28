import { Injectable } from '@angular/core';
import { Routes, Route as ngRoute } from '@angular/router';
import { BaseComponent } from '../base/base.component';

@Injectable({
  providedIn: 'root'
})
export class RouteService {

  static withShell(routes: Routes): ngRoute {
    return {
      path: '',
      component: BaseComponent,
      children: routes,
    };
  }

}
