import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { DatePipe } from '@angular/common'
import { NoteService } from '../../Services/note.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'
import {MatSnackBar} from '@angular/material/snack-bar';
import {MatDialog} from '@angular/material';
import {EditNoteComponent} from './../edit-note/edit-note.component';


@Component({
  selector: 'app-display-note',
  templateUrl: './display-note.component.html',
  styleUrls: ['./display-note.component.scss']
})
export class DisplayNoteComponent implements OnInit {
  showIcon:boolean;
  @Input() getChildMessage: any;
  @Input() isTrashed:boolean; 
  mainDivlayOut="row wrap";
  listView=false
  
  constructor(
    public dialog : MatDialog,
    public datepipe: DatePipe,
    private noteService:NoteService,
    private dataOneService: DataOneService,
    private snackbar: MatSnackBar
  ) { 
    this.showIcon=false;
  }
  ngOnInit() { 
    this.dataOneService.currentMessage.subscribe(response=>{
      if(response.type=='listView'){
        this.listView=true;
        this.mainDivlayOut="column wrap";
      }else{
        this.listView=false;
        this.mainDivlayOut="row wrap";
      }
    })
  }

  removeReminder(value){
    let data={
      id:value,
      Reminder:null
    }
    this.noteService.addReminder(data).subscribe(response=>{
      console.log(response);
      this.snackbar.open(response['message'],'',{duration:2000});
      this.dataOneService.changeMessage({
        type:'removeReminder'
      })
    },error=>{
      console.log(error)
      this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000}); 
    })
  }
 
  pin(id){
    this.noteService.pin(id).subscribe(response=> {
      console.log('response',response);
      this.snackbar.open(response['data'],'',{duration:2000});
      this.dataOneService.changeMessage({
        data:id,
        type:'pinUnpin'
      })
    },error=>{
      console.log('error',error)
      this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000}); 
    })
  }

  UpdateNote(note){
    this.dialog.open(EditNoteComponent,{      
      data:note,
    });
  }

}