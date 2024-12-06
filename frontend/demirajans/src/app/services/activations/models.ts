export interface ActivationCreateDto {
  email: string;
  expirationDate: Date;
  code: string;
}

export interface VerifyActivationDto {
  code: string;
  email: string;
}
