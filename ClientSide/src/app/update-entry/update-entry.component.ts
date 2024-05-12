import { Component } from '@angular/core';
import {DriverService} from '../driver-service';
import { VehicleService } from 'app/vehicle.service';


@Component({
  selector: 'app-update-entry',
  templateUrl: './update-entry.component.html',
  styleUrl: './update-entry.component.css'
})
export class UpdateEntryComponent {
  driver : any = null;
  vehicle : any = null;
  vehicleInformation : any = null;
  selectedVehicleId: string | null = null;
  selectedDriverId: string | null = null;
  isUpdateStep: boolean = false;


  constructor(
    private driverService: DriverService,
    private vehicleService: VehicleService,
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


  onOptionChange(): void {
  }

  showSelectedVehicle(vehicleId: string) {
    this.selectedVehicleId = vehicleId;
    this.vehicleService.getVehicle(this.selectedVehicleId).subscribe((data) => {
      this.vehicle = data.dicOfDic['vehicle'];
      this.isUpdateStep = true;
      this.vehicleNumber = this.vehicle["vehiclenumber"];
      this.vehicleType = this.vehicle["vehicletype"];
    });
  }

  showSelectedVehicleInformation(vehicleId: string) {
    this.selectedVehicleId = vehicleId;
    this.vehicleService.getVehicleInformation(this.selectedVehicleId).subscribe((data) => {
      this.vehicleInformation = data.dicOfDic['vehicleinformation'];
      this.isUpdateStep = true;
      this.driverId = this.vehicleInformation["driverid"];
      this.vehicleMake = this.vehicleInformation["vehiclemake"];
      this.vehicleModel = this.vehicleInformation["vehiclemodel"];
      this.purchaseDate = this.vehicleInformation["purchasedate"];
    });
  }

  showSelectedDriver(driverId: string) {
    this.selectedDriverId = driverId;
    this.driverService.getDriver(this.selectedDriverId).subscribe((data) => {
      this.driver = data.dicOfDic['driver'];
      this.isUpdateStep = true;
      this.driverName = this.driver["drivername"];
      this.phoneNumber = this.driver["phonenumber"];
    });
  }


  updateDriver() {
  this.driverService.updateDriver(this.driverName,this.phoneNumber,this.driverId).subscribe(()=>{
    this.isUpdateStep = false;
    this.selectedOption='';
    this.driverId = '';
    this.phoneNumber = '';
    this.driverName = '';
  })
  }

  updateVehicle() {
    this.vehicleService.updateVehicle(this.vehicleNumber,this.vehicleType,this.vehicleId).subscribe(()=>{
      this.isUpdateStep = false;
      this.selectedOption='';
      this.vehicleId = '';
      this.vehicleNumber = '';
      this.vehicleType = '';
    })
    
}

updateVehicleInformation(){
  this.vehicleService.updateVehicleInformation(this.driverId,this.vehicleId,this.vehicleMake,this.vehicleModel,this.purchaseDate).subscribe(()=>{
    this.isUpdateStep = false;
    this.selectedOption='';
    this.driverId= '';
    this.vehicleMake='';
    this.purchaseDate='';
  })
}

}
