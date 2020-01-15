import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { NoteService } from '../../Services/note.service';
import { DatePipe } from '@angular/common';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service';
import {MatSnackBar} from '@angular/material/snack-bar';;

export interface DialogData {
  id: number;
  title: string;
  description:string,
  image:string,
  color:string,
  addReminder:any,
  isPin:boolean,  
  isNote:boolean,
  isArchive:boolean,
  isTrash:boolean
}

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss']
})
export class EditNoteComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<EditNoteComponent>,private noteService : NoteService,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,public datepipe:DatePipe, private dataOneService:DataOneService,
    private snackbar:MatSnackBar) { }

  ngOnInit() {
    this.dialogRef.updateSize('50%', 'auto');    
  }



  updateNote(){
    let updateData={
      Id:this.data.id,
      Title:this.data.title,
      Description:this.data.description,
      IsPin:this.data.isPin
    }
    this.noteService.updateNote(updateData).subscribe(response=>{
      console.log(response);
    },error=>{
      console.log(error)
    })
    this.dialogRef.close();
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
}
