export interface GeofencesApiResponse {
  dicOfDic: any;
  dicOfDT: {
    Geofences: { 
      geofenceid : string;
      geofencetype: string;
      addeddate: string;
      strokecolor : string;
      strokeopacity: string;
      strokeweight: string;
      fillcolor: string;
      fillopacity: string;
    }[];
  };
}