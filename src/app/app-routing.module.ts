import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import {RegisterComponent} from './Components/register/register.component';
import {ForgetComponent} from './Components/forget/forget.component';
import {ResetComponent} from './Components/reset/reset.component';
import {DashboardComponent} from './Components/dashboard/dashboard.component';
import { NotesComponent } from './Components/notes/notes.component';


const routes: Routes = [
  {path: '',redirectTo:'login', pathMatch:'full'},
  {path:'login', component: LoginComponent},
  {path:'register', component: RegisterComponent},
  {path:'forget', component: ForgetComponent},
  {path:'reset/:token', component: ResetComponent},

  {path:'dashboard', component: DashboardComponent,
  children:[
    {path:'', redirectTo:'notes', pathMatch:'full'},
    {path:'notes', component: NotesComponent}
  ]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
