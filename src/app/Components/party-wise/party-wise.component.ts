import { Component, OnInit } from '@angular/core';
import {DataService} from '../../Service/data/data.service'
import { Router } from '@angular/router';
import {VoterService} from '../../Service/voter/voter.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import {MatTableDataSource} from '@angular/material/table';

export interface element {  
  partyName:any,  
  votes:any,
}

@Component({
  selector: 'app-party-wise',
  templateUrl: './party-wise.component.html',
  styleUrls: ['./party-wise.component.scss']
})
export class PartyWiseComponent implements OnInit {

  constructor(private dataService : DataService,
    private router : Router,private voterService : VoterService
    ) { }

  selected="All"
  displayedColumns: string[] = ['partyName','votes'];
  states
  data
  dataSource = new MatTableDataSource<element>(this.data);
  newStates=[]
  ngOnInit() {
    this.dataService.currentMessage.subscribe(response=>{
      if(response.type=='allData'){
        this.states=response.data;
        for(let i=0;i<this.states.length;i++){
          this.newStates.push(response.data[i]['state'])
        }
        this.newStates=[...new Set(this.newStates)]   
        this.newStates.push("All");
      }      
    })     
    this.getData('All'); 
  }

  getData(state){   
    this.voterService.getPartyWiseResult(state).subscribe(response=>{
      console.log('response in partywiseresult',response); 
      this.data=response['data'];
      this.dataSource = new MatTableDataSource<element>(this.data);   
    },error=>{
      console.log('error in partywiseresult',error);      
    })
  }

}
