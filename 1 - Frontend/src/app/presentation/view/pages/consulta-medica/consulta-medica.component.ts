import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-consulta-medica',
  templateUrl: './consulta-medica.component.html',
  styleUrls: ['./consulta-medica.component.scss']
})
export class ConsultaMedicaComponent implements OnInit {
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  isLoading: boolean;
  displayedColumns: string[] = ['dataHoraInicio', 'dataHoraFinal', 'nome', 'dataNascimento', 'acoes'];
  dataSource: any;

  cars: any[];

    cols: any[];

  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.initializeCols();
    this.cars = [];
    this.cars.push({ vin: 'dsad231ff', year: 2012, brand: 'VW', color: 'Orange', acoes: 'Teste' });
    this.cars.push({ vin: 'dsad231ff', year: 2012, brand: 'VW', color: 'Orange', acoes: 'Teste' });
    this.cars.push({ vin: 'dsad231ff', year: 2012, brand: 'VW', color: 'Orange', acoes: 'Teste' });
    this.cars.push({ vin: 'dsad231ff', year: 2012, brand: 'VW', color: 'Orange', acoes: 'Teste' });
    // { vin: 'dsad231ff', year: 2012, brand: 'VW', color: 'Orange' },
    // { vin: 'dsad231ff', year: 2012, brand: 'VW', color: 'Orange' },
    // { vin: 'dsad231ff', year: 2012, brand: 'VW', color: 'Orange' }]
  }

  initializeCols() {
    this.cols = [
      { field: 'dataHoraInicio', header: 'Data hora inicio' },
      { field: 'dataHoraFinal', header: 'Data hora final' },
      { field: 'nome', header: 'Nome' },
      { field: 'dataNascimento', header: 'Data nascimento' },
      { field: 'acoes', header: 'Ações' },
    ];
  }

}
