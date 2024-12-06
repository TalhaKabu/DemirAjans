import { Component } from '@angular/core';
import { takeWhile, tap, timer } from 'rxjs';
import { UserCreateDto } from '../../services/user/models';
import { ActivationService } from '../../services/activations/activation.service';
import {
  ActivationCreateDto,
  VerifyActivationDto,
} from '../../services/activations/models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: false,

  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  //#region Fields
  activationSend: boolean = false;
  activatinSendAgain: boolean = false;
  activationSendErrMsg: string = '';
  verifyActivation: boolean = false;
  verifyActivationErrMsg: string = '';

  isEmailValid: boolean = true;

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
          this.activatinSendAgain = false;
          this.startTimer();
          this.activationSendErrMsg = '';
          this.verifyActivationErrMsg = '';
        },
        error: (e) => {
          this.activationSendErrMsg =
            'Aktivasyon kodu gönderilemedi, lütfen maili kontrol ediniz.';
        },
      });
  }

  verifyActivationCode(verifyActivationDto: VerifyActivationDto) {
    this.activationService.verifyActivationCode(verifyActivationDto).subscribe({
      next: (n) => {
        this.verifyActivation = true;
        this.stopTimer = true;
      },
      error: (e) => {
        if (e.status === 404) {
          this.verifyActivationErrMsg =
            'Mail adresi bulunamadı, lütfen kontrol edip tekrar deneyiniz.';
        } else if (e.status === 408) {
          this.verifyActivationErrMsg =
            'Aktivasyon süresi doldu, lütfen tekrar deneyiniz.';
          this.activatinSendAgain = true;
          this.stopTimer = true;
          this.counterStr = '3:00';
        } else if (e.status === 409) {
          this.verifyActivationErrMsg =
            'Aktivasyon kodu yanlış, lütfen kontrol edip tekrar deneyiniz.';
        }
      },
    });
  }
  //#endregion

  //#region Ctor
  constructor(
    private router: Router,
    private activationService: ActivationService
  ) {}
  //#endregion

  //#region Methods
  startTimer() {
    this.stopTimer = false;
    this.counterStr = '3:00';
    timer(1000, 1000)
      .pipe(
        takeWhile(() => this.counter > 0 && !this.stopTimer),
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
    this.counterStr =
      Math.floor(this.counter / 60) +
      ':' +
      (this.counter % 60 < 10 ? '0' + (this.counter % 60) : this.counter % 60);
  }

  buttonOnClick() {
    if (!this.activationSend) {
      if (this.isEmailValid) {
        this.activationCreateDto.expirationDate = new Date();
        this.activationCreateDto.expirationDate.setMinutes(
          this.activationCreateDto.expirationDate.getMinutes() +
            this.counter / 60
        );
        this.sendActivationCode();
      }
    } else {
      if (!this.activatinSendAgain) {
        if (!this.verifyActivation) {
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
      } else {
        this.activationCreateDto.expirationDate = new Date();
        this.activationCreateDto.expirationDate.setMinutes(
          this.activationCreateDto.expirationDate.getMinutes() +
            this.counter / 60
        );
        this.sendActivationCode();
      }
    }
  }

  backButtonOnClick() {
    this.router.navigate(['/login']);
  }

  validateEmail = () => {
    this.isEmailValid = String(this.activationCreateDto.email)
      .toLowerCase()
      .match(
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      )
      ? true
      : false;

    if (this.isEmailValid) this.activationSendErrMsg = '';
    else this.activationSendErrMsg = 'Lütfen maili kontrol ediniz.';
  };
  //#endregion
}
