import { PrecoCalculado, InPrecoCalculado } from './../../Models/PrecoCalculadoPlano';
import { Planos } from './../../Models/Planos';
import { Component, OnInit } from '@angular/core';
import { TabelacaoPreco } from 'src/app/Models/TabelacaoPreco';
import { VxTelApiService } from 'src/app/Services/VxTelApi.service';
import { FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-simulacao-planos',
  templateUrl:'./simulacao-planos.component.html',
  styleUrls: ['./simulacao-planos.component.css'
  ]
})
export class SimulacaoPlanosComponent implements OnInit {

  public planos: Planos[];
  public entradaCalcularplano: InPrecoCalculado = new InPrecoCalculado;
  public tabelacaoPrecos: TabelacaoPreco[];
  public tempoGasto: number = 30;
  public valorComPlano: number[];
  public valorSemPlano: number[];
  public precoCalculado: PrecoCalculado = new PrecoCalculado;
  
  selectedOrigem: string;
  selectedDestino: string;
  selectedPlano: string;
  minutosDesejados: number;
  minutosPlano: number;
  
  errorMessage: any[] = [];

  constructor(private vxtelService: VxTelApiService, private modalService: NgbModal, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.vxtelService.ObterListaPlanos()
    .subscribe(
      planos => {
        this.planos = planos;
        console.log(this.planos);
      },
      error => this.errorMessage
    );

    this.vxtelService.ObterListaCobertura()
    .subscribe(
      tabelacaoPrecos => {
        this.tabelacaoPrecos = tabelacaoPrecos;
        console.log(this.tabelacaoPrecos);
      },
      error => this.errorMessage
    )

    this.precoCalculado.message = [];
  }

  CalcularPrecosComPlano(tempoGasto: number, custoMin: number) : number {
    return (((this.tempoGasto * custoMin) + (((this.tempoGasto) * custoMin) * 10) / 100))
  }

  CalcularPrecosSemPlano(tempoGasto: number, custoMin: number) : number {
    return tempoGasto * custoMin
  }

  ConsultaOrigemDestino() {
    this.vxtelService.ObterListaCobertura()
    .subscribe(
      tabelacaoPrecos => {
        this.tabelacaoPrecos = tabelacaoPrecos;
        console.log(this.tabelacaoPrecos);
      },
      error => this.errorMessage
    )
  }
    
  RealizarSimulacao() {

    this.entradaCalcularplano.Origem = this.selectedOrigem;
    this.entradaCalcularplano.Destino = this.selectedDestino;
    this.entradaCalcularplano.MinutosPlano = this.minutosPlano;

     if(this.minutosDesejados <= 0){
       return;
     }

     this.entradaCalcularplano.MinutosDesejados = this.minutosDesejados;

    this.vxtelService.CalcularPlanos(this.entradaCalcularplano)
      .subscribe(
        sucesso => { 
          this.precoCalculado = sucesso; 
          console.log(sucesso); 
        },
        erro => this.errorMessage = erro
      );
  }

  abrirModal(content) {
    this.modalService.open(content);
  }

}
