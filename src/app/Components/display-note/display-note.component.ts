import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { DatePipe } from '@angular/common'
import { NoteService } from '../../Services/note.service';


@Component({
  selector: 'app-display-note',
  templateUrl: './display-note.component.html',
  styleUrls: ['./display-note.component.scss']
})
export class DisplayNoteComponent implements OnInit {
  showIcon:boolean;
  @Input() getChildMessage: any;
  @Input() isTrashed:boolean;  
  
  constructor(public datepipe: DatePipe,private noteService:NoteService
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
    },error=>{
      console.log(error)
    })
  }


}