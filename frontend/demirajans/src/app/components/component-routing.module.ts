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

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomeComponent,
    canActivate: [authGuard],
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
    path: 'profile',
    pathMatch: 'full',
    component: ProfileComponent,
  },
  {
    path: 'shopping-cart',
    pathMatch: 'full',
    component: ShoppingCartComponent,
  },
  {
    path: 'service',
    pathMatch: 'full',
    component: ServiceComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ComponentRoutingModule {}
