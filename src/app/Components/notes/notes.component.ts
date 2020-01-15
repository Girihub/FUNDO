import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NoteService } from '../../Services/note.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss'],
})
export class NotesComponent implements OnInit {

  constructor(
    private noteService : NoteService,
    private dataOneService: DataOneService
  ) { }

  message:string;

  ngOnInit() {
    this.getNotes() 
    console.log('allnotes',this.notes)
    this.dataOneService.currentMessage.subscribe(response =>{
      if(response.type=='archive' || response.type=='trash' || response.type=='addReminder' || response.type =='pinUnpin'){        
        this.getNotes();
      }
    });    
  }

  pinnedNotes=[];
  unpinnedNotes=[];
  notes=[];
 
  separateNotes(){
    this.pinnedNotes=[];
    this.unpinnedNotes=[];
    for (let i = 0; i < this.notes.length; i++) {
      if(this.notes[i].isPin == true){
        this.pinnedNotes.push(this.notes[i]);
      }else{
        this.unpinnedNotes.push(this.notes[i]);
      }
    }
  }

  getNotes(){

    this.noteService.getNotes().subscribe(response =>{
      console.log('Response', response);      
      this.notes=response['data'];
      this.separateNotes();
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
