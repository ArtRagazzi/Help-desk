import { Component, signal } from '@angular/core';

import { RouterModule, RouterOutlet } from '@angular/router';

import { Login } from "./pages/login/login.component";
import { FormsModule } from '@angular/forms';





@Component({

  selector: 'app-root',

  standalone: true,

  imports: [
    Login,
    FormsModule,
    RouterModule
  ],

  templateUrl: './app.html',

  styleUrl: './app.scss'

})

export class App {



}