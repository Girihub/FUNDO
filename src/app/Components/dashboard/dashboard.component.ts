import {MediaMatcher} from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import { Router } from '@angular/router';

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

  mobileQuery: MediaQueryList;


  private _mobileQueryListener: () => void;
  
constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, 
  private snackbar: MatSnackBar, private router: Router) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnInit() {
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
}


