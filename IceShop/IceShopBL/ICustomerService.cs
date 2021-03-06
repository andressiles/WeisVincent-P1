﻿using IceShopDB.Models;
using System.Collections.Generic;

namespace IceShopBL
{
    public interface ICustomerService
    {
        void AddCustomerToRepo(Customer newCustomer);
        void UpdateCustomerEntry(Customer existingCustomer);
        List<Customer> GetAllCustomers();
        List<Order> GetAllOrdersForCustomer(Customer customer);
        List<Order> GetAllOrdersForCustomerAsync(Customer customer);
        Customer GetCustomerByEmail(string newEmail);
    }
}