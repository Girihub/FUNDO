import { Injectable } from '@angular/core';
import { HttpserviceService } from './httpService/httpservice.service';




@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpService: HttpserviceService) { }

  login(user){
    return this.httpService.post('api/Account/UserLogin',user);
  }

  register(data){
    return this.httpService.post('api/Account/UserRegistration',data);
  }

  forget(data){
    return this.httpService.post('api/Account/ForgotPassword',data);
  }

  reset(data){
    return this.httpService.post('api/Account/ResetPassword',data);
  }  

  getUsers(){
    return this.httpService.get('api/Admin/UserList');
  }
}



