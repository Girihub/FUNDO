import { Component, OnInit } from '@angular/core';
import { NoteService } from '../../Services/note.service';
import { CreateNote } from '../../Model/createNote';

@Component({
  selector: 'app-make-note',
  templateUrl: './make-note.component.html',
  styleUrls: ['./make-note.component.scss']
})
export class MakeNoteComponent implements OnInit {

  title='';
  description='';


  isOpen=true;

  constructor(
    private noteService:NoteService
  ) { }

  ngOnInit() {
  }

  createNote(){
    this.isOpen=true;

    let note : CreateNote = {
      Title:this.title,
      Description: this.description,
      Image:"test",
      Color:"#000000",
      IsPin:false,
      IsNote:true,
      IsArchive:false,
      IsTrash:false
    }

    this.noteService.createNote(note).subscribe(response =>{
      console.log('Response', response);
    },error=>
    {
        console.log('error msg', error);   
    })

  }
}
