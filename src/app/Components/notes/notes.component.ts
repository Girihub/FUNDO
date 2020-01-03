import { Component, OnInit } from '@angular/core';
import { NoteService } from '../../Services/note.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {

  constructor(
    private noteService : NoteService
  ) { }

  ngOnInit() {
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
    })
  }

}
