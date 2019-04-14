using System;
using API.Controllers;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class APITests
    {
        [Test]
        public void IpAddressListTest()
        {
            var controller = new IpAddressController();
            var addresses = controller.Get();
            Assert.IsNotNull(addresses);
            //  verify address list is not empty
            Assert.IsTrue(addresses.Count > 0);
        }
        [Test]
        public void IpAddressDetailsTest()
        {
            var controller = new IpAddressController();
            var ipAddressInfo = controller.Get("172.245.173.13");
            Assert.IsNotNull(ipAddressInfo);
            Assert.AreEqual("172-245-173-13-host.colocrossing.com", ipAddressInfo.Host);
            Assert.AreEqual("Buffalo", ipAddressInfo.City);
            Assert.AreEqual("New York", ipAddressInfo.Region);
            Assert.AreEqual(42.8864, ipAddressInfo.Latitude);
            Assert.AreEqual(-78.8781, ipAddressInfo.Longitude);
            Assert.AreEqual(14202, ipAddressInfo.ZipCode);

            ipAddressInfo = controller.Get("idontexist");
            Assert.IsNull(ipAddressInfo);
        }
    }
}