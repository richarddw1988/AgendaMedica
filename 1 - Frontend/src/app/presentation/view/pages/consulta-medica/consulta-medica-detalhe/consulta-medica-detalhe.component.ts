import { Component, OnInit } from '@angular/core';
import { ConsultaModel } from 'src/app/core/domain/entity/consulta-model';
import { ConsultaControllerService } from 'src/app/presentation/controllers/consulta/consulta-controller.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import  * as moment from 'moment';


@Component({
  selector: 'app-consulta-medica-detalhe',
  templateUrl: './consulta-medica-detalhe.component.html',
  styleUrls: ['./consulta-medica-detalhe.component.scss'],
  providers: [MessageService]
})
export class ConsultaMedicaDetalheComponent implements OnInit {

  displayDialog: boolean;
  consultaForm: FormGroup;
  consulta: ConsultaModel = {};
  idConsulta: number;
  newConsulta: boolean;
  formType: string;

  constructor(
    private consultaController: ConsultaControllerService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private messageService: MessageService
    ) { }

  ngOnInit() {
    this.initilizeForm();
  }

  initilizeForm() {
    this.consultaForm = this.fb.group({
      'id': null,
      'nome': new FormControl(null, Validators.compose([Validators.required, Validators.maxLength(200)])),
      'dataNascimento': new FormControl(null, Validators.required),
      'observacoes': new FormControl(null, Validators.compose([Validators.maxLength(500)])),
      'dataHoraInicio': new FormControl(null, Validators.required),
      'dataHoraFinal': new FormControl(null , Validators.required)
    });

    this.formType = this.route.snapshot.data['formType'];

    this.idConsulta = this.route.snapshot.params['id'];
    if (this.idConsulta) {
      this.consultaController.get(this.idConsulta)
      .subscribe(consulta => {
        this.updateConsultaForm(consulta);
      });
    }
  }

  onSubmit(itemForm) {
    this.consulta.pessoa = {
      nome: itemForm.nome,
      dataNascimento: itemForm.dataNascimento
    };
    this.consulta.pessoa.dataNascimento.setHours(0, 0);
    this.consulta.dataHoraInicio = moment(itemForm.dataHoraInicio).subtract(3, 'hour').toDate();
    this.consulta.dataHoraFinal = moment(itemForm.dataHoraFinal).subtract(3, 'hour').toDate();
    this.consulta.dataHoraInicio.setSeconds(0, 0);
    this.consulta.dataHoraFinal.setSeconds(0, 0);
    this.consulta.observacoes = itemForm.observacoes;

    if (this.formType === 'insert') {
      this.consultaController.insert(this.consulta)
      .subscribe(() => {
        this.consultaForm.reset();
        this.messageService.add({severity: 'info', summary: 'Sucesso', detail: 'Operação efetuada com sucesso!'});
        this.router.navigate(['/consulta-medica']);
      }, error => {
        if (error.status === 400) {
          this.messageService.add({severity: 'error', summary: 'Erro', detail: error.error});
        } else {
          this.messageService.add({severity: 'error', summary: 'Erro', detail: 'Não foi possível efetuar a operação. Tente novamente'});
        }
      });
    } else {
      this.consultaController.update(this.idConsulta, this.consulta)
      .subscribe(() => {
        this.consultaForm.reset();
        this.messageService.add({severity: 'info', summary: 'Sucesso', detail: 'Operação efetuada com sucesso!'});
        this.router.navigate(['/consulta-medica']);
      }, error => {
        if (error.status === 400) {
          this.messageService.add({severity: 'error', summary: 'Erro', detail: error.error});
        } else {
          this.messageService.add({severity: 'error', summary: 'Erro', detail: 'Não foi possível efetuar a operação. Tente novamente'});
        }
      });
    }
  }

  formInvalid() {
    return !this.consultaForm.valid;
  }

  private updateConsultaForm(consulta: ConsultaModel) {

      this.consultaForm.patchValue({
        id: consulta.id,
        nome: consulta.pessoa.nome,
        dataNascimento: new Date(consulta.pessoa.dataNascimento),
        dataHoraInicio: new Date(consulta.dataHoraInicio),
        dataHoraFinal: new Date(consulta.dataHoraFinal),
        observacoes: consulta.observacoes
      });
  }
}
