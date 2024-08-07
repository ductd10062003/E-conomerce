import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './page/home/home.component';
import { DashBoardComponent } from './admin/dash-board/dash-board.component';
import { AbcComponent } from './abc/abc.component';

const routes: Routes = [

  {path: 'home', component: HomeComponent},
  {path: 'admin/dash-board', component: DashBoardComponent},
  {path: 'test', component:AbcComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
