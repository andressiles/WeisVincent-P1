﻿using IceShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceShopBL
{
    public interface IOrderService
    {
        void AddOrderToRepo(Order order);
        List<OrderLineItem> GetAllProductsInOrder(Order order);
        Task<List<OrderLineItem>> GetAllProductsInOrderAsync(Order order);
        void RemoveLineItemFromLocationInventory(InventoryLineItem inventoryLineItem);
        void RemoveLineItemsFromLocationInventory(List<InventoryLineItem> inventoryLineItems);
        void UpdateLineItemsInLocationInventory();
    }
}