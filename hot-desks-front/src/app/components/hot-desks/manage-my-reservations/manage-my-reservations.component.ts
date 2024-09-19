import { Component, OnInit } from '@angular/core';
import { Reservation } from '../../../models/reservation.model';
import { ReservationService } from '../../../services/reservation.service';

@Component({
  selector: 'app-manage-my-reservations',
  templateUrl: './manage-my-reservations.component.html',
  styleUrl: './manage-my-reservations.component.css'
})
export class ManageMyReservationsComponent implements OnInit {
  reservations: Reservation[] = [];
  employeeId = 1;

  constructor(private reservationService: ReservationService) {}

  ngOnInit(): void {
    this.loadReservations();
  }

  loadReservations(): void {
    this.reservationService.getReservations(this.employeeId).subscribe(
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
}