export interface ProductDto {
  id: number;
  name: string;
  categoryId: number;
  subCategoryId: number;
  code: string;
  price: number;
  dimension: string | null;
  appearInFront: boolean;
  header: string;
  color: string | null;
  description: string;
  vat: number;
  uid: number;
  images: ImageDto[];
}

export interface ImageDto {
  id: string;
  productId: number;
  isFrontImage: boolean;
  base64: string;
}
