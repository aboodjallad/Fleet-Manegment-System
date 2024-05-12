import { Component } from '@angular/core';
import {DriverService} from '../driver-service';
import { VehicleService } from 'app/vehicle.service';
import { RouteService } from 'app/route.service';
@Component({
  selector: 'app-add-entry',
  templateUrl: './add-entry.component.html',
  styleUrls: ['./add-entry.component.css']
})

export class AddEntryComponent {

  constructor(
    private driverService: DriverService,
    private vehicleService: VehicleService,
    private routeService : RouteService
  ) { }


  selectedOption: string = '';
  driverName: string = '';
  phoneNumber: string = '';
  vehicleType: string = '';
  vehicleNumber: string = '';
  vehicleId: string = '';
  driverId: string = '';
  vehicleMake: string = '';
  vehicleModel: string = '';
  purchaseDate: string = '';
  vehicleDirection: string = '';
  status: string = '';
  vehicleSpeed: string = '';
  recordTime: string = '';
  address: string = '';
  latitude: string = '';
  longitude: string = '';



  onOptionChange(): void {
  }

  addDriver(driverName: string, phoneNumber: string): void {
    this.driverService.addNewDriver(driverName, phoneNumber).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.driverName = '';
        this.phoneNumber= '';
        console.log('vehicle added successfully:', response);
      },
      error: (error) => {
        console.error('Error adding Driver:', error);
      }
    });
  }

  addVehicle(vehicleNumber:string ,vehicleType:string) : void{
    this.vehicleService.addNewVehicle(vehicleNumber,vehicleType).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.vehicleNumber = '';
        this.vehicleType= '';
        console.log('Vehicle added successfully:', response);
      },
      error: (error) => {
        console.error('Error adding Vehicle:', error);
      }
    })
  }

  addVehicleInformation(vehicleId:string,driverId:string,vehicleMake:string,vehicleModel:string ,purchaseDate:string): void{
    this.vehicleService.addNewVehicleInformation(vehicleId,driverId,vehicleMake,vehicleModel,purchaseDate).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.vehicleId = '';
        this.driverId = '';
        this.vehicleMake = '';
        this.vehicleModel = '';
        this.purchaseDate = '';
        console.log('Vehicle information added successfully:', response);
      },
      error: (error) => {
        console.error('Error adding VehicleInformation:', error);
      }
    })
  }

  addRouteHistory(vehicleId:string,vehicleDirection:string,status:string,vehicleSpeed:string,recordTime:string,address:string,latitude:string,longitude:string): void{
    this.routeService.addNewRouteHistory(vehicleId,vehicleDirection,status,vehicleSpeed,recordTime,address,latitude,longitude).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.vehicleId = '';
        this.driverId = '';
        this.vehicleMake = '';
        this.vehicleModel = '';
        this.purchaseDate = '';
        console.log('Route History added successfully:', response);
      },
      error: (error) => {
        console.error('Error adding Route History:', error);
      }
    })
  }
}
