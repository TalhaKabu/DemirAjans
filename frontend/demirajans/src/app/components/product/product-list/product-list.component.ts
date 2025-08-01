import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
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

  @ViewChild('grid') grid!: ElementRef<HTMLDivElement>;
  //#endregion

  //#region Utils
  getProductListByAppearInFront() {
    this.productService.getListByAppearInFront(true).subscribe({
      next: (n) => (
        (this.productList = n),
        this.productList.forEach((x) => (x.selectedColor = x.colors[0]))
      ),
      error: (e) => console.log(e),
    });
  }

  getProductListByCategoryIdAndAppearInFront() {
    this.productService
      .getListByCategoryIdAndAppearInFront(this.selectedCategoryId, true)
      .subscribe({
        next: (n) => (
          (this.productList = n),
          this.productList.forEach((x) => (x.selectedColor = x.colors[0]))
        ),
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
        next: (n) => (
          (this.productList = n),
          this.productList.forEach((x) => (x.selectedColor = x.colors[0]))
        ),
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
      this.selectedCategoryId = Number.isNaN(parseInt(params['id']))
        ? this.categoryList[0].id
        : parseInt(params['id']);
      this.selectedSubCategoryId =
        params['sid'] !== undefined ? parseInt(params['sid']) : 0;

      if (this.router.url === '/') {
        this.getProductListByCategoryIdAndAppearInFront();
      } else {
        if (this.selectedCategoryId === 0) this.getProductListByAppearInFront();
        else this.getListByCategoryIdAndSubCategoryId();
      }
    });
  }

  productOnClick(productId: any, colorId: number = 0) {
    this.router.navigate(['product', productId], {
      queryParams: {
        categoryName: this.categoryList.find(
          (x) =>
            x.id == this.productList.find((x) => x.id === productId)!.categoryId
        )!.name,
        colorId:
          colorId > 0
            ? colorId
            : this.productList.find((x) => x.id === productId)!.selectedColor
                .id,
      },
    });
  }

  onColorsMouseenterleave(event: any) {
    if (window.screen.width > 800) {
      if (event.type === 'mouseenter') {
        event.currentTarget.nextElementSibling.classList.remove('hidden');
      } else if (event.type === 'mouseleave') {
        event.currentTarget.classList.add('hidden');
      }
    } else {
      if (event.type === 'click') {
        Array.from(
          this.grid.nativeElement.getElementsByClassName('color-container')
        ).forEach((cc) => {
          if (cc === event.currentTarget.parentNode.lastChild)
            event.currentTarget.parentNode.lastChild.classList.toggle('hidden');
          else cc.classList.add('hidden');
        });
      }
    }
  }

  onColorImgMouseenter(productId: number, colorId: number) {
    var pr = this.productList.find((x) => x.id === productId)!;
    pr.selectedColor = pr.colors.find((c) => c.id === colorId)!;
  }

  closeColorOption(event: any) {
    event.target.parentNode.parentNode.classList.add('hidden');
  }
  //#endregion
}
