import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {UserService } from '../../Services/user.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-forget',
  templateUrl: './forget.component.html',
  styleUrls: ['./forget.component.scss']
})
export class ForgetComponent implements OnInit {

  forgetForm: FormGroup;
  hide = true;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private snackbar: MatSnackBar
  ) { }

  gotoLogin(){
    this.router.navigate(['/login']);
  }

  ngOnInit() {
    this.forgetForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.pattern('([a-z0-9](.?[a-z0-9]){3,}@g(oogle)?mail.com)$')]]
  });
  }

  get f() { return this.forgetForm.controls; }

  forget(value){
    console.log('Email', this.forgetForm.value);
        this.userService.forget(this.forgetForm.value).subscribe(response=>{
            console.log('response after forget password', response);
            this.snackbar.open(response['message'],'',{duration:2000});
        },
        error=>
        {
            console.log('error msg', error); 
            this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000});  
        })
  }
}
