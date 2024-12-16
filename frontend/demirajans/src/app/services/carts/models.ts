export interface CartDto {
  id: number;
  userId: number;
  colorId: number;
  quantity: number;
}

export interface CartCreateDto {
  userId: number;
  colorId: number;
  quantity: number;
}
