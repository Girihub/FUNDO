import { NgModule } from '@angular/core';
import{MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatDividerModule} from '@angular/material/divider';
import {DatePipe} from '@angular/common';

@NgModule({
    imports: [
        MatCardModule,
        MatFormFieldModule,
        MatIconModule,
        FlexLayoutModule,
        BrowserAnimationsModule,
        MatSnackBarModule,
        MatGridListModule,
        MatTableModule,
        MatPaginatorModule,
        MatSelectModule,
        MatDialogModule,
        MatSidenavModule,
        MatDividerModule,
    ],
    exports:[
        MatCardModule,
        MatFormFieldModule,
        MatIconModule,
        FlexLayoutModule,
        BrowserAnimationsModule,
        MatSnackBarModule,
        MatGridListModule,
        MatTableModule,
        MatPaginatorModule,
        MatSelectModule,
        MatDialogModule,
        MatSidenavModule,
        MatDividerModule
    ],
    providers: [DatePipe,
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] }
    ]
  })

export class MaterialModule{}