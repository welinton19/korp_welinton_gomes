import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { importProvidersFrom } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app/app-routing-module';


bootstrapApplication(App,{
  providers: [
    provideHttpClient(),
    importProvidersFrom(FormsModule),
    provideRouter(routes)
  ]
})
  .catch(err => console.error(err));