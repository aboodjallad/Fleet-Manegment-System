export interface DriversApiResponse  {
    dicOfDic: any; 
    dicOfDT: {
      drivers: {
        driverid: string;
        drivername: string;
        phonenumber: string;
      }[];
    };
  }
  