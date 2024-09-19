import { Reservation } from "./reservation.model";

export interface Desk {
    id: number;
    deskNumber: string;
    isAvailable: boolean;
    locationId: number;
    locationName: string;
    isReservedOnDate: boolean;
    reservations?: Reservation[]
  }
  