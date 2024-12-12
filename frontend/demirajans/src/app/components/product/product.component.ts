import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ColorDto, ProductDto } from '../../services/products/models';
import { environment } from '../../../environments/environment';
import { ProductService } from '../../services/products/product.service';
import { CategoryDto } from '../../services/categories/models';

@Component({
  selector: 'app-product',
  standalone: false,

  templateUrl: './product.component.html',
  styleUrl: './product.component.scss',
})
export class ProductComponent implements OnInit {
  //#region Fields
  productId!: number;
  product!: ProductDto;
  selectedColor!: ColorDto;
  apiUrl!: string;
  categoryName!: string;
  //#endregion

  //#region Utils
  get() {
    this.productService.get(this.productId).subscribe({
      next: (n) => (
        (this.product = n),
        ((this.selectedColor = this.product.colors[0]),
        console.log(this.product))
      ),
      error: (e) => console.log(e),
    });
  }
  //#endregion

  //#region Ctor
  constructor(
    private activatedRoute: ActivatedRoute,
    private productService: ProductService
  ) {}
  //#endregion

  //#region Methods
  ngOnInit(): void {
    this.apiUrl = environment.apiUrl;
    this.activatedRoute.params.subscribe((params) => {
      this.productId = parseInt(params['id']);
      this.get();
    });

    this.activatedRoute.queryParamMap.subscribe((params) => {
      this.categoryName = params.get('categoryDto') + '';
    });
  }
  //#endregion
}
