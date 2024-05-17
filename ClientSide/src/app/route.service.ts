import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SingleRouteApiResponse } from './get-entry/SingleRouteApiResponse';
import { RouteApiResponse } from './map/SingleRouteApiResponse';
@Injectable({
  providedIn: 'root'
})
export class RouteService {

  private getRouteUrl= 'http://localhost:5000/RouteHistory/getRouteHistory';
  private addRouteUrl = 'http://localhost:5000/RouteHistory/addRouteHistory';
  getLastRouteUrl = 'http://localhost:5000/RouteHistory/getLastRouteHistory';

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

  getRoute(vehicleId: string , startTime:string, endTime:string): Observable<SingleRouteApiResponse> {

    const requestBody = {
      dicOfDic: {
        route: {
          vehicleid: vehicleId,
          starttime: startTime,
          endtime: endTime
        }
      }
    };
    return this.http.post<SingleRouteApiResponse>(this.getRouteUrl, requestBody);
  }

  getLastRoute(vehicleId: string , startTime:string, endTime:string): Observable<RouteApiResponse> {

    const requestBody = {
      dicOfDic: {
        route: {
          vehicleid: vehicleId,
          starttime: startTime,
          endtime: endTime
        }
      }
    };
    console.log('Request body:', requestBody); // Debugging line
    return this.http.post<RouteApiResponse>(this.getLastRouteUrl, requestBody);
  }




}
interface ApiResponse {
  success: boolean;
  message: string;
}