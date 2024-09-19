import { Component, Input, ViewChild } from '@angular/core';
import { LocationService } from '../../services/location.service';
import { Location } from '../../models/location.model';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-hot-desks',
  templateUrl: './hot-desks.component.html',
  styleUrl: './hot-desks.component.css'
})
export class HotDesksComponent {
  employee!: Employee;
  isActive = false;

  
  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.loadEmployee(1);
  }

  loadEmployee(employeeId: number): void {
    this.employeeService.getEmployee(employeeId).subscribe(
      (employee) => {
        this.employee = employee;
      },
      (error) => {
        console.error('Error fetching reservations', error);
      }
    );
  }

  onModeChange(isActive: boolean) {
    this.isActive = isActive;
  }

  onEmployeeChange(newEmployeeId: number): void {
    this.loadEmployee(newEmployeeId);
  }
}
