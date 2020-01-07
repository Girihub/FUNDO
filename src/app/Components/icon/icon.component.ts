import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteService } from '../../Services/note.service';
import{DataServiceService} from '../../Services/DataService/data-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-icon',
  templateUrl: './icon.component.html',
  styleUrls: ['./icon.component.scss']
})
export class IconComponent implements OnInit {
  
  constructor(
    private noteService : NoteService,
    private router : Router,
    private dataService: DataServiceService
  ) { }

  @Input() isTrash:boolean;

  message:string;
  ngOnInit() {
  }
 


  @Input() noteIds
  @Output() addArchiveEvent = new EventEmitter<any>();   

  // isTrash=true;

  

  color(value){
    if(this.noteIds==null || this.noteIds==undefined){
      return value;
    }
    else{
      this.noteIds['color']=value;
    let data={
      id:this.noteIds.id,
      color:value
    }

    this.noteService.changeColor(data).subscribe(response =>{
      console.log('response', response);
    },
    error=>
    {
        console.log('error msg', error);   
    })
    }    
  } 

  archive(){
    this.noteService.archive(this.noteIds.id).subscribe(response =>{
      console.log('response', response);
      if(!this.noteIds.isArchive){        
        this.dataService.changeMessage({
          type:'archive'      
       })
      }else{
        this.dataService.changeMessage({
          type:'unarchive'      
       })
      }
    },
    error=>{
      console.log('error msg', error); 
    })    
  }

  trash(){
    this.noteService.trash(this.noteIds.id).subscribe(response =>{
      console.log('response', response);
      if(!this.noteIds.isTrash){        
        this.dataService.changeMessage({
          type:'trash'      
       })
      }else{
        this.dataService.changeMessage({
          type:'restore'      
       })
      }
    },
    error=>{
      console.log('error msg', error); 
    })
  }

  addImage(event){
    console.log(event.target.files[0].name);
    this.noteIds['image']=event.target.files[0].name;
  }  

  deleteNote(){
    this.noteService.deleteNote(this.noteIds.id).subscribe(response =>{
      console.log('response', response);
      this.dataService.changeMessage({
        type:'delete'      
     })
    },
    error=>{
      console.log('error msg', error); 
    })
  }

  
}
