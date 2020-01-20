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
    return this.httpService.get('api/Note/GetNotesResponse');
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

  addImage(id,data){
    return this.httpService.postImage('api/Note/'+id+'/Image',data)
  }

  addImageForCreateNote(data){
    return this.httpService.postImage('api/Note/Image',data)
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

  collaborate(data){
    return this.httpService.post('api/Note/Collaborate',data)
  }

  removeNoteLabel(labelId,noteId){
    return this.httpService.delete('api/Note/Note/'+noteId+'/Label/'+labelId);
  }

  deleteCollaborate(data){
    return this.httpService.delete('api/Note/Collaborate/'+data.CollaboratedWith+'/'+data.NoteId)
  }

}
