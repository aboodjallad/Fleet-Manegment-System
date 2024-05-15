export interface SingleRouteApiResponse {
    dicOfDic: any;
    dicOfDT: {
        RouteHistory: {
        vehicleid: string;
        vehicledirection: string;
        status: string;
        vehiclespeed: string;
        recordtime: string;
        address: string;
        latitude: string;
        longitude: string;
      }[];
    };
  }
  