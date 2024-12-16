export interface ProductDto {
  id: number;
  name: string;
  categoryId: number;
  subCategoryId: number;
  code: string;
  price: number;
  appearInFront: boolean;
  vat: number;
  base64: string;
  printExp: string;
  imageName: string;
  description: string | null;
  dimension: string | null;
  colors: ColorDto[] ;
}

export interface ColorDto {
  id: number;
  name: string;
  code: string;
  color: string | null;
  base64: string;
  header: string;
  productId: number;
  uid: number;
  imageName: string;
  addedToCart: boolean;
}
