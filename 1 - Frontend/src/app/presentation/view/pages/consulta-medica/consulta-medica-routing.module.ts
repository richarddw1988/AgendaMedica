import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RouteService } from '../route.service';
import { ConsultaMedicaComponent } from './consulta-medica.component';

const routes: Routes = [
  RouteService.withShell([
    { path: '', redirectTo: '/consulta-medica', pathMatch: 'full' },
    {
      path: 'consulta-medica',
      component: ConsultaMedicaComponent,
      data: {
        title: 'Consulta Médica'
      }
    }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsultaMedicaRoutingModule { }
