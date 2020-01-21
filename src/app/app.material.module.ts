import { NgModule } from '@angular/core';
import{MatCardModule} from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatMenuModule} from '@angular/material/menu';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import { MatSnackBarModule } from "@angular/material";
import {MatDialogModule,MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {DatePipe} from '@angular/common';
import {MatChipsModule} from '@angular/material/chips';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatCheckboxModule} from '@angular/material/checkbox';


@NgModule({
    imports:[
        MatCardModule,
        FlexLayoutModule,
        MatFormFieldModule,
        MatIconModule,
        ReactiveFormsModule,
        MatButtonToggleModule,
        MatToolbarModule,
        MatTooltipModule,
        MatMenuModule,
        MatSidenavModule,
        MatListModule,
        MatSnackBarModule,
        MatDialogModule,
        MatChipsModule,
        MatAutocompleteModule,
        MatCheckboxModule

    ],

    exports:[
        MatCardModule,
        FlexLayoutModule,
        MatFormFieldModule,
        MatIconModule,
        ReactiveFormsModule,
        MatButtonToggleModule,
        MatToolbarModule,
        MatTooltipModule,
        MatMenuModule,
        MatSidenavModule,
        MatListModule,
        MatSnackBarModule,
        MatDialogModule,
        MatChipsModule,
        MatAutocompleteModule,
        MatCheckboxModule

    ],

    providers:[DatePipe,
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] }
    ]
})
export class MaterialModule{}