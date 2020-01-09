import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteService } from '../../Services/note.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'

@Component({
  selector: 'app-icon',
  templateUrl: './icon.component.html',
  styleUrls: ['./icon.component.scss']
})
export class IconComponent implements OnInit {
  
  constructor(
    private noteService : NoteService,
    private dataOneService: DataOneService
  ) { }

  @Input() isTrash:boolean;

  message:string;
  ngOnInit() {
  }
 

  colors=['#FFFFFF','#FBAD44','#FCE97C','#66ffe0','#9BF9C1','#AEF9F8','#AEBEFB',
            '#F9B1DB','#E9D1D0','#60B3F7','#E8F958','#F97558'];
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
        this.dataOneService.changeMessage({
          type:'archive'      
       })
      }else{
        this.dataOneService.changeMessage({
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
        this.dataOneService.changeMessage({
          type:'trash'      
       })
      }else{
        this.dataOneService.changeMessage({
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
      this.dataOneService.changeMessage({
        type:'delete'      
     })
    },
    error=>{
      console.log('error msg', error); 
    })
  }

  
}
