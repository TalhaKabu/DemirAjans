import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { LoginDto } from '../../services/auth/models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,

  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  loginDto: LoginDto = <LoginDto>{};

  login() {
    this.authService
      .login(<LoginDto>{
        username: 'admin',
        password: 'admin1234',
      })
      .subscribe({
        next: (n) => (
          localStorage.setItem('token', n.token),
          localStorage.setItem('expiration', n.expiration.toString()),
          this.router.navigate([''])
        ),
        error: (e) => console.log(e),
      });
  }

  constructor(private authService: AuthService, protected router: Router) {}

  ngOnInit(): void {}
}
