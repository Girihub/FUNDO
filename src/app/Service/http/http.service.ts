import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  baseUrl = environment.BaseUrl
  constructor(private httpClient:HttpClient) { 

  }
  post(url, data) {
    let options = {
      headers: new HttpHeaders({
       'Authorization': 'Bearer ' + localStorage.getItem('token'),
        'Content-Type': 'application/json'
      })
    }
    return this.httpClient.post(this.baseUrl+url, data, options);
  }

  get(url) {
    let options = {
      headers: new HttpHeaders({
       'Authorization': 'Bearer ' + localStorage.getItem('token'),
        'Content-Type': 'application/json'
      })
    }
    return this.httpClient.get(this.baseUrl+url, options);
  }
}
