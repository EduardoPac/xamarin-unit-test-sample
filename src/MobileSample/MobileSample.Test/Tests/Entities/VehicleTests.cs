using FluentAssertions;
using MobileSample.Test.Util;
using Xunit;

namespace MobileSample.Test.Entities
{
    public interface IVehicleTests : IBaseEntitiesTests
    {
        void EntitiesRequiredInvalid(string id, string companyId, string name, string manufacturerId);
    }
    
    public class VehicleTests : BaseTests, IVehicleTests
    {
        [Fact]
        public void EntitiesRequiredValid()
        {
            var vehicle = EntitiesFactory.GetNewVehicle();

            bool result = vehicle.ValidateRequired();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("","test","test","test")]
        [InlineData("test","","test","test")]
        [InlineData("test","test","","test")]
        [InlineData("test","test","test","")]
        [InlineData(null,"test","test","test")]
        [InlineData("test",null,"test","test")]
        [InlineData("test","test",null,"test")]
        [InlineData("test","test","test",null)]
        public void EntitiesRequiredInvalid(string id, string companyId, string name, string manufacturerId)
        {
            var vehicle = EntitiesFactory.GetNewVehicleParametrized(id, name, companyId, manufacturerId);

            bool result = vehicle.ValidateRequired();
            result.Should().BeFalse();
        }
    }
}