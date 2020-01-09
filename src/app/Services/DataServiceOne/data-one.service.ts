import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataOneService {

  private messageSource = new BehaviorSubject({data:'', type:''});
  currentMessage = this.messageSource.asObservable();

  constructor() { }

  
  changeMessage(message: any) {
    this.messageSource.next(message)
  }

}
