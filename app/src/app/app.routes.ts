import { Routes } from '@angular/router';


import { rotaGuard } from './autenticacao/rota-guard';
import { Login } from './pages/login/login.component';
import { Home } from './pages/home/home.component';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: '', component: Home }
]