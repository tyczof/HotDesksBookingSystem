import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoleSwitchComponent } from './components/main-screen/role-switch/role-switch.component';
import { MainScreenComponent } from './components/main-screen/main-screen.component';
import { DeskListComponent } from './components/main-screen/desk-list/desk-list.component';
import { DeskItemComponent } from './components/main-screen/desk-list/desk-item/desk-item.component';

@NgModule({
  declarations: [
    AppComponent,
    RoleSwitchComponent,
    MainScreenComponent,
    DeskListComponent,
    DeskItemComponent
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
