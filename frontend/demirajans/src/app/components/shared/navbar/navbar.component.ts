import {
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild,
} from '@angular/core';

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
  searchButtonClicked: boolean = false;

  // searchContainer = document.querySelector('.search-container');
  @ViewChild('searchInput') searchInput!: ElementRef<HTMLInputElement>;
  @ViewChild('searchButton') searchButton!: ElementRef<HTMLButtonElement>;
  @ViewChild('searchContainer') searchContainer!: ElementRef<HTMLDivElement>;
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

  searchButtonOnClick() {
    if (this.searchInput.nativeElement.value === '') {
      this.searchButtonClicked = !this.searchButtonClicked;
      this.searchButton.nativeElement.classList.toggle('active');
      this.searchContainer.nativeElement.classList.toggle('active');
      if (this.searchButtonClicked) {
        this.searchInput.nativeElement.focus();
        this.searchInput.nativeElement.placeholder = 'Ürünlerde Ara';
      } else {
        this.searchInput.nativeElement.blur();
        this.searchInput.nativeElement.placeholder = '';
      }
    }
  }

  @HostListener('document:click', ['$event'])
  handleDocumentClick(event: MouseEvent) {
    const target = event.target as HTMLElement;

    if (!this.searchButton.nativeElement.contains(target)) {
      if (this.searchInput.nativeElement.value === '') {
        this.searchButtonClicked = false;
        this.searchButton.nativeElement.classList.remove('active');
        this.searchContainer.nativeElement.classList.remove('active');
        this.searchInput.nativeElement.blur();
        this.searchInput.nativeElement.placeholder = '';
      }
    }
  }
  //#endregion
}
