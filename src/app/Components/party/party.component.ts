import { Component, OnInit, ViewChild } from '@angular/core';
import { PartyService } from '../../Service/Party/party.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialogRef } from '@angular/material'
import {MatSnackBar} from '@angular/material';
import {MatPaginator} from '@angular/material/paginator';

@Component({
  selector: 'app-party',
  templateUrl: './party.component.html',
  styleUrls: ['./party.component.scss']
})
export class PartyComponent implements OnInit {

  constructor(
    private partyService: PartyService,
    private dialogRef: MatDialogRef<PartyComponent>,
    private snackBar:MatSnackBar
  ) { }
  
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  data
  dataSource = new MatTableDataSource<any>(this.data);
  displayedColumns: string[] = ['id', 'partyName', 'action'];
  newParty
  ngOnInit() {
    this.getParties();
  }

  close() {
    this.dialogRef.close()
  }

  getParties() {
    this.partyService.getParty().subscribe(response => {
      console.log('response in getParties', response)
      this.data = response['data']
      this.dataSource = new MatTableDataSource<any>(this.data);
      this.dataSource.paginator = this.paginator;
    }, error => {
      console.log('error in getParties', error);
    })
  }

  addParty(data){
    let addParty={
      PartyName:data
    }
    this.partyService.addParty(addParty).subscribe(response=>{
      console.log('response in addParty',response);
      this.snackBar.open(response['message'],'',{duration:2000})
      let addData={
        id:response['data']['id'],
        partyName:response['data']['partyName'],
        createdDate:Date.UTC,
        modifiedDate:Date.UTC
      }
      this.data.push(addData);
      this.dataSource = new MatTableDataSource<any>(this.data);
      this.dataSource.paginator = this.paginator;
      this.newParty='';
    },error=>{
      console.log('error in addParty',error);
      this.snackBar.open(error.error.message,'',{duration:2000})
    })
  }

  editParty(data){    
    let editData={
      PartyName:data.partyName
    }
    let id=data.partyId;
    this.partyService.updateParty(data.id,editData).subscribe(response=>{
      console.log('response in editParty',response);
      this.snackBar.open(response['message'],'',{duration:2000})      
    },error=>{
      console.log('error in editParty',error); 
      this.snackBar.open(error.error.message,'',{duration:2000})      
    })    
  }

  deleteParty(data){
    this.partyService.deleteParty(data.id).subscribe(response=>{
      console.log('response in deleteParty',response);
      this.snackBar.open(response['message'],'',{duration:2000});
      this.data=this.data.filter(item=>item.id!==data.id);
      this.dataSource = new MatTableDataSource<any>(this.data); 
      this.dataSource.paginator = this.paginator;     
    },error=>{
      console.log('error in deleteParty',error);
      this.snackBar.open(error.error.message,'',{duration:2000})
    })
  }

}
