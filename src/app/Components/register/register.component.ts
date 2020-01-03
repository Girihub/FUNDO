import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {UserService } from '../../Services/user.service'
import {Register} from '../../Model/register';
import {MatSnackBar} from '@angular/material/snack-bar'




@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  hide = true;
  
  
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private snackbar: MatSnackBar
   ) {}

   gotoLogin(){
     this.router.navigate(['/login']);
   }

   ngOnInit() {
    this.registerForm = this.formBuilder.group({
        firstName: ['', [Validators.required, Validators.pattern('^([a-zA-Z]{2,})$')]],
        lastName: ['', [Validators.required, Validators.pattern('^([a-zA-Z]{2,})$')]],
        mobileNumber: ['', [Validators.required, Validators.pattern(/^[7-9]\d{9}$/)]],
        email: ['', [Validators.required, Validators.pattern('([a-z0-9](.?[a-z0-9]){3,}@g(oogle)?mail.com)$')]],
        password: ['', [Validators.required, Validators.pattern('(?=.*[0-9])(?=.*[a-z])(?=.*_)(?=.*[A-Z]).{4,8}')]],
        confirmPassword: ['', Validators.required],
        serviceType: ['', [Validators.required, Validators.pattern('^([a-zA-Z]{5,7})$')]]

    },{validator: this.checkPasswords});

}

checkPasswords(group: FormGroup) { 
  let pass = group.get('password').value;
  let confirmPass = group.get('confirmPassword').value;
  return pass === confirmPass ? null : { notSame: true }     
}

get f() { return this.registerForm.controls; }

register(value){
  
  let newUser:Register={
    FirstName:this.registerForm.value.firstName,
    LastName:this.registerForm.value.lastName,
    MobileNumber:this.registerForm.value.mobileNumber,
    Email:this.registerForm.value.email,
    Password:this.registerForm.value.password,
    ServiceType:this.registerForm.value.serviceType,
    ProfilePicture:"ProfilePicture"
  }

  console.log('newUser', newUser);
  console.log('registration', this.registerForm.value);
        this.userService.register(newUser).subscribe(response=>{
            console.log('response after registration', response); 
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
