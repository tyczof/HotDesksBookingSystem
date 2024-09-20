import { Desk } from "./desk.model";

export interface Location {
    id: number;
    name: string;
    desks?: Desk[]
  }
  