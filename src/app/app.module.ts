import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './app.material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FlexLayoutModule} from '@angular/flex-layout';
import { MatInputModule } from '@angular/material';
import {MatButtonModule} from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { ConstituencyWiseComponent } from './Components/constituency-wise/constituency-wise.component';
import { PartyWiseComponent } from './Components/party-wise/party-wise.component';
import { AllCandidateComponent } from './Components/all-candidate/all-candidate.component';
import { VoteComponent } from './Components/vote/vote.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    RegisterComponent,
    ConstituencyWiseComponent,
    PartyWiseComponent,
    AllCandidateComponent,
    VoteComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MatInputModule,
    MatButtonModule,
    HttpClientModule
    
  ],
  entryComponents: [
    VoteComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }