import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {DataService} from '../../Service/data/data.service'
import {MatDialog} from '@angular/material';
import {VoteComponent} from '../vote/vote.component'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private router:Router, private dataService : DataService,
    private dialog:MatDialog
    ) { }

  adminLogin = localStorage.getItem('login')
  ngOnInit() {
    console.log('admin',this.adminLogin);    
  }

  login(){
    this.router.navigate(['/login']);
  }

  logout(){
    localStorage.clear();
    localStorage.setItem('login','false');
    this.adminLogin='false';
  }

  vote(){
    this.dialog.open(VoteComponent,{
      panelClass: 'myapp-no-padding-dialog',
      width: '550px', 
    })
  }

  consti=true;
  party=false;
  candidate=false;

  partywise(){
    this.consti=false;
    this.party=true;
    this.candidate=false;
  }

  constituencywise(){
    this.consti=true;
    this.party=false;
    this.candidate=false;
  }

  candidateswise(){
    this.consti=false;
    this.party=false;
    this.candidate=true;
  }
}
