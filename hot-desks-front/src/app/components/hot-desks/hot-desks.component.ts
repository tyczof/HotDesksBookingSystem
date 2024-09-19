import { Component, ViewChild } from '@angular/core';
import { LocationService } from '../../services/location.service';
import { Location } from '../../models/location.model';

@Component({
  selector: 'app-hot-desks',
  templateUrl: './hot-desks.component.html',
  styleUrl: './hot-desks.component.css'
})
export class HotDesksComponent {
  employeeId: number = 1;
  isActive = false;

  onModeChange(isActive: boolean) {
    this.isActive = isActive;
  }

  onEmployeeIdChange(newEmployeeId: number): void {

    this.employeeId = newEmployeeId;
    
  }
}
