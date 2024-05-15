import { Component } from '@angular/core';
import {DriverService} from '../driver-service';
import { VehicleService } from 'app/vehicle.service';
import { RouteService } from 'app/route.service';
import { concatMap } from 'rxjs/operators';

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

  Vehicles : any[] = [];
  Drivers : any[] = [];
  selectedVehicle : string ='';
  selectedOption: string = '';
  selectedID: string = '';
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

 ngOnInit(): void {
  this.vehicleService.getVehiclesData().pipe(
    concatMap((vehicleData) => {
      this.Vehicles = vehicleData.dicOfDT.Vehicles;
      return this.driverService.getDriversData();
    })
  ).subscribe((driverData) => {
    this.Drivers = driverData.dicOfDT.Drivers;
  });
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
    this.vehicleService.addNewVehicleInformation(this.selectedVehicle,driverId,vehicleMake,vehicleModel,purchaseDate).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.selectedVehicle = '';
        this.selectedID = '';
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

  addRouteHistory(vehicleId :string,vehicleDirection:string,status:string,vehicleSpeed:string,recordTime:string,address:string,latitude:string,longitude:string): void{
    this.routeService.addNewRouteHistory(this.selectedID,vehicleDirection,status,vehicleSpeed,recordTime,address,latitude,longitude).subscribe({
      
      next: (response) => {
        this.selectedOption='';
        this.selectedID = '';
        this.vehicleDirection = '';
        this.status = '';
        this.latitude = '';
        this.longitude = '';
        this.vehicleSpeed = '';
        this.address = '';
        this.recordTime = '';

        console.log('Route History added successfully:', response);
      },
      error: (error) => {
        console.error('Error adding Route History:', error);
      }
    })
  }

  assignDriver(driverId: string, vehicleID: string): void {
    this.driverService.assignDriver(driverId, vehicleID).subscribe({
      next: (response) => {
        this.selectedOption='';
        this.selectedID ='';
        this.selectedVehicle = '';
        this.driverName = '';
        this.phoneNumber= '';
        console.log('vehicle added successfully:', response);
      },
      error: (error) => {
        console.error('Error adding Driver:', error);
      }
    });
  }
}
