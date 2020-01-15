import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import { NoteService } from 'src/app/Services/note.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import {UserService} from '../../Services/user.service'

export interface DialogData {
  noteId: number
}

@Component({
  selector: 'app-collaborator',
  templateUrl: './collaborator.component.html',
  styleUrls: ['./collaborator.component.scss']
})

export class CollaboratorComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<CollaboratorComponent>,private noteService : NoteService,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,private snackbar:MatSnackBar, private userService: UserService) { }

    myControl = new FormControl();
    allUsers=[];

    filteredUsers: Observable<string[]>;
  ownerId = localStorage.getItem('id');
  ownerName = localStorage.getItem('fullName');
  ownerEmail = localStorage.getItem('email');
  userId

  

  ngOnInit() {   
    this.getUsers()
  }

  usersList(){
    this.filteredUsers = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );
  }
  private _filter(value: any): any[] {
    // const filterValue = value.toLowerCase();
    const filterValue = value;
    return this.allUsers.filter(user => user['email'].toLowerCase().includes(filterValue));
  }
  getUsers(){
    this.userService.getUsers().subscribe(response=>{
      this.allUsers=response['data'];
      console.log('respone',this.allUsers);
    },error=>{
      console.log('error',error)
    })
  }

  cancel(){
    this.dialogRef.close();
  }

  collaborate(){
    console.log(this.userId)
    console.log(this.data)
    let Data = {
      CollaboratedWith:this.userId,
      NoteId:this.data
    }

    return this.noteService.collaborate(Data).subscribe(response=>{
      console.log('response',response);
      this.dialogRef.close();
    },error=>{
      console.log('error',error)
      this.dialogRef.close();
    })    
  }
  
  

}
