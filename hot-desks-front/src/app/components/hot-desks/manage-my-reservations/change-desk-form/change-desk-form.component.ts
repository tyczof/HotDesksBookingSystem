import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { DeskService } from '../../../../services/desk.service';
import { Desk } from '../../../../models/desk.model';
import { Reservation } from '../../../../models/reservation.model';

@Component({
  selector: 'app-change-desk-form',
  templateUrl: './change-desk-form.component.html',
  styleUrls: ['./change-desk-form.component.css']
})
export class ChangeDeskFormComponent implements OnInit {
  @Input() reservation!: Reservation;
  @Input() showForm!: boolean;
  @Output() onDeskChange = new EventEmitter<number>();
  @Output() onActionCancel = new EventEmitter<void>();


  availableDesks: Desk[] = [];
  selectedDeskId!: number;

  constructor(private deskService: DeskService) {}

  ngOnInit(): void {
    this.showForm=true;
    this.loadAvailableDesks();
  }

  loadAvailableDesks(): void {
    console.log(this.reservation.startDate)
    let startDate: string = this.reservation.startDate.toString();
    let endDate: string = this.reservation.endDate.toString();
    this.deskService.getDesks(startDate, endDate).subscribe(
      (desks) => {
        this.availableDesks = desks;
      },
      (error) => {
        console.error('Error loading available desks', error);
      }
    );
  }

  changeDesk(): void {
    if (this.selectedDeskId) {
      this.onDeskChange.emit(this.selectedDeskId);
    } else {
      console.warn('No desk selected');
    }
  }
  cancelAction(): void {
    this.onActionCancel.emit();
    this.showForm=false;
  }
}
