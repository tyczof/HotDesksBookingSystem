import { Component, Input, OnInit } from '@angular/core';
import { Desk } from '../../../../models/desk.model';
import { ReservationService } from '../../../../services/reservation.service'; // Serwis do rezerwacji
import { Reservation } from '../../../../models/reservation.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Employee } from '../../../../models/employee.model';
import { EmployeeService } from '../../../../services/employee.service';

@Component({
  selector: 'app-desk-item',
  templateUrl: './desk-item.component.html',
  styleUrls: ['./desk-item.component.css']
})
export class DeskItemComponent implements OnInit {
  @Input() desk!: Desk;
  @Input() employee!: Employee;
  @Input() startDate!: string; 
  @Input() endDate!: string; 

  errorMessage: string = '';

  constructor(
    private reservationService: ReservationService,
    private employeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    if (this.desk.reservations && this.desk.reservations.length > 0) {
      this.desk.reservations.forEach(reservation => {
        if (!reservation.employeeName) {
          this.employeeService.getEmployee(reservation.employeeId).subscribe({
            next: (e) => {
              reservation.employeeName = e.firstName + " " + e.lastName;
            },
            error: (error: HttpErrorResponse) => {
              this.errorMessage = 'Unable to fetch employee details';
            }
          });
        }
      });
    }
  }

  reserveDesk(): void {
    const deskId = this.desk.id !== undefined ? this.desk.id : 0;
    if (!this.desk.isReservedOnDate) {
      const reservation: Reservation = {
        deskId: deskId,
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
