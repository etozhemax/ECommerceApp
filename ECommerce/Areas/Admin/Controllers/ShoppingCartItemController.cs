using AutoMapper;
using ECommerce.Core.Extensions;
using ECommerce.DataAccess.Repository;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Customer")]
    public class ShoppingCartItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoppingCartItemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();

            var shoppingCartItems = await _unitOfWork.ShoppingCartItemRepository.GetAsync(x => x.EcommerceApplicationUserId == userId, "Product");
            
            var shoppingCartItemViewModels = shoppingCartItems.Select(x => new ShoppingCartItemViewModel
            {
                Id = x.Id,
                Product = _mapper.Map<ProductViewModel>(x.Product),
                Count = x.Count
            });

            return View(new ShoppingCartItemPageViewModel 
            { 
                ShoppingCartItems = shoppingCartItemViewModels,
                Total = shoppingCartItems.Select(x => x.Product.Price * x.Count).Sum()
            });
        }

        [Authorize]
        public async Task<IActionResult> Increase(int id)
        {
            var userId = User.GetUserId();

            var shoppingCartItems = await _unitOfWork.ShoppingCartItemRepository.GetAsync(x => x.EcommerceApplicationUserId == userId, "Product");

            if (shoppingCartItems != null && shoppingCartItems.Any())
            {
                var currentShoppingItem = shoppingCartItems.FirstOrDefault(x => x.Id == id);

                if (currentShoppingItem != null)
                {
                    currentShoppingItem.Count += 1;
                }
            }

            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index", "ShoppingCartItem");
        }

        [Authorize]
        public async Task<IActionResult> Decrease(int id)
        {
            var userId = User.GetUserId();

            var shoppingCartItems = await _unitOfWork.ShoppingCartItemRepository.GetAsync(x => x.EcommerceApplicationUserId == userId, "Product");

            if (shoppingCartItems != null && shoppingCartItems.Any())
            {
                var currentShoppingItem = shoppingCartItems.FirstOrDefault(x => x.Id == id);

                if (currentShoppingItem != null)
                {
                    currentShoppingItem.Count -= 1;
                }
            }

            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index", "ShoppingCartItem");
        }

        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var shoppingCartItem = await _unitOfWork.ShoppingCartItemRepository.GetByIdAsync(id);

            if (shoppingCartItem != null)
            {
                _unitOfWork.ShoppingCartItemRepository.Remove(shoppingCartItem);
            }

            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index", "ShoppingCartItem");
        }
    }
}
