import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {

  constructor(private formBuilder : FormBuilder) { }

  voteForm : FormGroup;
  hide : true;

  ngOnInit() {
    this.voteForm=this.formBuilder.group({
      firstName:['',[Validators.required,Validators.pattern('([a-zA-Z]{2,})$')]],
      lastName:['',[Validators.required,Validators.pattern('([a-zA-Z]{2,})$')]],
      mobileNumber: ['', [Validators.required,Validators.pattern('([789][0-9]{9})$')]],
      candidateId:['',Validators.required]
    })
  }

}
