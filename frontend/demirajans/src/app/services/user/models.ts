export interface UserCreateDto {
  email: string;
  username: string;
  password: string;
  passwordAgain: string;
  name: string;
  lastName: string;
}

export interface UserDto {
  id: number;
  username: string;
  password: string;
  email: string;
  isAdmin: boolean;
  name: string;
  lastName: string;
  creationDate: Date;
  lastModificationDate: Date;
}
