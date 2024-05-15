export interface VehiclesApiResponse {
    dicOfDic: any; 
    dicOfDT: {
      Vehicles: {  
        vehicleid: string;
        vehiclenumber: string;
        vehicletype: string;
      }[];
    };
  }
  