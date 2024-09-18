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

  getDesks(startDate: string, endDate: string, locationId: number): Observable<Desk[]> {
    let params = new HttpParams()
      .set('startDate', startDate)
      .set('endDate', endDate);
  
    if (locationId) {
      params = params.set('locationId', locationId);
    }
    console.log(locationId);
    return this.http.get<Desk[]>(this.apiUrl + '/available', { params });
  }
  
}
