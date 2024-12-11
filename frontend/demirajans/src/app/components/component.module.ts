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
import { FooterComponent } from './shared/footer/footer.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { ProductComponent } from './product/product.component';

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
    FooterComponent,
    ProductListComponent,
    ProductComponent
  ],
  imports: [ComponentRoutingModule, CommonModule, FormsModule],
  exports: [NavbarComponent, FooterComponent],
})
export class ComponentModule {}
