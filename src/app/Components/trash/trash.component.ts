import { Component, OnInit } from '@angular/core';
import { NoteService } from '../../Services/note.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'

@Component({
  selector: 'app-trash',
  templateUrl: './trash.component.html',
  styleUrls: ['./trash.component.scss']
})
export class TrashComponent implements OnInit {

  constructor(
    private noteService : NoteService,
    private dataOneService: DataOneService
  ) { }

  ngOnInit() {
    this.dataOneService.currentMessage.subscribe(response =>{
      if(response.type=='restore' || response.type=='delete'){
        //this.getTrashed();
        return
      }
    }) ;
    this.getTrashed();
  }

  trashed=[];

  getTrashed(){

    this.noteService.getTrashed().subscribe(response =>{
      this.trashed=response['data'];
      console.log(response);
    },
    error=>{
      console.log('error', error);
      this.trashed=[];
    })
  }

}
