export interface VehiclesInformationsApiResponse  {
    dicOfDic: any; 
    dicOfDT: {
      VehiclesInformations: {
        vehicleid: number;
        driverid: number;
        vehiclemake: string;
        vehiclemodel: number;
        purchasedate: string;
      }[];
    };
  }
  