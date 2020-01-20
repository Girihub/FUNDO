import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA, MatSnackBar} from '@angular/material';
import { NoteService } from 'src/app/Services/note.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import {UserService} from '../../Services/user.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'

@Component({
  selector: 'app-collaborator',
  templateUrl: './collaborator.component.html',
  styleUrls: ['./collaborator.component.scss']
})

export class CollaboratorComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<CollaboratorComponent>,private noteService : NoteService,
    @Inject(MAT_DIALOG_DATA) public data: any,private snackbar:MatSnackBar, private userService: UserService,
    private dataOneService : DataOneService) { }

    myControl = new FormControl();
    allUsers=[];

    filteredUsers: Observable<string[]>;
  ownerId = localStorage.getItem('id');
  ownerName = localStorage.getItem('fullName');
  ownerEmail = localStorage.getItem('email');
  ownerImage = localStorage.getItem('profilePicture');
  userId
  collaborated=this.data.dataKey.collaborateResponses;


  

  ngOnInit() {   
    this.dialogRef.updateSize('40%', '50%');
    console.log('whole data',this.collaborated)
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
    console.log('in colab',this.data.NoteId)
    let Data = {
      CollaboratedWith:this.userId,
      NoteId:this.data.dataKey.id
    }
    return this.noteService.collaborate(Data).subscribe(response=>{
      console.log('response in add colaborator',response);
      this.collaborated.Add(Data)
      this.dataOneService.changeMessage({
        type:'colaboratorAdded'
      })
    },error=>{
      console.log('error in add colaborator',error)
    })    
  }
  
  deleteColab(userid){
    let data={
      CollaboratedWith:userid,
      NoteId:this.data.dataKey.id
    }
    console.log('wrgrwgwrg',data)
    return this.noteService.deleteCollaborate(data).subscribe(response=>{
      console.log('response in delete colaborator', response);
      this.dataOneService.changeMessage({
        type:'colaboratorDeleted'
      })
    },error=>{
      console.log('error in delete colaborator',error)
    })
  }

}
