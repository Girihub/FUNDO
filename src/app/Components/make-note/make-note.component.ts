import { Component, OnInit, Output, EventEmitter} from '@angular/core';
import { NoteService } from '../../Services/note.service';
import { CreateNote } from '../../Model/createNote';
import { Router } from '@angular/router';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-make-note',
  templateUrl: './make-note.component.html',
  styleUrls: ['./make-note.component.scss']
})

export class MakeNoteComponent implements OnInit {

  title='';
  description='';
  isOpen=true;
  color="#FFFFFF";
  Image='';
  isPin=false;
  Reminder=null;
  isArchive=false;
  @Output() addNoteEvent = new EventEmitter<any>();
  
  constructor(
    public datepipe: DatePipe,
    private dataOneService : DataOneService,
    private noteService:NoteService,
    private router : Router
  ) { }

  ngOnInit() {
    this.dataOneService.currentMessage.subscribe(response=>{
      if(response.type=='color'){
        this.color=response.data
      }
      if(response.type=='makeReminder'){
        this.Reminder=response.data;
      }
      if(response.type=='archive'){
        this.isArchive=!this.isArchive
      }
      if(response.type=='addImage'){
        this.Image=response.data
      }
    })
  }
 

   async createNote(){
    this.isOpen=true;

    if(this.title || this.description){

      let note : CreateNote = {
        Title:this.title,
        Description: this.description,
        Image:this.Image,
        Color:this.color,
        Reminder:this.Reminder,
        IsPin:this.isPin,
        IsNote:true,
        IsArchive:this.isArchive,
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
    this.title='';
    this.description='';
    this.color="#FFFFFF";
    this.isPin=false;   
    this.Reminder=null; 
    this.isArchive=false; 
    this.Image=''
  } 

  
}
