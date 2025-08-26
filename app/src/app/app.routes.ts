import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Home } from './pages/home/home';
import { rotaGuard } from './autenticacao/rota-guard';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'home', component: Home, canActivate: [rotaGuard] },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];
