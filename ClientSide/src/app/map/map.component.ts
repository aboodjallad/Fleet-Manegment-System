import { Component, OnInit } from '@angular/core';
import * as mapboxgl from 'mapbox-gl';
import { VehicleService } from 'app/vehicle.service';
import { RouteService } from 'app/route.service';
import { RouteApiResponse } from './SingleRouteApiResponse';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})

export class MapComponent implements OnInit {
  constructor(
     private vehicleService :VehicleService,
     private routeService : RouteService
  )
  {}

  marker!: mapboxgl.Marker;
  map!: mapboxgl.Map;
  accessToken = 'pk.eyJ1IjoiYWJvb2RqYWxsYWQiLCJhIjoiY2x3NXl4Z2IyMWtuajJrbDhtd3VndTRlMiJ9.-tjYDMiBL2z9WlYD-3OPtA';

  Selected: string = '';
  Vehicles : any[] = [];
  Longitude : number = 0; 
  Latitude : number = 0;
  StartTime : string ='0';
  EndTime : string ='9999999999999999999999999999999999999999';
  Route: any = null;

  ngOnInit(): void {
    this.vehicleService.getVehiclesData().subscribe((data) => {
      console.log(data);
      this.Vehicles = data.dicOfDT.Vehicles;
      this.marker= new mapboxgl.Marker().setLngLat([-74.16426145, 40.18451275]).addTo(this.map);
      this.map = new mapboxgl.Map({
      container: 'map',
      style: 'mapbox://styles/mapbox/streets-v11',
      center: [-74.16426145, 40.18451275],
      zoom: 9,
      accessToken: this.accessToken ,
      attributionControl: false

    });
  })
  }
  

  getCordenates(vehicleID:string) {
    console.log('Selected Vehicle:', this.Selected);  // Debugging line

    this.routeService.getLastRoute(vehicleID,this.StartTime,this.EndTime).subscribe((data)=>{
      console.log('Response data:', data);  // Debugging line

      this.Route = data.dicOfDic.route;
      this.Longitude = parseFloat(this.Route["longitude"]);
      this.Latitude = parseFloat(this.Route["latitude"]);
      this.goToVehicle();
      this.Latitude=0;
      this.Longitude =0;
      this.Route =[];
    })

  }

  goToVehicle() {
    if (!this.marker) {
      this.marker = new mapboxgl.Marker()
        .setLngLat([this.Longitude, this.Latitude])
        .addTo(this.map);
    } else {
      this.marker.setLngLat([this.Longitude, this.Latitude]);
    }
    this.map.flyTo({
      center: [this.Longitude, this.Latitude],
      essential: true,
      zoom: 9
    });
  }

  onOptionChange(){

    console.log('Vehicle changed to:', this.Selected); // Debugging line

  }
}
