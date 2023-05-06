using FluentAssertions;
using FluentAssertions.Equivalency;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace NetworkUtility.test.Pingtest
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        public NetworkServiceTests()
        {
            //SUT
            _pingService = new NetworkService();
        }
        [Fact]
        public void NetworkService_Sendping_ReturnString()
        {
            //arrange - variables,classes,mocks

            // var pingService = new NetworkService(); <- to -> _pingService () made a prop

            //act
            var result = _pingService.SendPing();


            //assert
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Success: Ping sent!");
            result.Should().Contain("Success", Exactly.Once());


        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]

        public void Networkservice_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange
            var pingService = new NetworkService();

            //Act
            var result = pingService.PingTimeout(a, b);


            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().BeInRange(-10, 10);
        }


        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //arrange - variables,classes,mocks

            // var pingService = new NetworkService(); <- to -> _pingService () made a prop

            //act
            var result = _pingService.LastPingDate();


            //assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));

        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject() {
            //arrange
            var expected = new PingOptions() {
                DontFragment = true,
                Ttl = 1
            };
        //act
        var result = _pingService.GetPingOptions();

            //assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }


        [Fact]

        public void NetworkService_MostRecentPings_ReturnObject()
        {
            //arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //act
            var result = _pingService.MostRecentPings();

            //assert
            //result.Should().BeOfType<IEnumerable<PingOptions>>(); not working :c
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }

    }
}