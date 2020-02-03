import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from './Components/login/login.component';
import {RegisterComponent} from './Components/register/register.component';
import {DashboardComponent} from './Components/dashboard/dashboard.component';
import {ConstituencyWiseComponent} from './Components/constituency-wise/constituency-wise.component';
import {PartyWiseComponent} from './Components/party-wise/party-wise.component'


const routes: Routes = [
  {path: '',redirectTo:'dashboard', pathMatch:'full'},
  {path:'dashboard', component: DashboardComponent,
  // children:[
  //   {path:'',redirectTo:'constituency-wise',pathMatch:'full'},
  //   {path:'constituency-wise', component: ConstituencyWiseComponent},
  //   {path:'party-wise', component: PartyWiseComponent},
  // ]
},
  {path:'login', component: LoginComponent},
  {path:'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
