import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {VoterService} from '../../Service/voter/voter.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import {MatTableDataSource} from '@angular/material/table';
import {DataService} from '../../Service/data/data.service'

export interface element {  
  candidateName:any,
  partyName:any,  
  constituencyName:any,
  state:any,
  votes:any,
}
@Component({
  selector: 'app-constituency-wise',
  templateUrl: './constituency-wise.component.html',
  styleUrls: ['./constituency-wise.component.scss']
})
export class ConstituencyWiseComponent implements OnInit {

  constructor(private router:Router, private voterService:VoterService, private snackbar:MatSnackBar,
    private dataService : DataService
    ) { }
  displayedColumns: string[] = ['candidateName','partyName','constituencyName','state','votes'];
  
   
  allResult
  showData
  states=[]
  newStates
  constituencies=[]
  dataSource = new MatTableDataSource<element>(this.showData);
  ngOnInit() {
    this.getAllResult(); 
    this.dataService.currentMessage.subscribe(response=>{
      if(response.type=='vote'){
        this.getAllResult();
      }
    })   
  } 

  getAllResult(){
    this.voterService.getAllResult().subscribe(response=>{
      console.log('response in getAllResult',response); 
      this.allResult = response['data'];  
      this.showData = response['data']; 

      for(let i=0;i<this.allResult.length;i++){
        this.states.push(response['data'][i]['state'])
      }
      this.newStates=[...new Set(this.states)] 
      
      this.dataService.changeMessage({
        type:'allData',
        data:this.allResult
      }) 
      this.dataSource = new MatTableDataSource<element>(this.showData);  
    },error=>{
      console.log('error in getAllResult',error);      
    })      
  }

  getconstituencies(state){
    this.constituencies=[]
    for(let i=0;i<this.allResult.length;i++){
      if(this.allResult[i]['state']==state){
        this.constituencies.push(this.allResult[i]['constituencyName'])
      }      
    }
    this.constituencies=[...new Set(this.constituencies)] 
  }

  getConstituencyResult(constituency){
    this.showData=[];
    for(let i=0;i<this.allResult.length;i++){
      if(this.allResult[i]['constituencyName']==constituency){
        this.showData.push(this.allResult[i])
      }      
    }
    this.dataSource = new MatTableDataSource<element>(this.showData);    
  }

}
