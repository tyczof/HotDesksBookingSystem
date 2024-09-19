import { Component, Input, ViewChild } from '@angular/core';
import { DeskListComponent } from './desk-list/desk-list.component';
import { LocationService } from '../../services/location.service';
import { Location } from '../../models/location.model';
import { Employee } from '../../models/employee.model';

@Component({
  selector: 'app-main-screen',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.css']
})
export class MainScreenComponent {
  startDate: string = '';
  startTime: string = '08:00';
  endDate: string = '';
  endTime: string = '16:00'; 
  locationId: number = 0;
  locations: Location[] = [];
  @Input() employee!: Employee;

  today: string = '';

  constructor(private locationService: LocationService) {}

  @ViewChild(DeskListComponent) deskList!: DeskListComponent;

  ngOnInit(): void {
    const todayDate = new Date();
    this.today = this.formatDate(todayDate);

    const tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1); // Następny dzień

    // Ustawiamy domyślne daty na jutro
    this.startDate = this.formatDate(tomorrow);
    this.endDate = this.formatDate(tomorrow);

    // Pobierz lokalizacje z serwisu
    this.locationService.getLocations().subscribe(
      (locations: Location[]) => {
        this.locations = [{ id: 0, name: 'All Locations' }, ...locations];
      },
      (error) => {
        console.error('Error fetching locations:', error);
      }
    );
  }

  formatDate(date: Date): string {
    return date.toISOString().substring(0, 10); // Format YYYY-MM-DD
  }


  searchDesks(): void {
    // Przekazanie wartości do komponentu desk-list
    this.deskList.startDate = this.startDate;
    this.deskList.startTime = this.startTime;
    this.deskList.endDate = this.endDate;
    this.deskList.endTime = this.endTime;
    this.deskList.locationId = this.locationId;

    // Wywołanie metody loadDesks, aby odświeżyć wyniki
    this.deskList.loadDesks();
  }
}
