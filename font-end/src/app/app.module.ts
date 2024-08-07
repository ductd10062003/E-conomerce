import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './common/header/header.component';
import { FooterComponent } from './common/footer/footer.component';
import { HomeComponent } from './page/home/home.component';
import { DashBoardComponent } from './admin/dash-board/dash-board.component';
import { ManageCategoryComponent } from './admin/manage-category/manage-category.component';
import { ManageProductComponent } from './admin/manage-product/manage-product.component';
import { ProductDetailComponent } from './page/product-detail/product-detail.component';
import { LoginComponent } from './page/login/login.component';
import { RegisterComponent } from './page/register/register.component';
import { AbcComponent } from './abc/abc.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    DashBoardComponent,
    ManageCategoryComponent,
    ManageProductComponent,
    ProductDetailComponent,
    LoginComponent,
    RegisterComponent,
    AbcComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
