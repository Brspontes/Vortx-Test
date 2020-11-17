import { PrecoCalculado, InPrecoCalculado } from './../Models/PrecoCalculadoPlano';
import { Planos } from './../Models/Planos';
import { TabelacaoPreco } from './../Models/TabelacaoPreco';
import { Injectable } from "@angular/core";
import { BaseService } from './Base.service';
import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class VxTelApiService extends BaseService {
    public tabelacaoPreco: TabelacaoPreco[];

    constructor(private http: HttpClient) {super()}

    ObterListaCobertura() : Observable<TabelacaoPreco[]> {
        return this.http
            .get<TabelacaoPreco[]>(this.UrlServiceV1 + 'TabelaPrecos')
            .pipe(catchError(super.serviceError));
    }

    ObterListaPlanos(): Observable<Planos[]> {
        return this.http
            .get<Planos[]>(this.UrlServiceV1)
            .pipe(catchError(super.serviceError));
    }

    CalcularPlanos(precoCalculadoEntrada: InPrecoCalculado) : Observable<PrecoCalculado> {
        let response = this.http
            .post(this.UrlServiceV1 + 'CalculaValorMinutosPlano', precoCalculadoEntrada)
            .pipe(
                map(this.extractData),
                catchError(this.serviceError)
            );

            return response;
    }
}