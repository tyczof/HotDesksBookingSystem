import { Component, OnInit } from '@angular/core';
import { LocationService } from '../../../services/location.service';
import { DeskService } from '../../../services/desk.service';
import { Location } from '../../../models/location.model';
import { Desk } from '../../../models/desk.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-admin-forms',
  templateUrl: './admin-forms.component.html',
  styleUrls: ['./admin-forms.component.css']
})
export class AdminFormsComponent implements OnInit {
  locations: Location[] = [];
  desks?: Desk[] = [];
  newLocationName: string = '';
  newDeskNumber: string = '';
  selectedLocationId: number = 0;
  selectedLocationName: string = '';
  selectedDeskId: number = 0;

  locationError: string = ''; // Dodaj zmienną do przechowywania błędów lokalizacji
  deskError: string = '';     // Dodaj zmienną do przechowywania błędów biurka

  constructor(private locationService: LocationService, private deskService: DeskService) {}

  ngOnInit(): void {
    this.loadLocations();
  }

  loadLocations() {
    this.locationService.getLocations().subscribe(locations => {
      this.locations = locations;
      this.locationError = '';
    });
  }

  addLocation() {
    if (this.newLocationName) {
      const newLocation: Location = { id: 0, name: this.newLocationName };
      this.locationService.addLocation(newLocation).subscribe(() => {
        this.loadLocations();
        this.newLocationName = '';
        this.locationError = '';
      }, error => {
        this.locationError = 'Failed to add location: ' + error.message;
      });
    }
  }

  deleteLocation(locationId: number) {
    this.locationError = '';
    this.deskError = '';
    const confirmed = window.confirm('Are you sure you want to delete this location?');
    
    if (confirmed) {
      this.selectedLocationId = locationId
      this.locationService.deleteLocation(locationId).subscribe({
        next: () => {
          this.loadLocations();
        },
        error: (error: HttpErrorResponse) => {
          if (error.error instanceof ErrorEvent) {
            this.locationError = 'An error occurred: ' + error.error.message;
          } else {
            this.locationError = error.error;
          }
        }
      });
    }
  }

  loadDesks(selectedLocationId: number) {
    this.locationService.getLocation(selectedLocationId).subscribe(location => {
      this.selectedLocationName = location.name;
      this.selectedLocationId = selectedLocationId;
      this.desks = location.desks;
      this.deskError = '';
    }, error => {
      this.deskError = 'Failed to load desks: ' + error.message;
    });
  }

  addDesk() {
    if (this.newDeskNumber && this.selectedLocationId) {
      const newDesk: Desk = { deskNumber: this.newDeskNumber, isAvailable: true, locationId: this.selectedLocationId };
      this.deskService.addDesk(newDesk).subscribe(() => {
        this.loadDesks(this.selectedLocationId);
        this.newDeskNumber = '';
        this.deskError = '';
      }, error => {
        this.deskError = 'Failed to add desk: ' + error.message;
      });
    }
  }

  deleteDesk(deskId?: number) {
    this.deskError = '';
    this.locationError = '';
    const confirmed = window.confirm('Are you sure you want to delete this desk?');
    
    if (confirmed && deskId !== undefined) {
      this.selectedDeskId = deskId
      this.deskService.deleteDesk(deskId).subscribe({
        next: () => {
          this.loadDesks(this.selectedLocationId);
        },
        error: (error: HttpErrorResponse) => {
          if (error.error instanceof ErrorEvent) {
            this.deskError = 'An error occurred: ' + error.error.message;
          } else {
            this.deskError = error.error;  // Backend zwraca dokładny komunikat
          }
        }
      });
    }
  }

  toggleDeskAvailability(desk: Desk) {
    desk.isAvailable = !desk.isAvailable;
    this.deskService.toggleDeskAvailability(desk.id).subscribe(() => {
      this.deskError = '';
    }, error => {
      this.deskError = 'Failed to update desk availability: ' + error.message;
    });
  }
}
