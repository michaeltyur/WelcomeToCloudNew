import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbCardModule, NbButtonModule, NbSpinnerModule, NbInputModule, NbToggleModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { HttpClient, HttpClientModule, HttpHeaders, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CredentialsInterceptor } from './shared/services/http-interseptor';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'cosmic' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbCardModule,
    NbButtonModule,
    HttpClientModule,
    NbSpinnerModule,
    NbInputModule,
    FormsModule,
    NbToggleModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: CredentialsInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
