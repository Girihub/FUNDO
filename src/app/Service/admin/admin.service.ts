import { Injectable } from '@angular/core';
import { HttpService } from './../http/http.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpService: HttpService) { }

  login(admin){  
    return this.httpService.post('api/Admin/AdminLogin',admin);
  }

  usersList(){
    return this.httpService.get('api/Account/AllUsers')
  }
}
