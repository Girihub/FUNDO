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

  getTrashed(){
    return this.httpService.get('api/Note/Trashed');
  }

  changeColor(data){   
    return this.httpService.patch('api/Note/'+data.id+'/ChangeColor',data);
  }

  archive(id){
    return this.httpService.post('api/Note/'+id+'/Archive',id);
  }

  trash(id){
    return this.httpService.post('api/Note/'+id+'/Trash',id)
  }

  deleteNote(id){
    return this.httpService.delete('api/Note/'+id)
  }
  
  searchNotes(word){
    return this.httpService.get('api/Note/Search?word='+word)
  }

  addReminder(data){
    return this.httpService.post('api/Note/'+data.id+'/Reminder',data)
  }

  addImage(data){
    return this.httpService.post('api/Note/'+data.id+'/Image',data)
  }

  getRemindered(){
    return this.httpService.get('api/Note/Remindered');
  }

  pin(id){
    return this.httpService.post('api/Note/'+id+'/Pin',id)
  }

  updateNote(data){
    return this.httpService.put('api/Note/'+data.Id,data)
  }
}
