import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VehicleApiResponse } from './vehicle-list//VehicleApiResponse ';
import { DetailedVehicleApiResponse } from './vehicle-list/DetailedVehicleApiResponse';
import { SingleVehicleApiResponse } from './SingleVehicleApiResponse';
import { SingleVehicleInformationApiResponse } from './SingleVehicleInformationApiRespnse';
import { VehiclesApiResponse } from './get-entry/AllVehiclesApiResponce';
import { VehiclesInformationsApiResponse } from './get-entry/AllVehiclesInformationsResponse';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
@Injectable({
  providedIn: 'root'
})
export class VehicleService {



  private getAllUrl = 'http://localhost:5000/VehicleInformation/getAllVehiclesInformation';
  private showMoreUrl = 'http://localhost:5000/VehicleInformation/getSpecificVehicleInformation';
  private addVehicleUrl = 'http://localhost:5000/Vehicles/addVehicle';
  private deleteVehicleUrl = 'http://localhost:5000/Vehicles/deleteVehicle';
  private addVehicleInformationUrl ='http://localhost:5000/VehicleInformation/addVehicleInformation';
  private deleteVehicleInformationsUrl = 'http://localhost:5000/VehicleInformation/deleteVehicleInformation';
  private getVehicleInformationUrl = 'http://localhost:5000/VehicleInformation/getVehicleInformation';
  private updateVehicleUrl = 'http://localhost:5000/Vehicles/updateVehicle';
  private updateVehicleInformationUrl = 'http://localhost:5000/VehicleInformation/updateVehicleInformation';
  private getAllVehiclesUrl = 'http://localhost:5000/Vehicles/getAllVehicles';
  private getVehicleUrl = 'http://localhost:5000/Vehicles/getVehicle';
  private getAllVehiclesInformationsUrl ='http://localhost:5000/VehicleInformation/getAll';
  
  public hubConnection!: HubConnection;
  public vehicles:any[]=[];

  constructor(private http: HttpClient) {
    this.buildConnection();
    this.startConnection();
  }

  private buildConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('http://localhost:5000/vehicleHub')
      .build();
  }

  private startConnection(): void {
    this.hubConnection.start()
      .then(() => {
        console.log('Connection started');
        this.registerOnServerEvents();
      })
      .catch(err => console.error('Error while starting connection: ', err));
  }

  private registerOnServerEvents(): void {
    this.hubConnection.on('ReceiveRouteHistoryUpdate', (routeHistory) => {
      console.log('Route history update received:', routeHistory);
      this.fetchUpdatedVehicleData();
    });
  }

  fetchUpdatedVehicleData(): void {
    this.getVehicleData().subscribe((data) => {
      this.vehicles = data.dicOfDT.VehiclesInformation;
    });
  }

  getVehicleData(): Observable<VehicleApiResponse> {
    return this.http.get<VehicleApiResponse>(this.getAllUrl);
  }


  getVehiclesInformations(): Observable<VehiclesInformationsApiResponse > {
    return this.http.get<VehiclesInformationsApiResponse>(this.getAllVehiclesInformationsUrl);
  }

  getDetailedVehicleInformation(vehicleId: string): Observable<DetailedVehicleApiResponse> {

    const requestBody = {
      dicOfDic: {
        getVehicleInformation: {
          vehicleid: vehicleId
        }
      }
    };
    return this.http.post<DetailedVehicleApiResponse>(this.showMoreUrl, requestBody);
  }

  
  addNewVehicle(vehicleNumber:string , vehicleType:string): Observable<ApiResponse>{
    const requestBody = {
      dicOfDic: {
        Vehicle: {
          vehiclenumber: vehicleNumber,
          vehicletype : vehicleType
        }
      }
    };
    
    return this.http.post<ApiResponse>(this.addVehicleUrl,requestBody);
  }

  deleteVehicle(vehicleId:string): Observable<ApiResponse>{
    const requestBody = {
      dicOfDic: {
        Vehicle: {
          vehicleid :vehicleId
        }
      }
    };
    return this.http.post<ApiResponse>(this.deleteVehicleUrl,requestBody);
  }

  addNewVehicleInformation(vehicleId:string,driverId:string,vehicleMake:string,vehicleModel:string ,purchaseDate:string): Observable<ApiResponse>{
    const requestBody = {
      dicOfDic: {
        gool: {
          vehicleid : vehicleId,
          driverid : driverId,
          vehiclemake : vehicleMake,
          vehiclemodel : vehicleModel,
          purchasedate : purchaseDate
        }
      }
    };
    return this.http.post<ApiResponse>(this.addVehicleInformationUrl,requestBody);
  }

  deleteVehicleInformation(vehicleId:string): Observable<ApiResponse>{
    const requestBody = {
      dicOfDic: {
        gool: {
          vehicleid : vehicleId
        }
      }
    };
    return this.http.post<ApiResponse>(this.deleteVehicleInformationsUrl,requestBody);
  }

  getVehicle(vehicleId: string): Observable<SingleVehicleApiResponse> {

    const requestBody = {
      dicOfDic: {
        vehicle: {
          vehicleid: vehicleId
        }
      }
    };
    return this.http.post<SingleVehicleApiResponse>(this.getVehicleUrl, requestBody);
  }

  getVehicleInformation(vehicleId: string): Observable<SingleVehicleInformationApiResponse> {

    const requestBody = {
      dicOfDic: {
        vehicleinformation: {
          vehicleid: vehicleId
        }
      }
    };
    return this.http.post<SingleVehicleInformationApiResponse>(this.getVehicleInformationUrl, requestBody);
  }

  updateVehicle(vehicleNumber: string, vehicleType: string,vehicleId: string){

    const requestBody = {
      dicOfDic: {
        Vehicle: {
          vehicleid:vehicleId,
          vehiclenumber: vehicleNumber,
          vehicletype: vehicleType
        }
      }
    };
    return this.http.put(this.updateVehicleUrl, requestBody);
  }

  getVehiclesData(): Observable<VehiclesApiResponse> {
    return this.http.get<VehiclesApiResponse>(this.getAllVehiclesUrl);
  }

  updateVehicleInformation(driverId:string,VehicleId: string, vehicleMake: string,vehicleModel: string, purchaseDate: string){

    const requestBody = {
      dicOfDic: {
        gool: {
          vehicleid:VehicleId,
          driverid:driverId,
          vehiclemake: vehicleMake,
          vehiclemodel: vehicleModel,
          purchasedate: purchaseDate
        }
      }
    };
    return this.http.put(this.updateVehicleInformationUrl, requestBody);
  }
}
interface ApiResponse {
  success: boolean;
  message: string;
}
