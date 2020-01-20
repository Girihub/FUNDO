import { Component, OnInit } from '@angular/core';
import{LabelService} from '../../Services/labelService/label.service'
import {MatDialogRef} from '@angular/material';
import{DataServiceService} from '../../Services/DataService/data-service.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'

@Component({
  selector: 'app-create-label',
  templateUrl: './create-label.component.html',
  styleUrls: ['./create-label.component.scss']
})
export class CreateLabelComponent implements OnInit {

  constructor(private labelService: LabelService,private dataServive : DataServiceService,private dataOneService: DataOneService,
    public dialogRef: MatDialogRef<CreateLabelComponent>) { }

  name=localStorage.getItem('firstName');
  label:any;
  allLabels=[];
  
  
  ngOnInit() {
    this.dataServive.currentLabel.subscribe(response =>{
      if(response.type='dialog'){
        var result: any[][] = response.data;
        this.allLabels=result;
        console.log(response)
      }
    })    
  }

  close(){
    this.dialogRef.close();
  }

  addLabel(value){
    if(value){
      let Label={
        Lable:value
      }
      console.log(Label.Lable)
      return this.labelService.addLabel(Label).subscribe(response =>{
        console.log(response); 
        this.label=''       
        this.dataServive.changeLabel({
          type:'refreshLabel'
       })
      },
      error=>{
        console.log('error', error);
      })      
    }   
  }

  deleteLabel(id){
    return this.labelService.deleteLabel(id).subscribe(response =>{
      console.log(response)
      this.dataServive.changeLabel({
        type:'refreshLabel'
     })
    },error=>{
      console.log('error',error)
    })
  }

  editLabel(id,data){
    if(data){
      let Data={
        id:id,
        Lable:data
      }
      this.labelService.editLabel(Data).subscribe(response=>{
        console.log('response',response)
        this.dataServive.changeLabel({
          type:'refreshLabel'
       })
      },error=>{
        console.log('error',error)
      })
    }
  }

}