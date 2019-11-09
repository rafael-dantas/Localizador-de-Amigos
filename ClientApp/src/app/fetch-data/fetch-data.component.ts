import { Component, Inject } from '@angular/core';
import { HttpClient,HttpParams, HttpHeaders } from '@angular/common/http';
import { inject } from '@angular/core/testing';

interface WeatherForecast {
  id: number;
  nome: string;
  login: string;
  latitude: number;
  longitude: number;
  distancia: number;
}

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})


export class FetchDataComponent {
  
  public forecasts: WeatherForecast[];
  public erro: string;
  txtLatitude = '-23.569226';
  txtLongitude = '-46.505607';
  txtToken = 'token';
  
  constructor(private http: HttpClient){

  }

  Pesquisar(){
    
     const url = 'http://localhost:57630/api/amigo';
     const params = new HttpParams().set('token',`${this.txtToken}`).set('latitude',`${this.txtLatitude}`).set('longitude',`${this.txtLongitude}`);
     const  headers = new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
      this.erro = '';
     if(this.txtLatitude == "" || this.txtLongitude == "" || this.txtToken == ""){
      this.erro = 'FAVOR PREENCHER TODOS OS CAMPOS';
     }else{
     this.http.post<WeatherForecast[]>(url,{},{params,headers})
     .subscribe(
         result => {
          this.forecasts = result;
         }
      , error => {
        console.log(error);
        let mensagem = error.status == 401 ? 'Token Invalido' : error.headers.mensagem;
        this.erro = error.status +" - " + mensagem + " (" + error.headers.statusText + ")"});    
    }
  }
}


