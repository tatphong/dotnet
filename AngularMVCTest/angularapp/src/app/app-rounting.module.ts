import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
import { WeatherComponent } from './weather/weather.component';
import { AppComponent } from './app.component';


const routes: Routes = [
  //{
  //  path: '',
  //  component: AppComponent
  //},
  {
    path: 'user',
    component: UserComponent
  },
  {
    path: 'weather',
    component: WeatherComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRountingModule { }
