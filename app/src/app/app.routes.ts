import { Routes } from '@angular/router';
import { Login } from './login/login';
import { Home } from './home/home';
import { rotaGuard } from './autenticacao/rota-guard';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'home', component: Home, canActivate: [rotaGuard] },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];
