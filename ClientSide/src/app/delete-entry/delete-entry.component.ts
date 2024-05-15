import { Component } from '@angular/core';
import {DriverService} from '../driver-service';
import { VehicleService } from 'app/vehicle.service';
@Component({
  selector: 'app-delete-entry',
  templateUrl: './delete-entry.component.html',
  styleUrl: './delete-entry.component.css'
})
export class DeleteEntryComponent {

  constructor(
    private driverService: DriverService,
    private vehicleService: VehicleService
  ) { }

  selectedOption: string = '';
  vehicleId: string = '';
  driverId: string = '';


  onOptionChange(): void {
  }

  deleteDriver(driverId: string): void {
    this.driverService.deleteDriver(driverId).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.driverId = '';
        console.log('driver deleted successfully:', response);
      },
      error: (error) => {
        console.error('Error deleting Driver:', error);
      }
    });
  }

  deleteVehicle(vehicleId : string) : void{
    this.vehicleService.deleteVehicle(vehicleId).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.vehicleId = '';
        console.log('Vehicle deleted successfully:', response);
      },
      error: (error) => {
        console.error('Error deleting Vehicle:', error);
      }
    })
  }

  deleteVehicleInformation(vehicleId:string): void{
    this.vehicleService.deleteVehicleInformation(vehicleId).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.vehicleId = '';
        console.log('Vehicle information deleted successfully:', response);
      },
      error: (error) => {
        console.error('Error deleting VehicleInformation:', error);
      }
    })
  }

}
