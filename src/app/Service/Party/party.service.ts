import { Injectable } from '@angular/core';
import {HttpService} from '../http/http.service';

@Injectable({
  providedIn: 'root'
})
export class PartyService {

  constructor(private httpService : HttpService) { }

  getParty(){
    return this.httpService.get('api/Party');
  }

  addParty(data){
    return this.httpService.post('api/Party',data);
  }

  updateParty(id,data){    
    return this.httpService.put('api/Party/'+id,data)
  }

  deleteParty(id){
    return this.httpService.delete('api/Party/'+id);
  }
}
