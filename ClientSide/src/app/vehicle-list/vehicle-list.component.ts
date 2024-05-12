import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles : any[] = [];
  detailedVehicleInfo: any = null;
  selectedVehicleId: string | null = null;


  constructor(
    private vehicleService: VehicleService,
    private router:Router
  ) { }

  ngOnInit(): void {
    this.vehicleService.getVehicleData().subscribe((data) => {
      this.vehicles = data.dicOfDT.VehiclesInformation;
    });
  }

  showDetailedInfo(vehicleId: string) {
    this.selectedVehicleId = vehicleId;
    this.vehicleService.getDetailedVehicleInformation(this.selectedVehicleId).subscribe((data) => {
      this.detailedVehicleInfo = data.dicOfDic['Detailed VehicleInformation'];
      this.openDetailsModal(this.detailedVehicleInfo);
    });
  }

  openAddEntry(): void {
    this.router.navigate(['/add-entry']);
    console.log('Navigating to add entry');
  }

  openDetailsModal(data: any): void {
    const queryParams = encodeURIComponent(JSON.stringify(data));
    const popup = window.open(`assets/vehicle-details-popup.html?data=${queryParams}`, '_blank', 'width=1200,height=600');
  
    if (popup) {
      popup.focus();
    }

  }

}

