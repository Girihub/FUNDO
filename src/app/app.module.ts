import { BrowserModule } from '@angular/platform-browser/';
import { NgModule, Injectable } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { ForgetComponent } from './Components/forget/forget.component';
import { MaterialModule } from './app.material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {FlexLayoutModule} from '@angular/flex-layout';
import { MatInputModule } from '@angular/material';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import { ResetComponent } from './Components/reset/reset.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { NotesComponent } from './Components/notes/notes.component';
import { DisplayNoteComponent } from './Components/display-note/display-note.component';
import { MakeNoteComponent } from './Components/make-note/make-note.component';
import { IconComponent } from './Components/icon/icon.component';
import { ArchiveComponent } from './Components/archive/archive.component';
import { TrashComponent } from './Components/trash/trash.component';
import { ReminderComponent } from './Components/reminder/reminder.component';
import { SearchComponent } from './Components/search/search.component';
import { GetLabelComponent } from './Components/get-label/get-label.component';
import { CreateLabelComponent } from './Components/create-label/create-label.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForgetComponent,
    ResetComponent,
    DashboardComponent,
    NotesComponent,
    DisplayNoteComponent,
    MakeNoteComponent,
    IconComponent,
    ArchiveComponent,
    TrashComponent,
    ReminderComponent,
    SearchComponent,
    GetLabelComponent,
    CreateLabelComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    [FlexLayoutModule],
    MatButtonModule,
    HttpClientModule,
    OwlDateTimeModule, 
    OwlNativeDateTimeModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
