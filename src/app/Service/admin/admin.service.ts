import { Injectable } from '@angular/core';
import {HttpService} from '../http/http.service'

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpService : HttpService) { }

  login(data){
    return this.httpService.post('api/Admin/Login',data);
  }

  register(data){
    return this.httpService.post('api/Admin/Registration',data);
  }
}
