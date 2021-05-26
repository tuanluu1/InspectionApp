import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { VehicleService } from '../vehicle.service';
import { Vehicle } from '../vehicle';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.sass']
})
export class VehicleComponent implements OnInit {
  dataSaved = false;
  vehicleForm: any;
  allVehicles!: Observable<Vehicle[]>;
  vehicleIdUpdate = null;
  massage: any;
  constructor(private formbulider: FormBuilder, private vehicleService: VehicleService) { }

  ngOnInit(): void {
    this.vehicleForm = this.formbulider.group({
      VIN: ['', [Validators.required]],
      Vehicle_Maker: ['', [Validators.required]],
      Vehicle_Year: ['', [Validators.required]],
      Vehicle_Model: ['', [Validators.required]],
      Inspection_Date: ['', [Validators.required]],
      Inspector_Name: ['', [Validators.required]],
      Inspection_Location: ['', [Validators.required]],
      Pass_Fail: ['', [Validators.required]],
    });
    this.loadAllVehicle();
  }
  loadAllVehicle() {
    this.allVehicles = this.vehicleService.GetVehicleInspections();
  }
  onFormSubmit() {
    this.dataSaved = false;
    const vehicle = this.vehicleForm.value;
    this.CreateVehicle(vehicle);
    this.vehicleForm.reset();
  }
  loadVehicleToEdit(Id: bigint) {
    this.vehicleService.GetVehicleInspection(Id).subscribe(vehicle => {
      this.massage = null;
      this.dataSaved = false;
      //this.vehicleIdUpdate = vehicle.RowID;
      this.vehicleForm.controls['VIN'].setValue(vehicle.VIN)
      this.vehicleForm.controls['Vehicle_Maker'].setValue(vehicle.Vehicle_Maker)
      this.vehicleForm.controls['Vehicle_Year'].setValue(vehicle.Vehicle_Year)
      this.vehicleForm.controls['Vehicle_Model'].setValue(vehicle.Vehicle_Model)
      this.vehicleForm.controls['Inspection_Date'].setValue(vehicle.Inspection_Date)
      this.vehicleForm.controls['Inspector_Name'].setValue(vehicle.Inspector_Name)
      this.vehicleForm.controls['Inpsection_Location'].setValue(vehicle.Inspection_Location)
      this.vehicleForm.controls['Pass_Fail'].setValue(vehicle.Pass_Fail)
      this.vehicleForm.controls['Notes'].setValue(vehicle.Notes)
    });

  }

  CreateVehicle(vehicle: Vehicle) {
    if (this.vehicleIdUpdate == null) {
      this.vehicleService.createVehicle(vehicle).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record saved Successfully';
          this.loadAllVehicle();
          this.vehicleIdUpdate = null;
          this.vehicleForm.reset();
        }
      );
    } else {
      //vehicle.RowID = this.vehicleIdUpdate;
      this.vehicleService.updateVehicle(vehicle).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Updated Successfully';
        this.loadAllVehicle();
        this.vehicleIdUpdate = null;
        this.vehicleForm.reset();
      });
    }
  }
  deleteVehicle(id: bigint) {
    if (confirm("Are you sure you want to delete this ?")) {
      this.vehicleService.deleteVehicle(id).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Deleted Succefully';
        this.loadAllVehicle();
        this.vehicleIdUpdate = null;
        this.vehicleForm.reset();

      });
    }
  }
  resetForm() {
    this.vehicleForm.reset();
    this.massage = null;
    this.dataSaved = false;
  }
}
