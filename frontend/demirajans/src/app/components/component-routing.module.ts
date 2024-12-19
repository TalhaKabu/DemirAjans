import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { authGuard } from '../helpers/guards/auth.guard';
import { RegisterComponent } from './register/register.component';
import { CategoryComponent } from './category/category.component';
import { ProfileComponent } from './profile/profile.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { ServiceComponent } from './service/service.component';
import { ProductComponent } from './product/product.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomeComponent,
  },
  {
    path: 'login',
    pathMatch: 'full',
    component: LoginComponent,
  },
  {
    path: 'register',
    pathMatch: 'full',
    component: RegisterComponent,
  },
  {
    path: 'category/:id',
    pathMatch: 'full',
    component: CategoryComponent,
  },
  {
    path: 'category/:id/:sid',
    pathMatch: 'full',
    component: CategoryComponent,
  },
  {
    path: 'product/:id',
    pathMatch: 'full',
    component: ProductComponent,
  },
  {
    path: 'profile',
    pathMatch: 'full',
    component: ProfileComponent,
  },
  {
    path: 'shopping-cart',
    pathMatch: 'full',
    component: ShoppingCartComponent,
    canActivate: [authGuard],
  },
  {
    path: 'service',
    pathMatch: 'full',
    component: ServiceComponent,
  },
  {
    path: 'admin-panel',
    pathMatch: 'full',
    component: AdminPanelComponent,
    canActivate: [authGuard],
  },
  {
    path: '**',
    component: HomeComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ComponentRoutingModule {}
