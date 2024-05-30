using AutoMapper;
using ECommerce.Core.Extensions;
using ECommerce.DataAccess.Repository;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(
            ILogger<HomeController> logger, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            var productViewModels = products.Select(_mapper.Map<ProductViewModel>).ToList();
            return View(productViewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id, "Category");

            var productViewModel = _mapper.Map<ProductViewModel>(product.FirstOrDefault());

            var detailsPageViewModel = new DetailsPageViewModel
            {
                Product = productViewModel,
                Count = 1
            };

            return View(detailsPageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Details(DetailsPageViewModel detailsPage)
        {
            var userId = User.GetUserId();

            var shoppingCartItems = await _unitOfWork.ShoppingCartItemRepository.GetAsync(x => x.EcommerceApplicationUserId == userId, "Product");

            if (shoppingCartItems != null && shoppingCartItems.Any())
            {
                var currentShoppingItem = shoppingCartItems.FirstOrDefault(x => x.ProductId == detailsPage.Product.Id);

                if (currentShoppingItem == null)
                {
                    var shoppingItem = new ShoppingCartItem
                    {
                        EcommerceApplicationUserId = userId,
                        ProductId = detailsPage.Product.Id,
                        Count = detailsPage.Count
                    };

                    await _unitOfWork.ShoppingCartItemRepository.AddAsync(shoppingItem);
                }
                else
                {
                    currentShoppingItem.Count += detailsPage.Count;
                }
            }

            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}