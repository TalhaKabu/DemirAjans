import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CategoryService } from '../../../services/categories/category.service';
import { CategoryDto } from '../../../services/categories/models';

@Component({
  selector: 'app-navbar',
  standalone: false,

  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent implements OnInit {
  //#region Props
  categoryList!: CategoryDto[];
  openMenuIndex: number | null = null;
  openMenuIndex2: number | null = null;

  @ViewChild('sidebarBtn') sidebarBtn!: ElementRef<HTMLButtonElement>;
  @ViewChild('sidebar') sidebar!: ElementRef<HTMLDivElement>;
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
  //#endregion
}
