import { Component } from '@angular/core';
import { DriverService } from 'app/driver-service';
import { DriversApiResponse } from './AllDriversApiResponse';
import { VehiclesApiResponse } from './AllVehiclesApiResponce';
import { VehicleService } from 'app/vehicle.service';
import { RouteService } from 'app/route.service';
import { SingleRouteApiResponse } from './SingleRouteApiResponse';
import { GeofencesService } from 'app/geofences.service';
import { GeofencesApiResponse } from './AllGeofencesApiResponse';

@Component({
  selector: 'app-get-entry',
  templateUrl: './get-entry.component.html',
  styleUrl: './get-entry.component.css'
})
export class GetEntryComponent {

  Routes : any[] = [];
  Drivers : any[] = [];
  Vehicles : any[] = [];
  Geofences : any[] = [];
  selectedOption: string = '';
  VehiclesInformations : any[] = [];
  selectedVehicle = '';
  startTime = '';
  endTime ='';


  constructor(
  private driverService :DriverService,
  private vehicleService :VehicleService,
  private routeService : RouteService,
  private geofencesService :GeofencesService
  ){}
  

  ngOnInit(): void {
    this.vehicleService.getVehiclesData().subscribe((data) => {
      this.Vehicles = data.dicOfDT.Vehicles;
    });
  }

  getDrivers(): void {
    this.driverService.getDriversData().subscribe((data: DriversApiResponse) => {
      this.Drivers = data.dicOfDT.Drivers;
      this.VehiclesInformations = [];
      this.Vehicles = [];
      this.Routes = [];
      this.Geofences =[];
    }, error => {
      console.error("Error fetching drivers:", error);
    });
  }

  getVehicles(): void {
    this.vehicleService.getVehiclesData().subscribe((data: VehiclesApiResponse) => {
      this.Vehicles = data.dicOfDT.Vehicles;
      this.VehiclesInformations = [];
      this.Drivers = [];
      this.Routes = [];
      this.Geofences =[];
    }, error => {
      console.error("Error fetching vehicles:", error);
    });
  }

  getVehiclesInformations():void{ 
    this.vehicleService.getVehiclesInformations().subscribe((data) => {
      this.VehiclesInformations = data.dicOfDT.VehiclesInformations;
      this.Drivers = [];
      this.Routes = [];
      this.Geofences =[];
  },error => {
    console.error("Error fetching VehiclesInformations:", error);
  });
}

getRoutes(vehicleId:string , startTime : string , endTime: string): void {
  this.routeService.getRoute(vehicleId,startTime,endTime).subscribe((data: SingleRouteApiResponse) => {
    this.Routes = data.dicOfDT.RouteHistory;
    this.VehiclesInformations = [];
    this.Drivers = [];
    this.Geofences =[];
    this.selectedVehicle = '';
    this.startTime = '';
    this.endTime ='';
  }, error => {
    console.error("Error fetching routs:", error);
  });
  
}

getAllGeofences():void{
  this.geofencesService.getGofencesData().subscribe((data: GeofencesApiResponse) => {
    this.Geofences = data.dicOfDT.Geofences;
    this.Drivers = [];
    this.Routes = [];
  }, error => {
    console.error("Error fetching geofences:", error);
  });

}


  onOptionChange(): void {
  }



}
