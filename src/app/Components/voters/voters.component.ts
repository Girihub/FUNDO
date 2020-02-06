import { Component, OnInit, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {MatTableDataSource} from '@angular/material/table';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-voters',
  templateUrl: './voters.component.html',
  styleUrls: ['./voters.component.scss']
})
export class VotersComponent implements OnInit {

  constructor(
    public dialogRef : MatDialogRef<VotersComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any,
    public datepipe : DatePipe
  ) { }

  dataSource = new MatTableDataSource<any>(this.data);
  displayedColumns: string[] = ['name','mobileNumber','candidateName','date'];
  ngOnInit() {
    console.log('in voters', this.data);    
  }

  close(){
    this.dialogRef.close();
  }
}
