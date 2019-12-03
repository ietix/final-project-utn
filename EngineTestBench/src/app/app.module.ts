import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutes } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { PanelModule } from 'primeng/panel';
import { InputTextModule } from 'primeng/inputtext';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {ButtonModule} from 'primeng/button';
//import {NoopAnimationsModule} from '@angular/platform-browser/animations';

@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      HomeComponent
   ],
   imports: [
      BrowserModule,
      AppRoutes, 
      PanelModule, 
      InputTextModule,
      BrowserAnimationsModule,
      ButtonModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
