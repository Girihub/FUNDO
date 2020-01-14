import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NoteService } from '../../Services/note.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'
import { DatePipe } from '@angular/common';
import {MatSnackBar} from '@angular/material/snack-bar';
@Component({
  selector: 'app-icon',
  templateUrl: './icon.component.html',
  styleUrls: ['./icon.component.scss']
})
export class IconComponent implements OnInit {
  
  constructor(
    private snackbar: MatSnackBar,
    private noteService : NoteService,
    private dataOneService: DataOneService,
    private datePipe: DatePipe
  ) { }

  @Input() isTrash:boolean;
  message:string;
  colors=['#FFFFFF','#FBAD44','#FCE97C','#66ffe0','#9BF9C1','#AEF9F8','#AEBEFB',
  '#F9B1DB','#E9D1D0','#60B3F7','#E8F958','#F97558'];
  @Input() noteIds
  @Output() addArchiveEvent = new EventEmitter<any>();  
  @Output() onDatePicked: EventEmitter<any> = new EventEmitter<any>(); 
  reminderDate;
  isArchive=false;
// isTrash=true;


  ngOnInit() {
    
  }   

  color(value){
    if(this.noteIds==null || this.noteIds==undefined){
      this.dataOneService.changeMessage({
        type:'color',
        data:value
      })
    }
    else{
      this.noteIds['color']=value;
    let data={
      id:this.noteIds.id,
      color:value
    }

    this.noteService.changeColor(data).subscribe(response =>{
      console.log('response', response);
      this.snackbar.open(response['message'],'',{duration:2000});
    },
    error=>
    {
        console.log('error msg', error);  
        this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000});  
    })
    }    
  } 

  archive(){
    if(this.noteIds==null || this.noteIds==undefined){
      this.isArchive=!this.isArchive
      this.dataOneService.changeMessage({
        data:this.isArchive,
        type:'archive',
      })
    }
    else{
      this.noteService.archive(this.noteIds.id).subscribe(response =>{
        console.log('response', response);
        this.snackbar.open(response['data'],'',{duration:2000});
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
        this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000}); 
      })
    }    
  }

  trash(){
    if(this.noteIds==null || this.noteIds==undefined){
      return
    }else{
      this.noteService.trash(this.noteIds.id).subscribe(response =>{
        console.log('response', response);
        this.snackbar.open(response['data'],'',{duration:2000});
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
        this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000}); 
      })
    }
  }

  addImage(event){
    if(this.noteIds==null || this.noteIds==undefined){
      return
    }else{
      console.log(event.target.files[0].name);    
    let data={
      id:this.noteIds.id,
      formFile:event.target.files[0].name
    }
    return this.noteService.addImage(data).subscribe(response=>{
      this.noteIds['image']=event.target.files[0].name;
      console.log(response);
      this.snackbar.open(response['message'],'',{duration:2000});
    },error=>{
      console.log('error',error);
      this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000}); 
    })
    }
  }  

  deleteNote(){
    if(this.noteIds==null || this.noteIds==undefined){
      return
    }else{
      this.noteService.deleteNote(this.noteIds.id).subscribe(response =>{
        console.log('response', response);
        this.snackbar.open(response['message'],'',{duration:2000});
        this.dataOneService.changeMessage({
          type:'delete'      
       })
      },
      error=>{
        console.log('error msg', error); 
        this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000}); 
      })
    }
  }
  
  addReminder(value){ 
    if(value=='today'){
      this.reminderDate=new Date()
      //set hour hour time of 8:00AM. wasn't working properly so did the adjustment
      this.reminderDate.setHours(25,30,0)
    }else if(value=='tomorrow'){
      this.reminderDate=new Date()
      var today = new Date()
      this.reminderDate.setDate(today.getDate() + 1)
      //set hour hour time of 8:00AM. wasn't working properly so did the adjustment
      this.reminderDate.setHours(13,30,0)
    }else if(value==null){
      this.reminderDate=null
    }
    else{
      this.reminderDate=new Date(value)
      this.reminderDate.setHours(this.reminderDate.getHours()+5);
      this.reminderDate.setMinutes(this.reminderDate.getMinutes()+30)
    }

    if(this.noteIds==null || this.noteIds==undefined){
      this.dataOneService.changeMessage({
        type:'makeReminder',
        data:this.reminderDate
      })
    }else{         
      
      let data={
        id:this.noteIds.id,
        Reminder:this.reminderDate
      }
      
      this.noteService.addReminder(data).subscribe(response =>{
        console.log(response);
        this.snackbar.open(response['message'],'',{duration:2000});
        this.dataOneService.changeMessage({
          type:'addReminder'
        })
      },error=>{
        console.log('error',error);
        this.snackbar.open(error.statusText + '. ' + error.error.message,'',{duration:2000});
      })
    }
  }
  
}
