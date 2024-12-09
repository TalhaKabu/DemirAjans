import { Component } from '@angular/core';
import { CategoryDto } from '../../services/categories/models';
import { CategoryService } from '../../services/categories/category.service';
import { ProductService } from '../../services/products/product.service';
import { ProductDto } from '../../services/products/models';

@Component({
  selector: 'app-home',
  standalone: false,

  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  //#region Props
  productList!: ProductDto[];
  categoryList!: CategoryDto[];
  //#endregion

  //#region Utils
  getProductListByAppearInFront() {
    this.productService.getListByAppearInFront(true).subscribe({
      next: (n) => ((this.productList = n), console.log(n)),
      error: (e) => console.log(e),
      // complete: () => ,
    });
  }

  getCategoryListByAppearInFront() {
    this.categoryService.getListByAppearInFront(true).subscribe({
      next: (n) => ((this.categoryList = n), console.log(n)),
      error: (e) => console.log(e),
      // complete: () => ,
    });
  }
  //#endregion

  //#region Ctor
  constructor(
    private productService: ProductService,
    private categoryService: CategoryService
  ) {}
  //#endregion

  //#region Methods
  ngOnInit() {
    this.getCategoryListByAppearInFront();
    this.getProductListByAppearInFront();
  }

  getProductsByCategoryId(categoryId: number): ProductDto[] {
    return this.productList.filter((x) => x.categoryId === categoryId);
  }
  //#endregion
}
