import { Injectable } from '@angular/core';
import {HttpService} from '../http/http.service'

@Injectable({
  providedIn: 'root'
})
export class ConstituencyService {

  constructor(private httpService : HttpService) { }

  getConstituency(){
    return this.httpService.get('api/Constituent');
  }

  addConstituency(data){
    return this.httpService.post('api/Constituent',data);
  }

  updateConstituency(data){
    return this.httpService.put('api/Constituent/'+data.constituentId ,data)
  }

  deleteConstituency(id){
    return this.httpService.delete('api/Constituent/'+id);
  }
}
