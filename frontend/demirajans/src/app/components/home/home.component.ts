import { Component } from '@angular/core';
import { CategoryDto } from '../../services/categories/models';
import { CategoryService } from '../../services/categories/category.service';
import { ProductService } from '../../services/products/product.service';
import { ProductDto } from '../../services/products/models';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';

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
  apiUrl!: string;
  //#endregion

  //#region Utils
  getProductListByAppearInFront() {
    this.productService.getListByAppearInFront(true).subscribe({
      next: (n) => (this.productList = n),
      error: (e) => console.log(e),
      // complete: () => ,
    });
  }

  getCategoryListByAppearInFront() {
    this.categoryService.getListByAppearInFront(true).subscribe({
      next: (n) => (this.categoryList = n),
      error: (e) => console.log(e),
      // complete: () => ,
    });
  }
  //#endregion

  //#region Ctor
  constructor(
    private router: Router,
    private productService: ProductService,
    private categoryService: CategoryService
  ) {}
  //#endregion

  //#region Methods
  ngOnInit() {
    this.apiUrl = environment.apiUrl;
    this.getCategoryListByAppearInFront();
    this.getProductListByAppearInFront();
  }

  getProductsByCategoryId(categoryId: number): ProductDto[] {
    return this.productList.filter((x) => x.categoryId === categoryId);
  }

  productOnClick(productId: number) {
    this.router.navigate(['product', productId]);
  }
  //#endregion
}
