import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RouteService } from '../route.service';
import { ConsultaMedicaComponent } from './consulta-medica.component';
import { ConsultaMedicaDetalheComponent } from './consulta-medica-detalhe/consulta-medica-detalhe.component';

const routes: Routes = [
  RouteService.withShell([
    { path: '', redirectTo: '/consulta-medica', pathMatch: 'full' },
    {
      path: 'consulta-medica',
      component: ConsultaMedicaComponent,
      data: {
        title: 'Consulta Médica'
      }
    },
    {
      path: 'consulta-medica-detalhe',
      component: ConsultaMedicaDetalheComponent,
      data: {
        formType: 'insert',
        title: 'Consulta Médica Detalhe'
      }
    },
    {
      path: 'consulta-medica-detalhe/:id',
      component: ConsultaMedicaDetalheComponent,
      data: {
        formType: 'update',
        title: 'Consulta Médica Detalhe'
      }
    }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsultaMedicaRoutingModule { }
