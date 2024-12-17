import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ColorDto, ProductDto } from '../../services/products/models';
import { environment } from '../../../environments/environment';
import { ProductService } from '../../services/products/product.service';
import { CartService } from '../../services/carts/cart.service';
import { CartCreateDto, CartDto } from '../../services/carts/models';
import { TokenHelperService } from '../../helpers/services/token-helper.service';

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
  images: string[] = [];
  selectedImage!: string;
  apiUrl!: string;
  categoryName!: string;

  @ViewChild('thumbnails') thumbnails!: ElementRef<HTMLImageElement>;
  //#endregion

  //#region Utils
  get() {
    this.productService.get(this.productId).subscribe({
      next: (n) => (
        (this.product = n),
        ((this.selectedColor = this.product.colors[0]),
        this.images.push(this.product.imageName, this.selectedColor.imageName),
        (this.selectedImage = this.selectedColor.imageName))
      ),
      error: (e) => console.log(e),
    });
  }

  //#endregion

  //#region Ctor
  constructor(
    private activatedRoute: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService,
    private tokenHelperService: TokenHelperService
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

  activeImage(img: string): boolean {
    return this.selectedImage === img;
  }

  arrowOnClick(value: boolean, imageName: string) {
    if (value) {
      var index = this.images.indexOf(imageName);
      if (index === this.images.length - 1) {
        this.selectedImage = this.images[0];
      } else {
        this.selectedImage = this.images[index + 1];
      }
    } else {
      var index = this.images.indexOf(imageName);
      if (index === 0) {
        this.selectedImage = this.images[this.images.length - 1];
      } else {
        this.selectedImage = this.images[index - 1];
      }
    }
  }

  imgOnClick(img: string) {
    this.selectedImage = img;
  }

  colorOnClick(colorId: number) {
    this.selectedColor = this.product.colors.find((x) => x.id === colorId)!;
    var imgs = this.images.filter((x) => x === this.product.imageName);
    imgs.push(this.selectedColor.imageName);
    this.images = imgs;
    this.selectedImage = this.selectedColor.imageName;
  }

  addToCart() {
    // this.cartService
    //   .insert(<CartCreateDto>{
    //     userId: this.tokenHelperService.getUserIdFromToken(),
    //     colorId: this.selectedColor.id,
    //     quantity: this.selectedColor.quantity,
    //   })
    //   .subscribe({
    //     next: (n) => (console.log(n), (this.selectedColor.addedToCart = true)),
    //     error: (e) => console.log(e),
    //   });
  }
  //#endregion
}
