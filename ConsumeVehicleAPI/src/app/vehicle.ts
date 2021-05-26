export class Vehicle {
  RowID!: bigint;
  VIN!: string;
  Vehicle_Maker!: bigint;
  Vehicle_Year!: bigint;
  Vehicle_Model!: string;
  Inspection_Date!: Date;
  Inspector_Name!: string;
  Inspection_Location!: string;
  Pass_Fail!: boolean;
  Notes!: string;
}
