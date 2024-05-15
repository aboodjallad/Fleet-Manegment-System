export interface VehicleApiResponse  {
    dicOfDic: any; 
    dicOfDT: {
      VehiclesInformation: {
        vehicleid: number;
        vehiclenumber: number;
        vehicletype: string;
        lastdirection: number;
        laststatus: string;
        lastaddress: string;
        lastposition: string;
      }[];
    };
  }
  