import { Component, OnInit } from '@angular/core';
import { NoteService } from '../../Services/note.service';
import {DataServiceService} from '../../Services/DataService/data-service.service';

@Component({
  selector: 'app-trash',
  templateUrl: './trash.component.html',
  styleUrls: ['./trash.component.scss']
})
export class TrashComponent implements OnInit {

  constructor(
    private noteService : NoteService,
    private dataService : DataServiceService
  ) { }

  ngOnInit() {
    this.dataService.currentMessage.subscribe(response =>{
      if(response.type=='restore' || response.type=='delete'){
        this.getTrashed();
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
