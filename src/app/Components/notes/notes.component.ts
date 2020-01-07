import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NoteService } from '../../Services/note.service';
import{DataServiceService} from '../../Services/DataService/data-service.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss'],
})
export class NotesComponent implements OnInit {

  constructor(
    private noteService : NoteService,
    private router : Router,
    private dataService : DataServiceService
  ) { }

  message:string;

  ngOnInit() {

    this.dataService.currentMessage.subscribe(response =>{
      if(response.type=='archive' || response.type=='trash'){
        this.getNotes();
      }
    }) ;
    this.getNotes();
  }

  notes=[];

  getNotes(){

    this.noteService.getNotes().subscribe(response =>{
      console.log('Response', response);
      this.notes=response['data'];
    },error=>
    {
        console.log('error msg', error); 
        this.notes=[]  
    })
  }
  async addNoteEvent(event){
    console.log("event from add note component",event);
    if(event.type=='addNote'){
      this.getNotes();
    }    
  }  




}
