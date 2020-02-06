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

  vote(data){
    return this.httpService.post('api/Voting/Vote',data);
  }

  reElection(){
    return this.httpService.reElection('api/Voting/Re-Election');
  }

  allVoters(){
    return this.httpService.get('api/Voting/AllVoters');
  }
}
