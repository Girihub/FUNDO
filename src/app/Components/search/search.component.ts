import { Component, OnInit } from '@angular/core';
import{NoteService} from '../../Services/note.service';
import{DataServiceService} from '../../Services/DataService/data-service.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  constructor(private noteService: NoteService, private dataServive : DataServiceService) { }

  
  ngOnInit() {
    this.dataServive.currentMessage.subscribe(response =>{
      if(response.type='search'){
        var result = response.data;
        this.searchNotes(result);
      }
    })    
  }

  searched=[];
  searchNotes(val){
    this.noteService.searchNotes(val).subscribe(response =>{
      console.log(response);
      this.searched=response['data'];
      console.log(response)
    },error=>{
      console.log(error,'errror');
    })
  }

  
}
