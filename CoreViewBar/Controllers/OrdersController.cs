using CoreViewBar.Data.Cart;
using CoreViewBar.Data.Services;
using CoreViewBar.Data.ViewComponents;
using CoreViewBar.Data.ViewModels;
using CoreViewBar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ShopBagMethods _shopBag;
        private readonly IOrdersServices _ordersServices;

        public OrdersController(IProductsService productsService, ShopBagMethods shopBag, IOrdersServices ordersServices)
        {
            _productsService = productsService;
            _shopBag = shopBag;
            _ordersServices = ordersServices;
        }

        
        //public async Task<IActionResult> OrderPaymentOption()
        //{            
        //    var orders = await _ordersServices.GetOrderList();
        //    return View(orders);              
        //}

        // Using the IActionResult is possible to create the object that will be use in the view. --TESTED.
        public IActionResult ShopBag()
        {
            var items = _shopBag.GetShopBagsItems();
            _shopBag.ShopBags = items;
            var _Discount = _shopBag.GetDiscountValue();
            var _isDiscountApplied = _Discount != 0 ? true : false;
            var response = new ShopBagVM()
            {
                ShopBagMethods = _shopBag,
                ShopBagTotal = _shopBag.GetShopBagsTotal(),
                Discount = _Discount,
                isDiscountApplied = _isDiscountApplied
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddToShopBag(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);
            if(item != null)
            {
                _shopBag.AddProductToShopBag(item);
                
            }
            return RedirectToAction(nameof(ShopBag));        
        }
        //Controller to remove from the ShopBag the items - TESTED.
        public async Task<RedirectToActionResult> RemoveFromShopBag(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);
            if (item != null)
            {
                _shopBag.RemoveProductToShopBag(item);

            }
            return RedirectToAction(nameof(ShopBag));
        }
        //I separate 2 controller in case the will be other operations in the future (just for this exercises) - TESTED.
        public async Task<IActionResult> CompleteOrderCreditCard()
        {
            var _items = _shopBag.GetShopBagsItems();
            var _ShopBagTotals = _shopBag.GetShopBagsTotal();
            var _Discounts = _shopBag.GetDiscountValue();
            string _ShopBagID = _shopBag.ShopBagID;
            DateTimeOffset DateTimeOrder = DateTimeOffset.UtcNow;
            //Save the values on the order parameters and then clean the Shop Bag.
            await _ordersServices.StoreOrdersAsync(_items, _ShopBagID, DateTimeOrder, _Discounts);
            await _shopBag.ClearShopBagAsync();

            var response = new PaymentVM()
            {
                ShopBagValues = _items,
                ShopBagTotal = _ShopBagTotals,
                Discount = _Discounts
            };          

            return View("CreditCardOrderComplete", response);
            
        }
        //Same with the Cash -- TESTED.
        public async Task<IActionResult> CompleteOrderCash()
        {
            var _items = _shopBag.GetShopBagsItems();
            var _ShopBagTotals = _shopBag.GetShopBagsTotal();
            var _Discounts = _shopBag.GetDiscountValue();
            string _ShopBagID = _shopBag.ShopBagID;
            DateTimeOffset DateTimeOrder = DateTimeOffset.UtcNow;

            //Save the values on the order parameters and then clean the Shop Bag.
            await _ordersServices.StoreOrdersAsync(_items, _ShopBagID, DateTimeOrder, _Discounts);
            await _shopBag.ClearShopBagAsync();

            var response = new PaymentVM()
            {
                ShopBagValues = _items,
                ShopBagTotal = _ShopBagTotals,
                Discount = _Discounts
            };

            return View("CashOrderComplete", response);
        }

        //The controller method that is the reponse of the View when we need to apply the discount coupon - TESTED.
        public async Task<RedirectToActionResult> SearchDiscountCoupon(string searchString)
        {
            var item = searchString;
            if (item != null)
            {
                await _shopBag.GetAllCoupons(item);
            }
            return RedirectToAction(nameof(ShopBag));
        }
    }
}
