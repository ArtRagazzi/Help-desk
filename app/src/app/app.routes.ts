import { Routes } from '@angular/router';
import { Login } from './pages/login/login.component';
import { Home } from './pages/home/home.component';


export const routes: Routes = [

  { path: 'login', component: Login },


  { path: 'home', component: Home },

  { path: '', redirectTo: '/login', pathMatch: 'full' },

  { path: '**', redirectTo: '/login' }
];
