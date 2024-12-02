import { Component } from '@angular/core';
import { CategoryDto } from '../../services/categories/models';
import { CategoryService } from '../../services/categories/category.service';

@Component({
  selector: 'app-home',
  standalone: false,

  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  //#region Props
  categoryList!: CategoryDto[];
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
  //#endregion
}
