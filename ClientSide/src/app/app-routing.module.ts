import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { AddEntryComponent } from './add-entry/add-entry.component';
import { DeleteEntryComponent } from './delete-entry/delete-entry.component';
import { UpdateEntryComponent } from './update-entry/update-entry.component';
import { GetEntryComponent } from './get-entry/get-entry.component';

const routes: Routes = [
  { path: 'add-entry', component: AddEntryComponent },
  { path: 'home', component: VehicleListComponent },
  { path: 'delete-entry', component: DeleteEntryComponent },
  { path: 'update-entry', component: UpdateEntryComponent },
  { path: 'get-entry', component: GetEntryComponent},
  { path: '', redirectTo: 'home', pathMatch : 'full' },
  { path: '**', redirectTo: '' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
