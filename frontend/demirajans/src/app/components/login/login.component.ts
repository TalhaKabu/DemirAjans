import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { LoginDto } from '../../services/auth/models';

@Component({
  selector: 'app-login',
  standalone: false,

  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    // this.authService
    //   .login(<LoginDto>{
    //     username: 'admin',
    //     password: 'admin1234',
    //   })
    //   .subscribe({
    //     next: (n) => (
    //       console.log(n),
    //       localStorage.setItem('token', n.token),
    //       localStorage.setItem('expiration', n.expiration.toUTCString())
    //     ),
    //     error: (e) => console.log(e),
    //   });
  }
}
