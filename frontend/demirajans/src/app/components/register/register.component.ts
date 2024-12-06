import { Component } from '@angular/core';
import { takeWhile, tap, timer } from 'rxjs';
import { UserCreateDto } from '../../services/user/models';

@Component({
  selector: 'app-register',
  standalone: false,

  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  activationSend: boolean = false;
  activated: boolean = false;

  counter: number = 180;
  counterStr: string = '3:00';
  stopTimer: boolean = false;

  userCreateDto: UserCreateDto = <UserCreateDto>{};

  constructor() {}

  startTimer() {
    timer(1000, 1000)
      .pipe(
        takeWhile(() => this.counter >= 0 && !this.stopTimer),
        tap(() => {
          this.counter--;
          this.formatCounter(this.counter);
        })
      )
      .subscribe(() => {
        //add you more code
      });
  }

  formatCounter(counter: number) {
    this.counterStr = Math.floor(this.counter / 60) + ':' + (this.counter % 60);
  }

  buttonOnClick() {
    if (!this.activationSend) {
      //aktivasyon kodu gonder
      this.activationSend = true;
      this.startTimer();
    } else {
      if (!this.activated) {
        // aktivasyon  dogrula
        this.activated = true;
        this.stopTimer = true;
      } else {
        console.log(this.userCreateDto);
        //create user
      }
    }
  }
}
