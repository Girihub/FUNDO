import { Component, OnInit, ViewChild } from '@angular/core';
import { CandidateService } from '../../Service/Candidate/candidate.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialogRef } from '@angular/material'
import { MatSnackBar } from '@angular/material';
import { MatPaginator } from '@angular/material/paginator';
import { ConstituencyService } from '../../Service/Constituency/constituency.service';
import { PartyService } from '../../Service/Party/party.service';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss']
})
export class CandidateComponent implements OnInit {

  constructor(
    private candiateService: CandidateService,
    private snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<CandidateComponent>,
    private constituencyService: ConstituencyService,
    private partyService: PartyService
  ) { }

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  data
  parties
  constituencies
  dataSource = new MatTableDataSource<any>(this.data);
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'partyName', 'constituencyName', 'votes', 'action'];
  newFirstName
  newLastName
  newParty
  newConstituency
  selectParty = "Party";
  ngOnInit() {
    this.getParties();
    this.getConstituencies();
    this.getCandidates();
  }

  close() {
    this.dialogRef.close();
  }

  getParties() {
    this.partyService.getParty().subscribe(response => {
      console.log('response for getParties in CandidateComponent', response);
      this.parties = response['data'];
    }, error => {
      console.log('error for getParties in CandidateComponent', error);
    })
  }

  getConstituencies() {
    this.constituencyService.getConstituency().subscribe(response => {
      console.log('response for getConstituencies in CandidateComponent', response);
      this.constituencies = response['data'];
    }, error => {
      console.log('error for getConstituencies in CandidateComponent', error);
    })
  }

  getCandidates() {
    this.candiateService.getCandidates().subscribe(response => {
      console.log('response in getCandidates', response);
      this.data = response['data']
      this.dataSource = new MatTableDataSource<any>(this.data);
      this.dataSource.paginator = this.paginator;
    }, error => {
      console.log('error in getCandidates', error);
    })
  }

  editCandidate(data) {
    let editData = {
      FirstName: data.firstName,
      LastName: data.lastName,
      PartyId: data.partyId,
      ConstituencyId: data.constituencyId
    }
    this.candiateService.updateCandidate(data.id, editData).subscribe(response => {
      console.log('response in editCandidate', response);
      this.snackBar.open(response['message'], '', { duration: 2000 })
    }, error => {
      console.log('error in editCandidate', error);
      this.snackBar.open(error.error.message, '', { duration: 2000 });
    })
  }

  deleteCandidate(data) {
    this.candiateService.deleteCandidate(data.id).subscribe(response => {
      console.log('reponse in deleteCandidate', response);
      this.snackBar.open(response['message'], '', { duration: 2000 });
      this.data = this.data.filter(item => item.id !== data.id);
      this.dataSource = new MatTableDataSource<any>(this.data);
      this.dataSource.paginator = this.paginator;
    }, error => {
      console.log('error in deleteCandidate', error);
      this.snackBar.open(error.error.message, '', { duration: 2000 });
    })
  }

  addCandidate(value) {
    let data = {
      FirstName: this.newFirstName,
      LastName: this.newLastName,
      PartyId: this.newParty.id,
      ConstituencyId: this.newConstituency.id
    }
    this.candiateService.addCandidate(data).subscribe(response => {
      console.log('response in addCandidate', response);
      this.snackBar.open(response['message'], '', { duration: 2000 });
      let newData = {
        id: response['data']['id'],
        firstName: this.newFirstName,
        lastName: this.newLastName,
        partyId: this.newParty.id,
        partyName: this.newParty.partyName,
        constituencyId: this.newConstituency.id,
        constituencyName: this.newConstituency.name,
        votes: 0
      }
      this.data.push(newData);
      this.dataSource = new MatTableDataSource<any>(this.data);
      this.dataSource.paginator = this.paginator;
      this.newFirstName=''
      this.newLastName=''
      this.newParty=''
      this.newConstituency=''
    }, error => {
      console.log('error in addCandidate', error);
      this.snackBar.open(error.error.message, '', { duration: 2000 });
    })
  }

}
