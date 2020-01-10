import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { NoteService } from '../../Services/note.service';
import { CreateNote } from '../../Model/createNote';
import { Router } from '@angular/router';
import { NotesComponent } from '../notes/notes.component';

@Component({
  selector: 'app-make-note',
  templateUrl: './make-note.component.html',
  styleUrls: ['./make-note.component.scss']
})
export class MakeNoteComponent implements OnInit {

  title='';
  description='';
  isOpen=true;
  @Output() addNoteEvent = new EventEmitter<any>();
  
  constructor(
    private noteService:NoteService,
    private router : Router
  ) { }

  ngOnInit() {
  }
  
   async createNote(){
    this.isOpen=true;

    if(this.title || this.description){

      let note : CreateNote = {
        Title:this.title,
        Description: this.description,
        Image:"",
        Color:"#FFFFFF",
        Reminder:null,
        IsPin:false,
        IsNote:true,
        IsArchive:false,
        IsTrash:false
      }
  
      this.noteService.createNote(note).subscribe(response =>{
        console.log('Response', response);    
      this.addNoteEvent.emit({
        type:'addNote'
      }) 
      },error=>
      {
          console.log('error msg', error);   
      })
    }         
  } 

  
}
