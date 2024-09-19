import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-mode-switch',
  templateUrl: './mode-switch.component.html',
  styleUrl: './mode-switch.component.css'
})
export class ModeSwitchComponent {
  isActive = false

  @Output() modeChange = new EventEmitter<boolean>();

  changeScreen() {
    this.isActive = !this.isActive;
    this.modeChange.emit(this.isActive);
  }
}
