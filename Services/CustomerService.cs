﻿using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class CustomerService
    {
        TestDbContext _ctx;
        private int totalItemPagina = 10;
        public CustomerService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public BaseList<Customer> ListCustomers(int page)
        {
            var skip = (page - 1) * totalItemPagina;
            var customers = _ctx.Customers.Skip(skip).Take(totalItemPagina).ToList();
            var totalCount = _ctx.Products.Count(); 

            var hasNext = (skip + customers.Count) < totalCount;

            return new BaseList<Customer>() { HasNext = false, TotalCount = totalCount, Lista = customers };

          // return new ProductList { HasNext = hasNext, TotalCount = totalCount, Products = products };
        }

        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            //Business Rule: Non registered Customers cannot purchase
            var customer = await _ctx.Customers.FindAsync(customerId);
            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            //Business Rule: A customer can purchase only a single time per month
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
            if (ordersInThisMonth > 0)
                return false;

            //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
            var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
            if (haveBoughtBefore == 0 && purchaseValue > 100)
                return false;

            return true;
        }

    }
}
