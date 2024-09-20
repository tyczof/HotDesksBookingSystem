import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { DeskListComponent } from './desk-list/desk-list.component';
import { RoleSwitchComponent } from './components/hot-desks/role-switch/role-switch.component';
import { MainScreenComponent } from './components/main-screen/main-screen.component';
import { HotDesksComponent } from './components/hot-desks/hot-desks.component';


const routes: Routes = [
  //{ path: 'desks', component: DeskListComponent },
  { path: '', component: HotDesksComponent  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
