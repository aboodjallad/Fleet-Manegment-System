import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import 'tslib';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { MatDialogModule } from '@angular/material/dialog';
import { AddEntryComponent } from './add-entry/add-entry.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { DeleteEntryComponent } from './delete-entry/delete-entry.component';
import { UpdateEntryComponent } from './update-entry/update-entry.component';
import { GetEntryComponent } from './get-entry/get-entry.component';


// Other component imports
const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  // other routes
];

@NgModule({
  declarations: [
    AddEntryComponent,
    AppComponent,
    VehicleListComponent,
    AddEntryComponent,
    DeleteEntryComponent,
    UpdateEntryComponent,
    GetEntryComponent,
    // other components
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    MatDialogModule,
    HttpClientModule,
    RouterModule.forRoot(routes) 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
