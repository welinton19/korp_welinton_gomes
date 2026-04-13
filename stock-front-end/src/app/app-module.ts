import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { ProdutosComponent } from "./features/produtos/produtos.component";
import { FormsModule } from '@angular/forms';

@NgModule({
 
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
  ]
})
export class AppModule { }
