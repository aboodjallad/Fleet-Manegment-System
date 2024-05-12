import { Component } from '@angular/core';
import { DriverService } from 'app/driver-service';


@Component({
  selector: 'app-get-entry',
  templateUrl: './get-entry.component.html',
  styleUrl: './get-entry.component.css'
})
export class GetEntryComponent {
  Drivers : any[] = [];
  _selectedOption: string = '';

  constructor(
  private driverService :DriverService

  ){}
  
  getDrivers(): void {
    this.driverService.getDriversData().subscribe((data) => {
      this.Drivers = data.dicOfDT["drivers"];
    });
  }

  set selectedOption(value: string) {
    this._selectedOption = value;
    if (value === 'driver') {
      this.getDrivers();
    }
  }

  onOptionChange(): void {
  }



}
