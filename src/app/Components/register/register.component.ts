import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { AdminService } from 'src/app/Service/admin/admin.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private router : Router,
    private formBuilder : FormBuilder,
    private snackbar : MatSnackBar,
    private adminService :AdminService
    ) { }

  registerForm: FormGroup;
  hide = true;

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      firstName: ['', [Validators.required,Validators.pattern('([a-zA-Z]{2,})$')]],
      lastName: ['', [Validators.required,Validators.pattern('([a-zA-Z]{2,})$')]],
      mobileNumber: ['', [Validators.required,Validators.pattern('([789][0-9]{9})$')]],
      userName: ['', [Validators.required,Validators.pattern('([a-zA-Z0-9]{2,})$')]],
      password: ['', [Validators.required,Validators.pattern('([a-zA-Z0-9]{4,8})$')]],
      confirmPassword: ['', Validators.required]
  },{validator: this.checkPasswords});
  }

  checkPasswords(group: FormGroup) { 
    let pass = group.get('password').value;
    let confirmPass = group.get('confirmPassword').value;
    return pass === confirmPass ? null : { notSame: true }     
  }

  dashboard(){
    this.router.navigate(['/dashboard'])
  }
  gotoLogin(){
    this.router.navigate(['/login'])
  }

  get f() { return this.registerForm.controls; }

  register(){

    let data={
      FirstName:this.registerForm.value.firstName,
      LastName:this.registerForm.value.lastName,
      MobileNumber:this.registerForm.value.mobileNumber,
      UserName:this.registerForm.value.userName,
      Password:this.registerForm.value.confirmPassword
    }

    this.adminService.register(data).subscribe(response=>{
      console.log('response in register',response);
      this.snackbar.open(response['message'],'',{duration:2000});
      this.router.navigate(['/login'])
    },error=>{
      console.log('error in register',error);
      this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000});
    })
  }

}
