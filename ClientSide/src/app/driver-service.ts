import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SingleDriverApiResponse } from './SingleDriverApiResponce';
@Injectable({
  providedIn: 'root'
})

export class DriverService {
  private addDriverUrl = 'http://localhost:5000/Driver/addDriver';
  private deleteDriverUrl = 'http://localhost:5000/Driver/deleteDriver';
  private updateDriverUrl = 'http://localhost:5000/Driver/updateDriver';
  private getDriverUrl = 'http://localhost:5000/Driver/getDriver';
  constructor(private http: HttpClient) { }


  addNewDriver(driverName:string , phonenumber:string): Observable<ApiResponse>{
    const requestBody = {
      dicOfDic: {
        Driver1: {
          drivername: driverName,
          phonenumber : phonenumber
        }
      }
    };
    return this.http.post<ApiResponse>(this.addDriverUrl,requestBody);
  }

  deleteDriver(driverId:string): Observable<ApiResponse>{
    const requestBody = {
      dicOfDic: {
        Driver1: {
          driverid: driverId
        }
      }
    };
    return this.http.post<ApiResponse>(this.deleteDriverUrl,requestBody);
  }

  getDriver(driverId: string): Observable<SingleDriverApiResponse> {

    const requestBody = {
      dicOfDic: {
        driver: {
          driverid: driverId
        }
      }
    };
    return this.http.post<SingleDriverApiResponse>(this.getDriverUrl, requestBody);
  }

  updateDriver(drivername: string,phonenumber: string,driverId: string){

    const requestBody = {
      dicOfDic: {
        Driver: {
          driverid:driverId,
          drivername: drivername,
          phonenumber: phonenumber
        }
      }
    };
    return this.http.put(this.updateDriverUrl, requestBody);
  }
  
}
interface ApiResponse {
  success: boolean;
  message: string;
}



