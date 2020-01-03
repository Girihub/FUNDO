import { Component, OnInit, } from '@angular/core';
import { NoteService } from './../../Services/note.service';

@Component({
  selector: 'app-archive',
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.scss']
})
export class ArchiveComponent implements OnInit {

  constructor(
    private noteService: NoteService
  ) { }

  archived=[];
  ngOnInit() {
    this.getAllTrashed();
  }

  getAllTrashed(){

    this.noteService.getArchived().subscribe(response =>{
      this.archived=response['data'];
      console.log(response);
    }
    ,error=>
    {
        console.log('error msg', error);   
    })

  }

}
