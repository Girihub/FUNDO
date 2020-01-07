import { Component, OnInit } from '@angular/core';
import {LabelService} from '../../Services/labelService/label.service'

@Component({
  selector: 'app-get-label',
  templateUrl: './get-label.component.html',
  styleUrls: ['./get-label.component.scss']
})
export class GetLabelComponent implements OnInit {

  constructor(private labelService: LabelService) { }

  ngOnInit() {
    this.getAllLabels();
  }
  getLabels=[];

  getAllLabels(){
    this.labelService.getLabels().subscribe(response => {
      this.getLabels=response['data'];
      console.log(response);
    }, error =>{
      console.log('error', error);
    })
  }

}
