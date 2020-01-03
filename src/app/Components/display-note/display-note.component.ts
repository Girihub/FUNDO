import { Component, OnInit } from '@angular/core';
import { NoteService } from '../../Services/note.service'

@Component({
  selector: 'app-display-note',
  templateUrl: './display-note.component.html',
  styleUrls: ['./display-note.component.scss']
})
export class DisplayNoteComponent implements OnInit {

  constructor(
    private noteService : NoteService
  ) { }

  ngOnInit() {
    this.getNotes();
  }

  notes={};


  getNotes(){

    this.noteService.getNotes().subscribe(response =>{
      console.log('Response', response);
      this.notes=response['data'];
      console.log("notes ",this.notes);
    },error=>
    {
        console.log('error msg', error);   
    })
  }

}
