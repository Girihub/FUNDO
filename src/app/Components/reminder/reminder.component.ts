import { Component, OnInit } from '@angular/core';
import { NoteService } from '../../Services/note.service';

@Component({
  selector: 'app-reminder',
  templateUrl: './reminder.component.html',
  styleUrls: ['./reminder.component.scss']
})
export class ReminderComponent implements OnInit {

  constructor(private noteService : NoteService) { }

  ngOnInit() {
  }

  Remindered=[];

  getRemindered(){
    this.noteService.getRemindered().subscribe(response=>{
      
    })
  }

}
