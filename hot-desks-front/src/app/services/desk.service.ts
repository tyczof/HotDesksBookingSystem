import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Desk } from '../models/desk.model';

@Injectable({
  providedIn: 'root'
})
export class DeskService {
  private apiUrl = 'https://localhost:7183/api/Desk';

  constructor(private http: HttpClient) {}

  getDesks(startDate: string, endDate: string, locationId: number = 0): Observable<Desk[]> {
    let params = new HttpParams()
      .set('startDate', startDate)
      .set('endDate', endDate);
  
    if (locationId) {
      params = params.set('locationId', locationId);
    }
    return this.http.get<Desk[]>(this.apiUrl + '/available', { params });
  }

  addDesk(desk: Desk): Observable<Desk> {
    return this.http.post<Desk>(`${this.apiUrl}`, desk);
  }

  deleteDesk(id?: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  toggleDeskAvailability(id?: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/changeavailability/${id}`, {});
  }
}
