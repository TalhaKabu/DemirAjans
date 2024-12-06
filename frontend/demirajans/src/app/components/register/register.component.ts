import { Component } from '@angular/core';
import { takeWhile, tap, timer } from 'rxjs';
import { UserCreateDto } from '../../services/user/models';
import { ActivationService } from '../../services/activations/activation.service';
import {
  ActivationCreateDto,
  VerifyActivationDto,
} from '../../services/activations/models';

@Component({
  selector: 'app-register',
  standalone: false,

  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  //#region Fields
  activationSend: boolean = false;
  activated: boolean = false;

  counter: number = 180;
  counterStr: string = '3:00';
  stopTimer: boolean = false;

  userCreateDto: UserCreateDto = <UserCreateDto>{};
  activationCreateDto: ActivationCreateDto = <ActivationCreateDto>{};
  //#endregion

  //#region Utils
  sendActivationCode() {
    this.activationService
      .sendActivationCode(this.activationCreateDto)
      .subscribe({
        next: (n) => {
          this.activationSend = true;
          this.startTimer();
        },
        error: (e) => console.log(e),
      });
  }

  verifyActivationCode(verifyActivationDto: VerifyActivationDto) {
    this.activationService.verifyActivationCode(verifyActivationDto).subscribe({
      next: (n) => {
        this.activated = true;
        this.stopTimer = true;
      },
      error: (e) => console.log(e.error),
    });
  }
  //#endregion

  //#region Ctor
  constructor(private activationService: ActivationService) {}
  //#endregion

  //#region Methods
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
      // mail kontrolu
      this.activationCreateDto.expirationDate = new Date();
      this.activationCreateDto.expirationDate.setMinutes(
        this.activationCreateDto.expirationDate.getMinutes() + 3
      );
      this.sendActivationCode();
    } else {
      if (!this.activated) {
        // aktivasyon  dogrula
        this.verifyActivationCode(<VerifyActivationDto>{
          email: this.activationCreateDto.email,
          code: this.activationCreateDto.code,
        });
        // this.activated = true;
        // this.stopTimer = true;
      } else {
        console.log(this.userCreateDto);
        //create user
      }
    }
  }
  //#endregion
}
