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
  loginErrMsg: string = '';

  login() {
    this.authService.login(this.loginDto).subscribe({
      next: (n) => (
        localStorage.setItem('token', n.token), this.router.navigate([''])
      ),
      error: (e) => {
        console.log(e);
        if (e.status === 401) {
          this.loginErrMsg = 'Kullanıcı adı veya şifre yanlış.';
        }
      },
    });
  }

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  register() {
    this.router.navigate(['/register']);
  }
}
