import { Component, OnInit, Input } from '@angular/core';
import { DeskService } from '../../../services/desk.service';
import { Desk } from '../../../models/desk.model';

@Component({
  selector: 'app-desk-list',
  templateUrl: './desk-list.component.html',
  styleUrls: ['./desk-list.component.css']
})
export class DeskListComponent implements OnInit {
  desks: Desk[] = [];
  @Input() startDate: string = '';
  @Input() startTime: string = '';
  @Input() endDate: string = '';
  @Input() endTime: string = '';
  @Input() locationId: number = 0;
  @Input() employeeId!: number;

  constructor(private deskService: DeskService) {}

  ngOnInit(): void {
    this.loadDesks();
  }


  formatDateTime(date: string, time: string): string {
    const fullDate = new Date(`${date}T${time}:00.000Z`); 


    const year = fullDate.getFullYear();
    const month = String(fullDate.getMonth() + 1).padStart(2, '0');
    const day = String(fullDate.getDate()).padStart(2, '0');
    const hours = String(fullDate.getHours()).padStart(2, '0');
    const minutes = String(fullDate.getMinutes()).padStart(2, '0');
    const seconds = String(fullDate.getSeconds()).padStart(2, '0');
    const milliseconds = String(fullDate.getMilliseconds()).padStart(3, '0');

    return `${year}-${month}-${day}T${hours}:${minutes}:${seconds}.${milliseconds}`;
  }

  loadDesks(): void {
    const startDateTime = this.formatDateTime(this.startDate, this.startTime);
    const endDateTime = this.formatDateTime(this.endDate, this.endTime);
    console.log(this.locationId)
    this.deskService.getDesks(startDateTime, endDateTime, this.locationId).subscribe(
      (desks: Desk[]) => {
        this.desks = desks;
      },
      (error) => {
        console.error('Error fetching desks:', error);
      }
    );
  }
}
