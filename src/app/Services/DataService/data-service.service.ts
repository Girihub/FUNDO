import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataServiceService { 

  private labelSource = new BehaviorSubject({data:[], type:''});
  currentLabel = this.labelSource.asObservable();

  constructor() { }

  changeLabel(message: any) {
    this.labelSource.next(message)
  }

 
}