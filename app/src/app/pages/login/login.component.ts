import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class Login {

  loginObj: LoginModel = new LoginModel();
  loginStatusMessage = signal<string | null>(null); // Sinal para a mensagem de status

  constructor(private router: Router) { }

  onLogin() {
    this.loginStatusMessage.set(null); // Limpa a mensagem anterior

    // CORREÇÃO AQUI: Use uma chave genérica para a lista de usuários
    const localUser = localStorage.getItem('angular17users'
    );

    if (localUser != null) {
      const users = JSON.parse(localUser); // Agora isso vai funcionar se 'angular17users' tiver um array JSON

      const isUserPresent = users.find((user: SingUpModel) => user.email === this.loginObj.email && user.password === this.loginObj.password);

      if (isUserPresent !== undefined) {
        this.loginStatusMessage.set("Usuário encontrado! Redirecionando...");
        localStorage.setItem('loggedUser', JSON.stringify(isUserPresent));
        this.router.navigateByUrl('/home');
      } else {
        this.loginStatusMessage.set("Nenhum usuário encontrado. Por favor, tente novamente.");
      }
    } else {
      this.loginStatusMessage.set("Nenhum usuário encontrado. Por favor, tente novamente.");
    }
  }
}

export class LoginModel {
  email: string;
  password: string;

  constructor() {
    this.email = "";
    this.password = ""
  }
}

export class SingUpModel {
  email: string;
  password: string;

  constructor() {
    this.email = "";
    this.password = ""
  }
}
