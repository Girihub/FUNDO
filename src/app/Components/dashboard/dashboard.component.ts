import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AdminService } from './../../Service/admin/admin.service'
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

export interface elements {
  id:any,
  firstName:any,
  lastName:any,
  mobileNumber:any,
  email:any,
  serviceType:any,
  userType:any
}

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private router: Router, private snackbar: MatSnackBar, private adminService: AdminService) { }

  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'mobileNumber', 'email', 'serviceType', 'userType'];
  basicCount;
  advanceCount;
  serviceCount
  userData;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  dataSource = new MatTableDataSource<elements>(this.userData);  

  ngOnInit() {
    this.usersList();    
  }

  logout() {
    localStorage.clear();
    this.snackbar.open("Logged out successfully", '', { duration: 2000 });
    this.router.navigate(['/login']);
  } 

  usersList() {
    this.adminService.usersList().subscribe(response => {
      console.log('response in usersList', response);
      this.userData = response['data'];
      this.basicCount = this.userData.filter((i) => i.serviceType === 'Basic').length;
      this.advanceCount = this.userData.filter((i) => i.serviceType === 'Advance').length;
      this.dataSource = new MatTableDataSource<elements>(this.userData); 
      this.dataSource.paginator = this.paginator;     
    }, error => {
      console.log('error in usersList', error);
    })
  }

  search(event) {
    if(event.target.value==''){
      this.basicCount = this.userData.filter((i) => i.serviceType === 'Basic').length;
      this.advanceCount = this.userData.filter((i) => i.serviceType === 'Advance').length;
      this.dataSource = new MatTableDataSource<elements>(this.userData); 
      this.dataSource.paginator = this.paginator;  
    }else{
      this.dataSource = this.userData.filter(function (data) {
        return JSON.stringify(data.firstName).toLowerCase().indexOf(event.target.value.toLowerCase()) !== -1
          || JSON.stringify(data.lastName).toLowerCase().indexOf(event.target.value.toLowerCase()) !== -1;
      })
      this.serviceCount=this.dataSource
      this.basicCount = this.serviceCount.filter((i) => i.serviceType === 'Basic').length;
      this.advanceCount = this.serviceCount.filter((i) => i.serviceType === 'Advance').length;
    }
  }  

}