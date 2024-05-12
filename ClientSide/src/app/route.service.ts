import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class RouteService {

private addRouteUrl = 'http://localhost:5000/RouteHistory/addRouteHistory';

  constructor(private http: HttpClient) { }


  addNewRouteHistory(vehicleId:string,vehicleDirection:string,Status:string,vehicleSpeed:string,recordTime:string,Address:string,Latitude:string,Longitude:string): Observable<ApiResponse>{
    const requestBody = {
      dicOfDic: {
        addRouteHistory: {
          vehicleid : vehicleId,
          vehicledirection : vehicleDirection,
          status : Status,
          vehiclespeed : vehicleSpeed,
          recordtime : recordTime,
          address : Address,
          latitude : Latitude,
          longitude : Longitude
        }
      }
    };
    return this.http.post<ApiResponse>(this.addRouteUrl,requestBody);
  }

}
interface ApiResponse {
  success: boolean;
  message: string;
}