import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoleSwitchComponent } from './components/hot-desks/role-switch/role-switch.component';
import { MainScreenComponent } from './components/main-screen/main-screen.component';
import { DeskListComponent } from './components/main-screen/desk-list/desk-list.component';
import { DeskItemComponent } from './components/main-screen/desk-list/desk-item/desk-item.component';
import { ModeSwitchComponent } from './components/hot-desks/mode-switch/mode-switch.component';
import { ManageMyReservationsComponent } from './components/hot-desks/manage-my-reservations/manage-my-reservations.component';
import { HotDesksComponent } from './components/hot-desks/hot-desks.component';
import { ReservationComponent } from './components/hot-desks/manage-my-reservations/reservation/reservation.component';
import { ChangeDeskFormComponent } from './components/hot-desks/manage-my-reservations/change-desk-form/change-desk-form.component';

@NgModule({
  declarations: [
    AppComponent,
    RoleSwitchComponent,
    MainScreenComponent,
    DeskListComponent,
    DeskItemComponent,
    ModeSwitchComponent,
    ManageMyReservationsComponent,
    HotDesksComponent,
    ReservationComponent,
    ChangeDeskFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
