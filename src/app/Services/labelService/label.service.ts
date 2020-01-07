import { Injectable } from '@angular/core';
import { HttpserviceService } from '../httpService/httpservice.service';

@Injectable({
  providedIn: 'root'
})
export class LabelService {

  constructor(private httpService: HttpserviceService) { }

  getLabels(){
    return this.httpService.get('api/Lable');
  }
}


