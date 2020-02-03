import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/Service/admin/admin.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  hide = true;

  constructor(
    private formBuilder: FormBuilder,
    private snackbar : MatSnackBar,
    private router : Router,
    private adminService :AdminService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required,],
      password: ['', [Validators.required, Validators.pattern('([a-zA-Z0-9]{4,8})$')]],
  });
  }

  get f() { return this.loginForm.controls; }

  dashboard(){
    this.router.navigate(['/dashboard'])
  }

  login(){
    console.log('gggg,',this.loginForm.value);
    
    this.adminService.login(this.loginForm.value).subscribe(response=>{
      console.log('response in login',response);
      this.snackbar.open(response['message'],'',{duration:2000});
      localStorage.setItem('First Name',response['data']['firstName']);
      localStorage.setItem('Last Name',response['data']['lastName']);
      localStorage.setItem('token',response['data']['token']);  
      localStorage.setItem('login','true')
      this.router.navigate(['/dashboard']);   
    },error=>{
      console.log('error in login',error);
      this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000});
    })
  }

}
