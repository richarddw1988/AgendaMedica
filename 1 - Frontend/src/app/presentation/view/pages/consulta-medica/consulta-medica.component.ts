import { Component, OnInit } from '@angular/core';
import { ConsultaModel } from 'src/app/core/domain/entity/consulta-model';
import { ConsultaControllerService } from 'src/app/presentation/controllers/consulta/consulta-controller.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-consulta-medica',
  templateUrl: './consulta-medica.component.html',
  styleUrls: ['./consulta-medica.component.scss']
})
export class ConsultaMedicaComponent implements OnInit {

  consulta: ConsultaModel = {};

  consultas: ConsultaModel[] = [];

  cols: any[];

  constructor(
    private consultaController: ConsultaControllerService,
    private messageService: MessageService
  ) { }

  ngOnInit() {
    this.initialize();
  }

  initialize() {
    this.consulta.pessoa = {
      nome: '',
      dataNascimento: null
    };

    this.consultaController.getAll().subscribe(res => {
      this.consultas = res;
    });
  }

  delete(consulta) {
      this.consultaController.delete(consulta.id).subscribe(() => {
        this.consultas = this.consultas.filter((val) => val.id !== consulta.id);
        this.consulta = null;
      },
      error => {
        this.messageService.add({severity: 'error', summary: 'Erro', detail: 'Não foi possível efetuar a operação. Tente novamente'});
      }
    );
  }
}
