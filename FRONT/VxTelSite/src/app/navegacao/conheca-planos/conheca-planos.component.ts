import { VxTelApiService } from './../../Services/VxTelApi.service';
import { TabelacaoPreco } from './../../Models/TabelacaoPreco';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-conheca-planos',
  templateUrl: 'conheca-planos.component.html',
  styleUrls: [
    './conheca-planos.component.css'
  ]
})
export class ConhecaPlanosComponent implements OnInit {

  public tabelacaoPrecos: TabelacaoPreco[];
  errorMessage: string;

  constructor(private vxtelService: VxTelApiService) { }

  ngOnInit(): void {
    this.vxtelService.ObterListaCobertura()
      .subscribe(
        tabelacaoPrecos => {
          this.tabelacaoPrecos = tabelacaoPrecos;
          console.log(this.tabelacaoPrecos);
        },
        error => this.errorMessage
      )
  }
}
