import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-icon',
  templateUrl: './icon.component.html',
  styleUrls: ['./icon.component.scss']
})
export class IconComponent implements OnInit {

  btncolor="";
  constructor() { }

  ngOnInit() {
  } 
  color(value){
    return value;
  }
}
