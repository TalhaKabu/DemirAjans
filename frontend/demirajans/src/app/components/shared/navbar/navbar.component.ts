import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-navbar',
  standalone: false,

  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent implements OnInit {
  //#region Props
  openMenuIndex: number | null = null;

  @ViewChild('sidebarBtn') sidebarBtn!: ElementRef<HTMLButtonElement>;
  @ViewChild('sidebar') sidebar!: ElementRef<HTMLDivElement>;
  //#endregion

  //#region Utils
  //#endregion

  //#region Ctor
  //#endregion

  //#region Methods
  ngOnInit() {}

  toggleSubMenu(index: number): void {
    this.openMenuIndex = this.openMenuIndex === index ? null : index;

    if (this.sidebar.nativeElement.classList.contains('close')) {
      this.sidebar.nativeElement.classList.toggle('close');
      this.sidebarBtn.nativeElement.classList.toggle('rotate');
    }
  }

  toogleSidebar() {
    this.sidebar.nativeElement.classList.toggle('close');
    this.sidebarBtn.nativeElement.classList.toggle('rotate');

    Array.from(
      this.sidebar.nativeElement.getElementsByClassName('show')
    ).forEach((ul) => {
      ul.classList.remove('show');
      ul.previousElementSibling!.classList.remove('rotate');
    });
  }
  //#endregion
}
