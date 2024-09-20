export interface Reservation {
    id?: number;
    deskId: number;
    deskNumber?: string;
    deskLocationName?: string;
    employeeId: number;
    employeeName?: string;
    employeeEmail?: string;
    startDate: Date;
    endDate: Date;
    reservationStatus?: string;
  }
  