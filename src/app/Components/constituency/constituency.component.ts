import { Component, OnInit, ViewChild } from '@angular/core';
import {ConstituencyService} from '../../Service/Constituency/constituency.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialogRef } from '@angular/material'
import {MatSnackBar} from '@angular/material';
import {MatPaginator} from '@angular/material/paginator';

@Component({
  selector: 'app-constituency',
  templateUrl: './constituency.component.html',
  styleUrls: ['./constituency.component.scss']
})
export class ConstituencyComponent implements OnInit {

  constructor(
    private constituencyService:ConstituencyService,
    private dialogRef : MatDialogRef<ConstituencyComponent>,
    private snackBar : MatSnackBar
  ) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  data
  dataSource = new MatTableDataSource<any>(this.data);
  displayedColumns: string[] = ['id','name','state','action'];
  newConstituency;
  newState;
  ngOnInit() {
    this.getConstituencies();
  }

  close(){
    this.dialogRef.close();
  }
  getConstituencies(){
    this.constituencyService.getConstituency().subscribe(response=>{
      console.log('response in getConstituencies',response); 
      this.data = response['data']
      this.dataSource = new MatTableDataSource<any>(this.data);
      this.dataSource.paginator = this.paginator;     
    },error=>{
      console.log('error in getConstituencies',error);      
    })
  }

  addConstituency(){
    let data={
      Name:this.newConstituency,
      State:this.newState
    }
    this.constituencyService.addConstituency(data).subscribe(response=>{
      console.log('response in addConstituency',response);
      let newData={
        id:response['data']['id'],
        name:this.newConstituency,
        state:this.newState,
        createdDate:Date.UTC,
        modifiedDate:Date.UTC,
      }
      this.data.push(newData);
      this.dataSource = new MatTableDataSource<any>(this.data);
      this.dataSource.paginator = this.paginator;  
      this.newConstituency='';
      this.newState='';
      this.snackBar.open(response['message'],'',{duration:2000});
    },error=>{
      console.log('error in addConstituency',error);
      this.snackBar.open(error.error.message,'',{duration:2000})
    })
  }

  editConstituency(data){
    let editData={
      Name:data.name,
      State:data.state
    }
    this.constituencyService.updateConstituency(data.id,editData).subscribe(response=>{
      console.log('reponse in editConstituency',response);
      this.snackBar.open(response['message'],'',{duration:2000});
    },error=>{
      console.log('error in editConstituency',error);
      this.snackBar.open(error.error.message,'',{duration:2000});
    })  
  }

  deleteConstituency(data){
    this.constituencyService.deleteConstituency(data.id).subscribe(response=>{
      console.log('response in deleteConstituency',response);
      this.snackBar.open(response['message'],'',{duration:2000});
      this.data=this.data.filter(item=>item.id!==data.id);
      this.dataSource = new MatTableDataSource<any>(this.data); 
      this.dataSource.paginator = this.paginator;
    },error=>{
      console.log('error in deleteConstituency',error);
      this.snackBar.open(error.error.message,'',{duration:2000});
    })   
  }

}
