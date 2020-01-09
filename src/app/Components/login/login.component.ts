import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {UserService } from '../../Services/user.service';
import {MatSnackBar} from '@angular/material/snack-bar';


@Component({
templateUrl: 'login.component.html',
selector:'app-login',
styleUrls:['./login.component.scss']})

export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    hide = true;
    
   

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private userService: UserService,
        private snackbar: MatSnackBar
       ) {}

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            email: ['', [Validators.required, Validators.pattern('([a-z0-9](.?[a-z0-9]){3,}@g(oogle)?mail.com)$')]],
            password: ['', [Validators.required, Validators.pattern('(?=.*[0-9])(?=.*[a-z])(?=.*_)(?=.*[A-Z]).{4,8}')]],
        });

      
    }

   
   // convenience getter for easy access to form fields
   get f() { return this.loginForm.controls; }

   login(value)
    {
        
        console.log('loginUs', this.loginForm.value);
        this.userService.login(this.loginForm.value).subscribe(response=>{
            console.log('response after loginnnnnn', response);
            this.snackbar.open(response['message'],'',{duration:2000});             
            localStorage.setItem('id', response['data']['id']);
            localStorage.setItem('firstName', response['data']['firstName']);
            localStorage.setItem('fullName', response['data']['firstName'] +" "+ response['data']['lastName']);
            localStorage.setItem('mobileNumber', response['data']['mobileNumber']);
            localStorage.setItem('email', response['data']['email']);
            localStorage.setItem('profilePicture', response['data']['profilePicture']);
            localStorage.setItem('serviceType', response['data']['serviceType']);
            localStorage.setItem('userType', response['data']['userType']);
            localStorage.setItem('token', response['token']);
            this.router.navigate(['/dashboard']);
        },
        error=>
        {
            console.log('error msg', error);
            this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000});    
        })
        
    }


}