import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class HttpserviceService {
  baseUrl = environment.BaseUrl
  constructor(private httpClient:HttpClient
    ) { }

    


  post(url, data) {
    let options = {
      headers: new HttpHeaders({
       'Authorization': 'Bearer ' + localStorage.getItem('token'),
        'Content-Type': 'application/json'
      })
    }
    return this.httpClient.post(this.baseUrl+url, data, options);
  }

  postImage(url, data) {
    let options = {
      headers: new HttpHeaders({
       'Authorization': 'Bearer ' + localStorage.getItem('token'),
       'Content-Type': 'multipart/form-data'
      })
    }
    return this.httpClient.post(this.baseUrl+url, data, options);
  }

  put(url, data) {
    let options = {
      headers: new HttpHeaders({
       'Authorization': 'Bearer ' + localStorage.getItem('token'),
        'Content-Type': 'application/json'
      })
    }
    return this.httpClient.put(this.baseUrl+url, data, options);
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

  patch(url,data) {
    let options = {
      headers: new HttpHeaders({
       'Authorization': 'Bearer ' + localStorage.getItem('token'),
        'Content-Type': 'application/json'
      })
    }    
    return this.httpClient.patch(this.baseUrl+url, data, options);
  }

//   delete(url, data) {
//     let options = {
//       headers: new HttpHeaders({
//         'Authorization': 'Bearer ' + localStorage.getItem('token'),
//          'Content-Type': 'application/json'
//        }),
//       body: {
//         id: data
//       },
//     };    
//     return this.httpClient.delete(url, options);  
// }


delete(url) {
  let options = {
    headers: new HttpHeaders({
     'Authorization': 'Bearer ' + localStorage.getItem('token'),
      'Content-Type': 'application/json'
    })
  }
  return this.httpClient.delete(this.baseUrl+url, options);
}

}