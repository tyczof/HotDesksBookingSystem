import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-mode-switch',
  templateUrl: './mode-switch.component.html',
  styleUrls: ['./mode-switch.component.css']
})
export class ModeSwitchComponent {
  @Input() isAdmin = false;
  @Input() activeScreen: string = 'main';

  @Output() modeChange = new EventEmitter<string>();

  get isMyReservationsActive(): boolean {
    return this.activeScreen === 'myReservations';
  }

  get isAdminManagementActive(): boolean {
    return this.activeScreen === 'adminManagement';
  }

  changeScreenMyReservations(): void {
    if (this.isMyReservationsActive || this.isAdminManagementActive) {
      this.activeScreen = 'main';
    } else {
      this.activeScreen = 'myReservations';
    }
    this.modeChange.emit(this.activeScreen);
  }

  changeScreenAdminManagement(): void {
    this.activeScreen = 'adminManagement';
    this.modeChange.emit(this.activeScreen);
  }
}
