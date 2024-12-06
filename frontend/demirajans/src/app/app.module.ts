import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComponentModule } from './components/component.module';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { tokenInterceptor } from './helpers/interceptors/token.interceptor';

@NgModule({
  declarations: [AppComponent],
  imports: [
    AppRoutingModule,
    ComponentModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
  ],
  providers: [provideHttpClient(withInterceptors([tokenInterceptor]))],
  bootstrap: [AppComponent],
})
export class AppModule {}
