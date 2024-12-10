import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ComponentRoutingModule } from './component-routing.module';

import { NavbarComponent } from './shared/navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ServiceComponent } from './service/service.component';
import { ProfileComponent } from './profile/profile.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { CategoryComponent } from './category/category.component';

@NgModule({
  declarations: [
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ServiceComponent,
    ProfileComponent,
    ShoppingCartComponent,
    CategoryComponent,
  ],
  imports: [ComponentRoutingModule, CommonModule, FormsModule],
  exports: [NavbarComponent],
})
export class ComponentModule {}
