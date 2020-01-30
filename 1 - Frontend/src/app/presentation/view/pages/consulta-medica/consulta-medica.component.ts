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

  displayDialog: boolean;

  consulta: ConsultaModel = {};

  selectedConsulta: ConsultaModel;

  newConsulta: boolean;

  consultas: ConsultaModel[] = [];

  cols: any[];

  constructor(
    private consultaController: ConsultaControllerService,
    private messageService: MessageService
  ) { }

  ngOnInit() {
    this.initialize();
  }

  initialize(){
    this.consulta.pessoa = {
      nome: '',
      dataNascimento: null
    };

    this.consultaController.getAll().subscribe(res => {
      this.consultas = res;
    });
  }


  save() {
    const consultas = [...this.consultas];

    if (this.newConsulta) {
      this.consultaController.insert(this.consulta).subscribe(() => {
        consultas.push(this.consulta);
        this.consultas = consultas;
        this.consulta = null;
      },
      error => {
        this.messageService.add({severity: 'error', summary: 'Erro', detail: 'Não foi possível efetuar a operação. Tente novamente'});
      });
    } else {
      this.consultaController.update(this.consulta.id, this.consulta)
      .subscribe(() => {
        consultas[this.consultas.indexOf(this.selectedConsulta)] = this.consulta;
        this.consultas = consultas;
        this.consulta = null;
      },
      error => {
        this.messageService.add({severity: 'error', summary: 'Erro', detail: 'Não foi possível efetuar a operação. Tente novamente'});
      });
    }
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
