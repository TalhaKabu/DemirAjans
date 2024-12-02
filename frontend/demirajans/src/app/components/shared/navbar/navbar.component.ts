import { Component, HostListener, OnInit } from '@angular/core';
import { CategoryService } from '../../../services/categories/category.service';
import { catchError, Observable, tap } from 'rxjs';
import { CategoryDto } from '../../../services/categories/models';

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

  categoryList!: CategoryDto[];
  //#endregion

  //#region Utils
  getCategoryListByAppearInFront() {
    this.categoryService.getListByAppearInFront(true).subscribe({
      next: (n) => (this.categoryList = n),
      error: (e) => console.log(e),
      complete: () => console.log(this.categoryList),
    });
  }
  //#endregion

  //#region Ctor
  constructor(private categoryService: CategoryService) {}
  //#endregion

  //#region Methods
  ngOnInit() {
    this.getCategoryListByAppearInFront();
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
