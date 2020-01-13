import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { DatePipe } from '@angular/common'
import { NoteService } from '../../Services/note.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'


@Component({
  selector: 'app-display-note',
  templateUrl: './display-note.component.html',
  styleUrls: ['./display-note.component.scss']
})
export class DisplayNoteComponent implements OnInit {
  showIcon:boolean;
  @Input() getChildMessage: any;
  @Input() isTrashed:boolean; 
  
  constructor(public datepipe: DatePipe,private noteService:NoteService,private dataOneService: DataOneService
  ) { 
    this.showIcon=false;
  }
  ngOnInit() { 

  }

  removeReminder(value){
    let data={
      id:value,
      Reminder:null
    }
    this.noteService.addReminder(data).subscribe(response=>{
      console.log(response);
      this.dataOneService.changeMessage({
        type:'removeReminder'
      })
    },error=>{
      console.log(error)
    })
  }
 
  pin(id){
    this.noteService.pin(id).subscribe(response=> {
      console.log('response',response);
      this.dataOneService.changeMessage({
        data:id,
        type:'pinUnpin'
      })
    },error=>{
      console.log('error',error)
    })
  }

}