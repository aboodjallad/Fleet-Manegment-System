export interface DriversApiResponse {
  dicOfDic: any;
  dicOfDT: {
    Drivers: { 
      driverid: string;
      drivername: string;
      phonenumber: string;
    }[];
  };
}
