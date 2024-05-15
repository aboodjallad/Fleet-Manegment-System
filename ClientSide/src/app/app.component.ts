import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ClientSide';

  constructor(
    private _router: Router
  ) { }

  navigatePage(page: string): void {
    this._router.navigate([page])
  }

}
