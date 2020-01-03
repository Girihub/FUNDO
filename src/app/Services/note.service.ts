import { Injectable } from '@angular/core';
import { HttpserviceService } from './httpService/httpservice.service';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private httpService: HttpserviceService) { }

  createNote(note){
    return this.httpService.post('api/Note',note);
  }

  getNotes(){
    return this.httpService.get('api/Note');
  }

  getArchived(){
    return this.httpService.get('api/Note/Archived');
  }
}
