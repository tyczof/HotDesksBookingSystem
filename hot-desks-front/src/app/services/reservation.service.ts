import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Reservation } from '../models/reservation.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private apiUrl = 'https://localhost:7183/api/Reservation';

  constructor(private http: HttpClient) {}

  getReservations(employeeId: number): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(`${this.apiUrl}/employee/${employeeId}`);
  }

  cancelReservation(id?: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/cancel/${id}`, {});
  }

  addReservation(reservation: Reservation): Observable<Reservation> {
    return this.http.post<Reservation>(`${this.apiUrl}`, reservation);
  }

}
