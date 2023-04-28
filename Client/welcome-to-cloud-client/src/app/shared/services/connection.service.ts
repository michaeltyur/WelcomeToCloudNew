import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseEntity } from '../models/response-entity';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
  //http://localhost/welcome_to_cloud_fr/welcome-to-cloud/get-data/data/test
  private baseCoreUrl: string = `http://bamadevwscore01/WelcomeToCloud.Core/welcome-to-cloud`;
  private baseFrUrl: string = `http://bamadevwscore01/WelcomeToCloud.Framework/welcome-to-cloud`;
  //private baseCoreUrl: string = `http://bamadevws126/welcome_to_cloud_core/welcome-to-cloud`;
  //private baseFrUrl: string = `http://bamadevws126/welcome_to_cloud_fr/welcome-to-cloud`;
  public baseUrl: string = "";
  $frameworkChangedEmitter: EventEmitter<boolean> = new EventEmitter<boolean>();
  $urlEmitter: EventEmitter<string> = new EventEmitter<string>();
  constructor(private http: HttpClient) {
    let currentHref: string = window.location.href;
    console.log(currentHref);
    this.baseUrl = this.baseFrUrl;

    this.$frameworkChangedEmitter.subscribe(x => {
      if (x) {
        this.baseUrl = this.baseCoreUrl;
      }
      else {
        this.baseUrl = this.baseFrUrl;
      }
    });
  }

  getRandomFact(): Observable<any> {

    let data = {
      Data: "data"
    };
    const headers = new HttpHeaders()
      .set('content-type', 'application/json')
    //.set('Access-Control-Allow-Origin', '*')
    //.set('Access-Control-Allow-Headers','Content-Type, Authorization, Password');

    let url = `${this.baseUrl}/get-data`
    this.$urlEmitter.emit(url);
    return this.http.post(url, data, { 'headers': headers, withCredentials: true });

  }
  hello(): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json')
      .set('Access-Control-Allow-Origin', '*');

    let url = `${this.baseUrl}/hello`
    return this.http.get(`http://bamadevws126/welcome_to_cloud_fr/welcome-to-cloud/hello`, { 'headers': headers, withCredentials: true });
  }
}
