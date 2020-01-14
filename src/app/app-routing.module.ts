import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import {RegisterComponent} from './Components/register/register.component';
import {ForgetComponent} from './Components/forget/forget.component';
import {ResetComponent} from './Components/reset/reset.component';
import {DashboardComponent} from './Components/dashboard/dashboard.component';
import { NotesComponent } from './Components/notes/notes.component';
import { TrashComponent } from './Components/trash/trash.component';
import { ArchiveComponent } from './Components/archive/archive.component';
import { ReminderComponent } from './Components/reminder/reminder.component';
import { SearchComponent } from './Components/search/search.component';
import{CreateLabelComponent} from './Components/create-label/create-label.component'
import{EditNoteComponent} from './Components/edit-note/edit-note.component'



const routes: Routes = [
  {path: '',redirectTo:'login', pathMatch:'full'},
  {path:'login', component: LoginComponent},
  {path:'register', component: RegisterComponent},
  {path:'forget', component: ForgetComponent},
  {path:'reset/:token', component: ResetComponent},

  {path:'dashboard', component: DashboardComponent,
  children:[
    {path:'', redirectTo:'notes', pathMatch:'full'},
    {path:'notes', component: NotesComponent},
    {path:'archived', component: ArchiveComponent},
    {path:'trashed', component: TrashComponent},
    {path:'remindered', component: ReminderComponent},
    {path:'search', component:SearchComponent},
    {path:'label', component:CreateLabelComponent},
    {path:'editNote', component:EditNoteComponent}
  ]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
