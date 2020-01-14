import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { NoteService } from '../../Services/note.service';
import { DatePipe } from '@angular/common'

export interface DialogData {
  id: number;
  title: string;
  description:string,
  image:string,
  color:string,
  addReminder:Date,
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
    @Inject(MAT_DIALOG_DATA) public data: DialogData,public datepipe:DatePipe) { }

  ngOnInit() {
    this.dialogRef.updateSize('50%', 'auto');
  }



  updateNote(){
    let updateData={
      Id:this.data.id,
      Title:this.data.title,
      Description:this.data.description,
    }
    this.noteService.updateNote(updateData).subscribe(response=>{
      console.log(response);
    },error=>{
      console.log(error)
    })
    this.dialogRef.close();
  }

  pin(id){

  }

  removeReminder(id){

  }
}
