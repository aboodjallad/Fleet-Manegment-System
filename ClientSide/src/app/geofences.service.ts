import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {GeofencesApiResponse} from './get-entry/AllGeofencesApiResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GeofencesService {

  constructor(private http: HttpClient) { }


  private getGeofencesUrl ='http://localhost:5000/Geofences/getAllGeofences';

  getGofencesData(): Observable<GeofencesApiResponse> {
    return this.http.get<GeofencesApiResponse>(this.getGeofencesUrl);
  }

}
