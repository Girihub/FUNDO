import { Injectable } from '@angular/core';
import {HttpService} from '../http/http.service'

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private httpService : HttpService) { }

  getCandidates(){
    return this.httpService.get('api/Candidate');
  }

  addCandidate(data){
    return this.httpService.post('api/Candidate',data);
  }

  updateCandidate(data){
    return this.httpService.put('api/Candidate/'+data.candidateId,data)
  }

  deleteCandidate(id){
    return this.httpService.delete('api/Candidate/'+id);
  }
}
