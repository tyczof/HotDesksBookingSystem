import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Location } from '../models/location.model';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  private apiUrl = 'https://localhost:7183/api/Location';

  constructor(private http: HttpClient) {}
  
  getLocations(): Observable<Location[]> {
    return this.http.get<Location[]>(`${this.apiUrl}`);
  }
}
