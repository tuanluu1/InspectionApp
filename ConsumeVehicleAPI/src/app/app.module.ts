import { NgModule } from '@angular/core';
import { VehicleService } from './vehicle.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
//import {
//  MatButtonModule, MatMenuModule, MatDatepickerModule, MatNativeDateModule, MatIconModule, MatCardModule, MatSidenavModule, MatFormFieldModule,
//  MatInputModule, MatTooltipModule, MatToolbarModule
//} from '@angular/material';
import { MatRadioModule } from '@angular/material/radio';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VehicleComponent } from './vehicle/vehicle.component';

@NgModule({
  declarations: [
    AppComponent,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
   // MatButtonModule,
   // MatMenuModule,
   // MatDatepickerModule,
   // MatNativeDateModule,
   // MatIconModule,
    MatRadioModule,
   // MatCardModule,
   // MatSidenavModule,
   // MatFormFieldModule,
   // MatInputModule,
   // MatTooltipModule,
    //MatToolbarModule,
    VehicleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ], //MatDatepickerModule
  providers: [HttpClientModule, VehicleService,],
  bootstrap: [AppComponent]
})
export class AppModule { }
