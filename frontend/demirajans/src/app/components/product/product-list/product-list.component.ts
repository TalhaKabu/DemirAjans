import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../services/products/product.service';
import { ProductDto } from '../../../services/products/models';
import { environment } from '../../../../environments/environment';
import { CategoryDto } from '../../../services/categories/models';

@Component({
  selector: 'app-product-list',
  standalone: false,

  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent implements OnInit {
  //#region Fields
  selectedCategoryId: number = 0;
  selectedSubCategoryId: number = 0;
  apiUrl!: string;

  productList!: ProductDto[];
  @Input() categoryList!: CategoryDto[];
  //#endregion

  //#region Utils
  getProductListByAppearInFront() {
    this.productService.getListByAppearInFront(true).subscribe({
      next: (n) => (this.productList = n),
      error: (e) => console.log(e),
    });
  }

  getListByCategoryIdAndSubCategoryId() {
    this.productService
      .getListByCategoryIdAndSubCategoryId(
        this.selectedCategoryId,
        this.selectedSubCategoryId
      )
      .subscribe({
        next: (n) => (this.productList = n),
        error: (e) => console.log(e),
      });
  }
  //#endregion

  //#region Ctor
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private productService: ProductService
  ) {}
  //#endregion

  //#region Methods
  ngOnInit(): void {
    this.apiUrl = environment.apiUrl;
    this.activatedRoute.params.subscribe((params) => {
      this.selectedCategoryId = parseInt(params['id']);
      this.selectedSubCategoryId =
        params['sid'] !== undefined ? parseInt(params['sid']) : 0;
      if (this.selectedCategoryId === 0) this.getProductListByAppearInFront();
      else this.getListByCategoryIdAndSubCategoryId();
    });
  }

  productOnClick(productId: number) {
    this.router.navigate(['product', productId], {
      queryParams: {
        categoryDto: this.categoryList.find(
          (x) =>
            x.id == this.productList.find((x) => x.id === productId)!.categoryId
        )!.name,
      },
    });
  }
  //#endregion
}
