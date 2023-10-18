using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaPub.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public async Task CanPurchase_CustomerNotExists_ReturnsFalse()
        {
            
            var customerId = 1; 
            var purchaseValue = 50; 
            var mockContext = CreateMockContext();
            var customerService = new CustomerService(mockContext.Object);

            var canPurchase = await customerService.CanPurchase(customerId, purchaseValue);
 
            Assert.IsFalse(canPurchase);
        }

        private static Mock<TestDbContext> CreateMockContext()
        {
            var mockContext = new Mock<TestDbContext>();

            return mockContext;
        }
    }
}
