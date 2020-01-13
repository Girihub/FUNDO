import { Component, OnInit } from '@angular/core';
import{NoteService} from '../../Services/note.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'

@Component({
  selector: 'app-reminder',
  templateUrl: './reminder.component.html',
  styleUrls: ['./reminder.component.scss']
})
export class ReminderComponent implements OnInit {

  constructor(private noteService : NoteService, private dataOneService : DataOneService) { }

  ngOnInit() {
    this.dataOneService.currentMessage.subscribe(response =>{
      if(response.type=='removeReminder'){
        //this.getRemindered();
        return        
      }
    })
    this.getRemindered();
  }

  reminderedNotes=[];

  getRemindered(){
    this.noteService.getRemindered().subscribe(response =>{
      console.log(response);
      this.reminderedNotes=response['data'];
      console.log(response)
    },error=>{
      console.log(error,'errror');
      this.reminderedNotes=[];
    })
  }

}
