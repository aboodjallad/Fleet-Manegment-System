using System.Data;
using FPro;
using Fleet_Manegment_System.Services;
using Moq;
using Xunit;
using Npgsql;
using System.Collections.Concurrent;

namespace FMS_test
{
    public class DriverServicesTests
    {
        [Fact]
        public void Add_InsertsDriverInfo_WhenDriverInfoIsPresent()
        {
            // Arrange
            var driverInfo = new ConcurrentDictionary<string, string>();
            driverInfo["drivername"] = "John Doe";
            driverInfo["phonenumber"] = "1234567890";

            var gvarDict = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
            gvarDict["DriverInfo"] = driverInfo;

            var gvar = new GVAR { DicOfDic = gvarDict };

            // Assuming you have a mock setup or an actual instance of the service class
            var driverServices = new DriverServices(); 

            // Act
            driverServices.Add(gvar);

            // Assert
            // You would normally assert expected outcomes here, such as checking the database,
            // or ensuring that certain methods were called on mocked objects.
        }
    }
}