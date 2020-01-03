import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, RouterStateSnapshot  } from '@angular/router';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup, FormBuilder } from '@angular/forms';
import {UserService } from '../../Services/user.service';
import { validateBasis } from '@angular/flex-layout';
import {Reset} from '../../Model/reset';
import {MatSnackBar} from '@angular/material/snack-bar';


@Component({
  selector: 'app-reset',
  templateUrl: './reset.component.html',
  styleUrls: ['./reset.component.scss']
})
export class ResetComponent implements OnInit {

  resetForm: FormGroup;
  hide = true;
  notSame: true;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private snackbar: MatSnackBar
  ) { 
    
  }

  ngOnInit() {
    this.resetForm = this.formBuilder.group({
      password: ['', [Validators.required, Validators.pattern('(?=.*[0-9])(?=.*[a-z])(?=.*_)(?=.*[A-Z]).{4,8}')]],
      confirmPassword: ['', [Validators.required,]]
    }, {validator: this.checkPasswords});
  }

  

  checkPasswords(group: FormGroup) { 
  let pass = group.get('password').value;
  let confirmPass = group.get('confirmPassword').value;
  return pass === confirmPass ? null : { notSame: true }     
}

  get f() { return this.resetForm.controls; }

  
  
  reset(value){
    const token = this.route.snapshot.paramMap.get('token');

    let resetPassword: Reset={
      Token:token,
      NewPassword:this.resetForm.value.password
    }

        this.userService.reset(resetPassword).subscribe(response=>{
            console.log('response after forget password', response); 
            this.snackbar.open(response['message'],'',{duration:2000});
            this.router.navigate(['/login']);
        },
        error=>
        {
            console.log('error msg', error); 
            this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000});   
        })
  }  
}
