import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-role-switch',
  templateUrl: './role-switch.component.html',
  styleUrls: ['./role-switch.component.css']
})
export class RoleSwitchComponent {
  isAdmin = false;
  employeeId = 1;

  @Output() employeeIdChange = new EventEmitter<number>();

  toggleRole() {
    console.log('Role switched to:', this.isAdmin ? 'Admin' : 'Employee');
    this.isAdmin = !this.isAdmin;
    if (this.isAdmin)
    {
      this.employeeId = 2
    }
    else
    {
      this.employeeId = 1
    }
    this.employeeIdChange.emit(this.employeeId);
  }
}
