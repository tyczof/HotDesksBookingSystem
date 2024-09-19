import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Employee } from '../../../models/employee.model';

@Component({
  selector: 'app-role-switch',
  templateUrl: './role-switch.component.html',
  styleUrls: ['./role-switch.component.css']
})
export class RoleSwitchComponent {
  employee!: Employee;
  isAdmin = false;

  @Output() employeeChange = new EventEmitter<number>();

  toggleRole() {
    console.log('Role switched to:', this.isAdmin ? 'Admin' : 'Employee');
    if (this.isAdmin)
    {
      this.employeeChange.emit(1)
    }
    else
    {
      this.employeeChange.emit(2);
    }
  }
}
