import { Component, OnInit } from '@angular/core';
import {DataService} from '../../Service/data/data.service';
import {MatTableDataSource} from '@angular/material/table';

export interface element {  
  candidateName:any,
  partyName:any,  
  constituencyName:any,
  state:any,
  votes:any,
}

@Component({
  selector: 'app-all-candidate',
  templateUrl: './all-candidate.component.html',
  styleUrls: ['./all-candidate.component.scss']
})
export class AllCandidateComponent implements OnInit {

  constructor(private dataService:DataService) { }
  displayedColumns: string[] = ['candidateName','partyName','constituencyName','state','votes'];

  data
  dataSource = new MatTableDataSource<element>(this.data);
  ngOnInit() {
    this.dataService.currentMessage.subscribe(response=>{
      if(response.type='allData'){
        this.data=response.data;
        this.dataSource = new MatTableDataSource<element>(this.data);
      }
    })
  }

}
