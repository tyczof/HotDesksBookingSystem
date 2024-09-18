import { Component, Input } from '@angular/core';
import { Desk } from '../../../../models/desk.model';
import { ReservationService } from '../../../../services/reservation.service'; // Serwis do rezerwacji
import { Reservation } from '../../../../models/reservation.model';

@Component({
  selector: 'app-desk-item',
  templateUrl: './desk-item.component.html',
  styleUrls: ['./desk-item.component.css']
})
export class DeskItemComponent {
  @Input() desk!: Desk;
  @Input() employeeId!: number;
  @Input() startDate!: string; 
  @Input() endDate!: string; 

  constructor(private reservationService: ReservationService) {}

  reserveDesk(): void {
    console.log(this.startDate + ' ' + this.endDate + ' ' + this.employeeId + ' ' + this.desk.id)
    if (!this.desk.isReservedOnDate) {
      const reservation: Reservation = {
        deskId: this.desk.id,
        employeeId: this.employeeId,
        startDate: new Date(this.startDate),
        endDate: new Date(this.endDate)
      };

      this.reservationService.addReservation(reservation).subscribe({
        next: (response) => {
          console.log(`Desk ${this.desk.deskNumber} reserved successfully!`);
          this.desk.isReservedOnDate = true;
        },
        error: (error) => {
          console.error('Error during reservation:', error);
        }
      });
    }
  }
}
