import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../services/products/product.service';
import { ProductDto } from '../../services/products/models';

@Component({
  selector: 'app-product-list',
  standalone: false,

  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent implements OnInit {
  selectedCategoryId: number = 0;
  selectedSubCategoryId: number = 0;

  productList!: ProductDto[];

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

  constructor(
    private activatedRoute: ActivatedRoute,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.selectedCategoryId = parseInt(params['id']);
      this.selectedSubCategoryId =
        params['sid'] !== undefined ? parseInt(params['sid']) : 0;
      if (this.selectedCategoryId === 0) this.getProductListByAppearInFront();
      else this.getListByCategoryIdAndSubCategoryId();
    });
  }
}
