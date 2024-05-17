using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fleet_Manegment_System.Services.General
{
    public static class SqlManager
    {

        public enum SqlCommands
        {
            InsertVehicleInformation = 1,
            UpdateVehicleInformation = 2,
            DeleteVehicleInformation = 3,
            AssignDriver = 4,
            GetVehiclesInformation = 5,
            GetSpecificVehicleInformation = 6,
            GetVehicleInformation = 7,
            GetAll = 8,
            InsertVehicle = 9,
            UpdateVehicle = 10,
            DeleteVehicle = 11,
            GetVehicle = 12,
            GetAllVehicles = 13,
            insertDriver = 14,
            DeleteDriver = 15,
            GetDriver = 16,
            UpdateDriver = 17,
            GetAllDrivers = 18,
            AddRouteHistory = 19,
            GetRouteHistory = 20,
            GetAllGeofences = 21,
            GetAllCircularGeofences = 22,
            GetAllPolygonGeofences = 23,
            GetAllRectangularGeofences = 24,
            GetLastRouteHistory = 25,

        }

        public static string GetSqlCommand(SqlCommands command)
        {
            switch (command)
            {
                case SqlCommands.InsertVehicleInformation:
                    return @"INSERT INTO VehiclesInformations 
                         (vehicleid, driverid, vehiclemake, vehiclemodel, purchasedate)  
                         VALUES (@vehicleId, @driverId, @vehicleMake, @vehicleModel, @purchaseDate);";
                case SqlCommands.UpdateVehicleInformation:
                    return "UPDATE VehiclesInformations SET driverid = @driverId, vehiclemake = @vehicleMake, vehiclemodel = @vehicleModel, purchasedate = @purchaseDate WHERE vehicleid = @vehicleId";
                case SqlCommands.DeleteVehicleInformation:
                    return "DELETE FROM VehiclesInformations WHERE vehicleid = @vehicleId";
                case SqlCommands.AssignDriver:
                    return "UPDATE VehiclesInformations SET driverid = @DriverId WHERE vehicleid = @VehicleID;";
                case SqlCommands.GetVehiclesInformation:
                    return "SELECT V.VehicleID, V.VehicleNumber,V.VehicleType, RH.VehicleDirection AS LastDirection, RH.Status AS LastStatus, RH.Address AS LastAddress, RH.Latitude || ',' || RH.Longitude AS LastPosition FROM Vehicles V JOIN RouteHistory RH ON V.VehicleID = RH.VehicleID  ORDER BY RH.RecordTime DESC;";
                case SqlCommands.GetSpecificVehicleInformation:
                    return "SELECT V.VehicleNumber, V.VehicleType, D.DriverName, D.PhoneNumber, R.Latitude || ',' || R.Longitude AS LastPosition, VI.VehicleMake, VI.VehicleModel, R.RecordTime AS LastGPSTime, R.VehicleSpeed AS LastGPSSpeed, R.Address AS LastAddress FROM Vehicles V JOIN VehiclesInformations VI ON V.VehicleID = VI.VehicleID JOIN Driver D ON VI.DriverId = D.DriverID LEFT JOIN RouteHistory R ON V.VehicleID = R.VehicleID WHERE V.VehicleID = @VehicleID ORDER BY R.RecordTime DESC LIMIT 1;";
                case SqlCommands.GetVehicleInformation:
                    return "SELECT * FROM vehiclesinformations WHERE vehicleid = @vehicleId";
                case SqlCommands.GetAll:
                    return "SELECT * FROM vehiclesinformations";
                case SqlCommands.InsertVehicle:
                    return "INSERT INTO vehicles (vehiclenumber, vehicletype) VALUES (@vehicleNumber, @vehicleType)";
                case SqlCommands.DeleteVehicle:
                    return "DELETE FROM vehicles WHERE vehicleid = @vehicleId;";
                case SqlCommands.GetVehicle:
                    return "SELECT * FROM vehicles WHERE vehicleid = @vehicleId";
                case SqlCommands.UpdateVehicle:
                    return "UPDATE vehicles SET vehiclenumber = @vehicleNumber, vehicletype = @vehicleType WHERE vehicleid = @vehicleId";
                case SqlCommands.GetAllVehicles:
                    return "SELECT * FROM vehicles";
                case SqlCommands.insertDriver:
                    return "INSERT INTO driver (drivername, phonenumber) VALUES (@drivername, @phonenumber)";
                case SqlCommands.DeleteDriver:
                    return "DELETE FROM driver WHERE driverid = @driverid";
                case SqlCommands.GetDriver:
                    return "SELECT * FROM driver WHERE driverid = @driverid";
                case SqlCommands.UpdateDriver:
                    return "UPDATE driver SET drivername = @drivername, phonenumber = @phonenumber WHERE driverid = @driverid";
                case SqlCommands.GetAllDrivers:
                    return "SELECT * FROM driver";
                case SqlCommands.AddRouteHistory:
                    return @"
                    INSERT INTO RouteHistory (vehicleid, vehicledirection, status, vehiclespeed, recordtime, address, latitude, longitude)
                    VALUES (@VehicleID, @VehicleDirection, @Status, @VehicleSpeed, @RecordTime, @Address, @Latitude, @Longitude);";
                case SqlCommands.GetRouteHistory:
                    return @"
                    SELECT
                    V.VehicleID,
                     V.VehicleNumber,
                    RH.Address,
                    RH.Status,
                     RH.Latitude || ',' || RH.Longitude AS Position,
                    RH.VehicleDirection,
                    RH.VehicleSpeed AS GPSSpeed,
                    RH.RecordTime AS GPSTime
                    FROM Vehicles V
                    JOIN RouteHistory RH ON V.VehicleID = RH.VehicleID
                    WHERE V.VehicleID = @VehicleID
                    AND CAST(RH.RecordTime AS BIGINT) >= @StartTime
                    AND CAST(RH.RecordTime AS BIGINT) <= @EndTime
                    ORDER BY RH.RecordTime
                    DESC;";
                case SqlCommands.GetLastRouteHistory:
                    return @"
                    SELECT
                    V.VehicleID,
                     V.VehicleNumber,
                    RH.Address,
                    RH.Status,
                     RH.Latitude,
                     RH.Longitude ,
                    RH.VehicleDirection,
                    RH.VehicleSpeed AS GPSSpeed,
                    RH.RecordTime AS GPSTime
                    FROM Vehicles V
                    JOIN RouteHistory RH ON V.VehicleID = RH.VehicleID
                    WHERE V.VehicleID = @VehicleID
                    AND CAST(RH.RecordTime AS BIGINT) >= @StartTime
                    AND CAST(RH.RecordTime AS BIGINT) <= @EndTime
                    ORDER BY RH.RecordTime
                    DESC;";
                case SqlCommands.GetAllGeofences:
                    return "SELECT * FROM geofences";
                case SqlCommands.GetAllCircularGeofences:
                    return @"
                    SELECT GeofenceID, Radius, Latitude, Longitude
                    FROM CircleGeofence;";
                case SqlCommands.GetAllPolygonGeofences:
                    return @"
                    SELECT GeofenceID, Latitude, Longitude
                    FROM PolygonGeofence;";
                case SqlCommands.GetAllRectangularGeofences:
                    return @"
                    SELECT GeofenceID, North, East, West, South
                    FROM RectangleGeofence;";

                default:
                    throw new NotImplementedException("Command not implemented.");
            }
        }
    }
}
