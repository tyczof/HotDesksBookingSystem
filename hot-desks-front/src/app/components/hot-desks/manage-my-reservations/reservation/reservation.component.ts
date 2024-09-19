import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Reservation } from '../../../../models/reservation.model';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent {
  @Input() reservation!: Reservation;
  @Output() onCancel = new EventEmitter<number>();
  @Output() onModify = new EventEmitter<number>();

  get isUpcoming(): boolean {
    return this.reservation.reservationStatus === 'Upcoming';
  }

  get isCancelled(): boolean {
    return this.reservation.reservationStatus === 'Cancelled';
  }

  get canModifyOrCancel(): boolean {
    return this.isUpcoming && !this.isCancelled;
  }

  cancel(): void {
    if (this.isUpcoming && !this.isCancelled) {
      this.onCancel.emit(this.reservation.id);
    }
  }

  modify(): void {
    if (this.isUpcoming && !this.isCancelled) {
      this.onModify.emit(this.reservation.id);
    }
  }
}
