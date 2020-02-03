import { Injectable } from '@angular/core';
import {HttpService} from '../http/http.service'

@Injectable({
  providedIn: 'root'
})
export class VoterService {

  constructor(private httpService : HttpService) { }

  getAllResult(){
    return this.httpService.get('api/Voting/PartyWiseAll');
  }
  
  getPartyWiseResult(state){
    return this.httpService.get('api/Voting/PartyWiseResult?state='+state)
  }
}
