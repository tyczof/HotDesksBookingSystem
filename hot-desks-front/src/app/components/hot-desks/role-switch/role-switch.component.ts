import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from '../../../models/employee.model';

@Component({
  selector: 'app-role-switch',
  templateUrl: './role-switch.component.html',
  styleUrls: ['./role-switch.component.css']
})
export class RoleSwitchComponent {
  @Input() isAdmin!: boolean;

  @Input() employee!: Employee;

  @Output() employeeChange = new EventEmitter<number>();

  toggleRole() {
    console.log('Role switched to:', !this.isAdmin ? 'Admin' : 'Employee');
    if (this.isAdmin)
    {
      this.employeeChange.emit(1)
    }
    else
    {
      this.employeeChange.emit(2);
    }
    this.isAdmin = !this.isAdmin
  }
}
