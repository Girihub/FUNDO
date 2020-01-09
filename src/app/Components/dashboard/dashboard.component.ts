import {MediaMatcher} from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { NoteService } from 'src/app/Services/note.service';
import{DataServiceService} from '../../Services/DataService/data-service.service';
import {DataOneService} from '../../Services/DataServiceOne/data-one.service'
import {LabelService} from '../../Services/labelService/label.service'
import {CreateLabelComponent} from './../create-label/create-label.component'
import {MatDialog} from '@angular/material';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  src ="/assets/images/list1.png";
  viewToolTip ="List View";
  viewClass = "listView";
  step ="step1";
  name = "Fundoo";
  userName = localStorage.getItem('fullName');
  userEmail = localStorage.getItem('email');
  userProfilePic = localStorage.getItem('profilePicture');

  mobileQuery: MediaQueryList;


  private _mobileQueryListener: () => void;
  
constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private dataservice:DataServiceService, 
  private snackbar: MatSnackBar, private router: Router, private note: NoteService, private labelService: LabelService,
  public dialog : MatDialog, private dataOneService: DataOneService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener, );
  }

  ngOnInit() {
    this.getAllLabels();
    
    this.dataservice.currentLabel.subscribe(response=>{
      if(response.type=['refreshLabel']){
        //this.getAllLabels();
      }     
    })
  }

  logout(){
    localStorage.clear();
    this.snackbar.open("Logged out successfully",'',{duration:2000});
    this.router.navigate(['/login']);
  }


  changeView(){
    if(this.src == "/assets/images/list1.png"){
      this.src="/assets/images/grid3.png";
      this.viewToolTip="Grid View";
      this.viewClass = "gridView"
    }else{
      this.src="/assets/images/list1.png";
      this.viewToolTip="List View";
      this.viewClass = "listView"
    }
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

  searchNotes(event:any){
    this.router.navigate(['/dashboard/search']);
     console.log('event',event);
     let searchNote=event.target.value;
     console.log('message',searchNote);
    this.dataOneService.changeMessage({
      data:searchNote,
      type:'search'
   })
  }

  label(){
    this.dataservice.changeLabel({
      data:this.getLabels,
      type:[]
   })
    this.dialog.open(CreateLabelComponent,{
      height: '400px',
      width: '300px',
    });
  }
}


