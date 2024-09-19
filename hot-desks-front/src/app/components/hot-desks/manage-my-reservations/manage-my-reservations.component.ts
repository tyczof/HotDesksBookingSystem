import { Component, Input, OnInit } from '@angular/core';
import { Reservation } from '../../../models/reservation.model';
import { ReservationService } from '../../../services/reservation.service';
import { Employee } from '../../../models/employee.model';

@Component({
  selector: 'app-manage-my-reservations',
  templateUrl: './manage-my-reservations.component.html',
  styleUrl: './manage-my-reservations.component.css'
})
export class ManageMyReservationsComponent implements OnInit {
  reservations: Reservation[] = [];
  @Input() employee!: Employee;

  constructor(private reservationService: ReservationService) {}

  ngOnInit(): void {
    this.loadReservations();
  }

  loadReservations(): void {
    this.reservationService.getReservations(this.employee.id).subscribe(
      (reservations) => {
        this.reservations = reservations;
      },
      (error) => {
        console.error('Error fetching reservations', error);
      }
    );
  }

  cancelReservation(id?: number): void {
    const confirmed = window.confirm('Are you sure you want to cancel this reservation?');
    
    if (confirmed) {
      this.reservationService.cancelReservation(id).subscribe(
        () => {
          this.reservations = this.reservations.filter(reservation => reservation.id !== id);
        },
        (error) => {
          console.error('Error canceling reservation', error);
        }
      );
    }
  }
  changeDesk(reservation: Reservation, deskId: number): void {
    const updatedReservation: Reservation = {
      ...reservation,
      deskId: deskId
    };
  
    this.reservationService.updateReservationDesk(reservation.id!, updatedReservation).subscribe(
      () => {
        this.loadReservations();
      },
      (error) => {
        console.error('Error updating reservation desk', error);
      }
    );
  }  
}