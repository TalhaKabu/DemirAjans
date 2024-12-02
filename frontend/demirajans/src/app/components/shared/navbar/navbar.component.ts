import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  standalone: false,

  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent implements OnInit {
  //#region Props
  firstToolbarRowMobile: boolean = false;
  innerWidth: any;
  //#endregion

  //#region Utils
  //#endregion

  //#region Ctor
  //#endregion

  //#region Methods
  ngOnInit() {
    this.innerWidth = window.innerWidth;
    if (this.innerWidth < 768) this.firstToolbarRowMobile = true;
    else this.firstToolbarRowMobile = false;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: Event) {
    this.innerWidth = (event.target as Window).innerWidth;
    if (this.innerWidth < 768) this.firstToolbarRowMobile = true;
    else this.firstToolbarRowMobile = false;
  }
  //#endregion
}
