import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ComponentRoutingModule } from './component-routing.module';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';

import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    SidebarComponent,
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    ComponentRoutingModule,
    CommonModule,
    FormsModule,
    MatListModule,
    MatSidenavModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatButtonModule,
    MatDividerModule,
  ],
  exports: [SidebarComponent, NavbarComponent],
})
export class ComponentModule {}
