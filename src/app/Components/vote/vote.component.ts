import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {VoterService} from '../../Service/voter/voter.service'
import {MatSnackBar} from '@angular/material';
import {DataService} from '../../Service/data/data.service';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {

  constructor(private formBuilder : FormBuilder,
    private dialogRef:MatDialogRef<VoteComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private voterService : VoterService,
    private snackbar : MatSnackBar,
    private dataService : DataService
    ) { }

  voteForm : FormGroup;
  hide : true;

  ngOnInit() {   
    console.log('in dialog',this.data);     
    this.voteForm=this.formBuilder.group({
      firstName:['',[Validators.required,Validators.pattern('([a-zA-Z]{2,})$')]],
      lastName:['',[Validators.required,Validators.pattern('([a-zA-Z]{2,})$')]],
      mobileNumber: ['', [Validators.required,Validators.pattern('([789][0-9]{9})$')]],
      candidateId:['',Validators.required]
    })
  }  

  cancel(){
    this.dialogRef.close();
  }

  vote(){
    console.log('after voting',this.voteForm.value);
    this.voterService.vote(this.voteForm.value).subscribe(response=>{
      console.log('response after vote',response);
      this.snackbar.open(response['message'],'',{duration:2000});
      this.dataService.changeMessage({
        type:'vote'
      })  
      this.dialogRef.close();  
    },error=>{
      console.log('error after vote',error); 
      this.snackbar.open(error.error.message,'',{duration:2000});    
    })    
  }

}