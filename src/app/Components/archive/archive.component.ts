import { Component, OnInit, } from '@angular/core';
import { NoteService } from './../../Services/note.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'

@Component({
  selector: 'app-archive',
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.scss']
})
export class ArchiveComponent implements OnInit {

  constructor(
    private noteService: NoteService,
    private dataOneService: DataOneService
  ) { }

  archived=[];
  ngOnInit() {
    this.dataOneService.currentMessage.subscribe(response =>{
      if(response.type=='unarchive'){
        //this.getAllArchived();
      }
    }) ;
    this.getAllArchived();
  }

  getAllArchived(){

    this.noteService.getArchived().subscribe(response =>{
      this.archived=response['data'];
      console.log(response);
    }
    ,error=>
    {
        console.log('error msg', error);  
        this.archived=[]; 
    })

  }

}
