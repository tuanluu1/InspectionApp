import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vehicle } from './vehicle';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  url = 'http://localhost:2828/Api/Vehicle';
  constructor(private http: HttpClient) { }
  GetVehicleInspections(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(this.url + '/GetVehicleInspections');
  }
  GetVehicleInspection(Id: bigint): Observable<Vehicle> {
    return this.http.get<Vehicle>(this.url + '/GetVehicleInspection/' + Id);
  }
  createVehicle(vehicle: Vehicle): Observable<Vehicle> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Vehicle>(this.url + '/InsertVehicleDetails/',
      vehicle, httpOptions);
  }
  updateVehicle(vehicle: Vehicle): Observable<Vehicle> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Vehicle>(this.url + '/UpdateVehicleDetails/',
      vehicle, httpOptions);
  }
  deleteVehicle(id: bigint): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.url + '/DeleteVehicleInspection?id=' + id,
      httpOptions);
  }
}


//export class VehicleService {

//  constructor() { }
//}
