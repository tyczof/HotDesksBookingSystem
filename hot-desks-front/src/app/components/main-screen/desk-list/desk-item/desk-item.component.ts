import { Component, Input } from '@angular/core';
import { Desk } from '../../../../models/desk.model';
import { ReservationService } from '../../../../services/reservation.service'; // Serwis do rezerwacji
import { Reservation } from '../../../../models/reservation.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Employee } from '../../../../models/employee.model';

@Component({
  selector: 'app-desk-item',
  templateUrl: './desk-item.component.html',
  styleUrls: ['./desk-item.component.css']
})
export class DeskItemComponent {
  @Input() desk!: Desk;
  @Input() employee!: Employee;
  @Input() startDate!: string; 
  @Input() endDate!: string; 

  errorMessage: string = '';

  constructor(private reservationService: ReservationService) {}

  reserveDesk(): void {

    if (!this.desk.isReservedOnDate) {
      const reservation: Reservation = {
        deskId: this.desk.id,
        employeeId: this.employee.id,
        startDate: new Date(this.startDate),
        endDate: new Date(this.endDate)
      };

      this.reservationService.addReservation(reservation).subscribe({
        next: (response) => {
          console.log(`Desk ${this.desk.deskNumber} reserved successfully!`);
          this.desk.isReservedOnDate = true;
          this.errorMessage='';
        },
        error: (error: HttpErrorResponse) => {
          if (error.error instanceof ErrorEvent) {
            // Klient-side error
            this.errorMessage = 'An error occurred: ' + error.error.message;
          } else {
            // Server-side error
            this.errorMessage = error.error;
          }
        }
      });
    }
  }
}
