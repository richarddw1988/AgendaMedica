import { Component, OnInit } from '@angular/core';
import { ConsultaModel } from 'src/app/core/domain/entity/consulta-model';
import { ConsultaControllerService } from 'src/app/presentation/controllers/consulta/consulta-controller.service';
import { PessoaModel } from 'src/app/core/domain/entity/pessoa-model';

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

  calendarLocaleBR: any;

  constructor(private consultaController: ConsultaControllerService) { }

  ngOnInit() {
    this.configCalendar();
    this.initialize();
    this.configCols();
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

  configCols(){
    this.cols = [
      { field: 'dataHoraInicio', header: 'Data hora inicio' },
      { field: 'dataHoraFinal', header: 'Data hora final' },
      { field: 'nome', header: 'Nome' },
      { field: 'dataNascimento', header: 'Data nascimento' }
  ];
  }

  configCalendar(){
    this.calendarLocaleBR = {
      firstDayOfWeek: 0,
      dayNames: [ "domingo","segunda","terça","quarta","quinta","sexta","sábado" ],
      dayNamesShort: [ "dom","seg","ter","qua","qui","sex","sáb" ],
      dayNamesMin: [ "MO","TU","WE","TH","FR","SA","SU" ],
      monthNames: [ "janeiro","fevereiro","março","abril","maio","junho","julho","agosto","setembro","outubro","novembro","dezembro" ],
      monthNamesShort: [ "jan","fev","mar","abr","mai","jun","jul","ago","set","out","nov","dez" ],
      today: 'Hoje',
      clear: 'Limpar'
    };
  }

  showDialogToAdd() {
      this.newConsulta = true;
      this.consulta = {};
      this.consulta.pessoa = {
        nome: '',
        dataNascimento: null
      };
      this.displayDialog = true;
  }

  save() {
    const consultas = [...this.consultas];

    if (this.newConsulta) {
      this.consultaController.insert(this.consulta).subscribe(() => {
        consultas.push(this.consulta);
      });
    } else {
      this.consultaController.update(this.consulta.id, this.consulta)
      .subscribe(() => {
        consultas[this.consultas.indexOf(this.selectedConsulta)] = this.consulta;
      });
    }
    this.consultas = consultas;

    this.consulta = null;
    this.displayDialog = false;
  }

  delete() {
      this.consultaController.delete(this.consulta.id).subscribe(() => {
        const index = this.consultas.indexOf(this.selectedConsulta);
        this.consultas = this.consultas.filter((val, i) => i !== index);
        this.consulta = null;
      });

      this.displayDialog = false;
  }

  onRowSelect(event) {
      this.newConsulta = false;
      this.consulta = this.cloneConsulta(event.data);
      this.displayDialog = true;
  }

  cloneConsulta(c: ConsultaModel): ConsultaModel {
      let consulta = {};
      for (let prop in c) {
          consulta[prop] = c[prop];
      }
      return consulta;
  }

}
