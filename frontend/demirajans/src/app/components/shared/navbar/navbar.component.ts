import {
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild,
} from '@angular/core';
import { CategoryService } from '../../../services/categories/category.service';
import { CategoryDto } from '../../../services/categories/models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: false,

  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent implements OnInit {
  //#region Props
  categoryList!: CategoryDto[];

  searchButtonClicked: boolean = false;

  year: number = new Date().getFullYear();

  @ViewChild('sidebarBtn') sidebarBtn!: ElementRef<HTMLButtonElement>;
  @ViewChild('sidebar') sidebar!: ElementRef<HTMLDivElement>;

  @ViewChild('searchInput') searchInput!: ElementRef<HTMLInputElement>;
  @ViewChild('searchButton') searchButton!: ElementRef<HTMLButtonElement>;
  @ViewChild('searchContainer') searchContainer!: ElementRef<HTMLDivElement>;

  @ViewChild('footer') footer!: ElementRef<HTMLDivElement>;
  //#endregion

  //#region Utils
  getCategoryListByAppearInFront() {
    this.categoryService.getListByAppearInFront(true).subscribe({
      next: (n) => (this.categoryList = n),
      error: (e) => console.log(e),
      // complete: () => ,
    });
  }
  //#endregion

  //#region Ctor
  constructor(private categoryService: CategoryService) {}
  //#endregion

  //#region Methods
  ngOnInit() {
    this.getCategoryListByAppearInFront();
  }

  toggleSubMenu(button: HTMLButtonElement): void {
    if (!button.nextElementSibling!.classList.contains('show'))
      this.closeAllSubMenus();

    button.nextElementSibling!.classList.toggle('show');
    button.classList.toggle('rotate');

    if (this.sidebar.nativeElement.classList.contains('close')) {
      this.sidebar.nativeElement.classList.toggle('close');
      this.sidebarBtn.nativeElement.classList.toggle('rotate');
    }
  }

  toogleSidebar() {
    this.sidebar.nativeElement.classList.toggle('close');
    this.sidebarBtn.nativeElement.classList.toggle('rotate');
    this.footer.nativeElement.classList.toggle('close');

    this.closeAllSubMenus();
  }

  closeAllSubMenus() {
    Array.from(
      this.sidebar.nativeElement.getElementsByClassName('show')
    ).forEach((ul) => {
      ul.classList.remove('show');
      ul.previousElementSibling!.classList.remove('rotate');
    });
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

  liOnClick(link: HTMLLIElement, id?: number) {
    Array.from(
      this.sidebar.nativeElement.getElementsByClassName('active')
    ).forEach((li) => {
      li.classList.remove('active');
    });

    Array.from(
      this.sidebar.nativeElement.getElementsByClassName('active-dropdown')
    ).forEach((li) => {
      li.classList.remove('active-dropdown');
    });

    if (link.getElementsByTagName('span')[0].innerHTML === 'Kategoriler') {
      if (id !== undefined)
        Array.from(link.getElementsByTagName('li')).forEach((li) => {
          if (li.firstElementChild!.id === id!.toString()) {
            li.classList.add('active');
          } else {
            li.classList.remove('active');
          }
        });
    } else {
      link.classList.add('active');
    }
  }

  liDropdownOnClick(link: HTMLLIElement, id?: number) {
    Array.from(
      this.sidebar.nativeElement.getElementsByClassName('active')
    ).forEach((li) => {
      if (li.getElementsByTagName('span')[0].innerHTML === 'Kategoriler') {
        if (id !== undefined)
          Array.from(link.getElementsByTagName('li')).forEach((li) => {
            if (li.firstElementChild!.id === id!.toString()) {
              li.classList.add('active');
            } else {
              li.classList.remove('active');
            }
          });
      } else li.classList.remove('active');
    });

    Array.from(
      this.sidebar.nativeElement.getElementsByClassName('active-dropdown')
    ).forEach((li) => {
      li.classList.remove('active-dropdown');
    });

    link.classList.add('active-dropdown');
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
