import { Component, OnInit, ElementRef, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../../Service/data/data.service'
import { MatDialog } from '@angular/material';
import { VoteComponent } from '../vote/vote.component';
import { VoterService } from '../../Service/voter/voter.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { VotersComponent } from '../../Components/voters/voters.component';
import {CandidateComponent} from '../../Components/candidate/candidate.component';
import { ConstituencyComponent } from '../constituency/constituency.component';
import { PartyComponent } from '../party/party.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private router: Router, private dataService: DataService,
    private dialog: MatDialog, private voterService: VoterService, private snackbar: MatSnackBar
  ) { }

  adminLogin = localStorage.getItem('token')
  flex;

  data
  ngOnInit() {
    if (this.adminLogin != null) {
      this.flex = 'space-between center';
    } else if (this.adminLogin == null) {
      this.flex = 'end center';
    }
    this.dataService.currentMessage.subscribe(response => {
      if (response.type == 'allData') {
        this.data = response.data;
      }
    })
  }

  login() {
    this.router.navigate(['/login']);
  }

  logout() {
    localStorage.clear();
    localStorage.setItem('login', 'false');
    this.adminLogin = null;
    this.flex = 'end center';
  }

  vote() {
    this.dialog.open(VoteComponent, {
      panelClass: 'myapp-no-padding-dialog',
      width: '550px',
      data: this.data
    })
  }

  consti = true;
  party = false;
  candidate = false;

  partywise() {
    this.consti = false;
    this.party = true;
    this.candidate = false;
  }

  constituencywise() {
    this.consti = true;
    this.party = false;
    this.candidate = false;
  }

  candidateswise() {
    this.consti = false;
    this.party = false;
    this.candidate = true;
  }

  reElection() {
    this.voterService.reElection().subscribe(response => {
      console.log('response in re-election', response);
      this.snackbar.open(response['message'], '', { duration: 2000 });
    }, error => {
      console.log('error in re-election', error);
      this.snackbar.open(error.error.message, '', { duration: 2000 });
    })
  }

  allVoters() {
    this.voterService.allVoters().subscribe(response => {
      console.log('response in allVoters', response);
      this.snackbar.open(response['message'], '', { duration: 2000 });
      this.dialog.open(VotersComponent, {
        panelClass: 'myapp-no-padding-dialog',
        data: response['data']
      })
    }, error => {
      console.log('error in allVoters', error);
      this.snackbar.open(error.error.message, '', { duration: 2000 });
    })
  }

  openCandidate(){
    this.dialog.open(CandidateComponent,{
      panelClass: 'myapp-no-padding-dialog',
    })
  }

  openConstituency(){
    this.dialog.open(ConstituencyComponent,{
      panelClass: 'myapp-no-padding-dialog',
    })
  }

  openParty(){
    this.dialog.open(PartyComponent,{
      panelClass: 'myapp-no-padding-dialog',
    })
  }
}
