export interface CategoryDto {
  id: number;
  name: string;
  imageName: string;
  base64: string;
  appearInFront: boolean;
  subCategoryList: SubCategoryDto[];
}

export interface SubCategoryDto {
  id: number;
  name: string;
  imageName: string;
  categoryId: number;
  skid: number;
}
