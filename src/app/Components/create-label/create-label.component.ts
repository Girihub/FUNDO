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
  delete=false;
  
  ngOnInit() {
    this.dataServive.currentLabel.subscribe(response =>{
      if(response.type=[]){
        var result: any[][] = response.data;
        this.allLabels=result;
      }
    })    
  }


  addLabel(){
    if(this.label){
      let Label={
        Lable:this.label
      }
      console.log(Label.Lable)
      return this.labelService.addLabel(Label).subscribe(response =>{
        console.log(response);
        this.dialogRef.close();
        this.dataServive.changeLabel({
          type:['refreshLabel']
       })
      },
      error=>{
        console.log('error', error);
        this.dialogRef.close();
      })      
    }
    else
    {
      this.dialogRef.close();
    }    
  }

  deleteLabel(id){
    return this.labelService.deleteLabel(id).subscribe(response =>{
      console.log(response)
      this.dataServive.changeLabel({
        type:['refreshLabel']
     })
      this.dialogRef.close();
    },error=>{
      console.log('error',error)
    })
  }

}