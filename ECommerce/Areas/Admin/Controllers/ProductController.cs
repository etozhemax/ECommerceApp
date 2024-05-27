using AutoMapper;
using ECommerce.DataAccess.Repository;
using ECommerce.Models.ViewModels;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Core.Pagination;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(PagedOptions options)
        {
            var products = _unitOfWork.ProductRepository.GetAsync(options);
            var productViewModels = _mapper.Map<ProductPageViewModel>(products);
            return View(productViewModels);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            if (id == null || id == 0)
            {
                return View(new ProductViewModel());
            }

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<ProductViewModel>(product);

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ProductViewModel productViewModel, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var product = _mapper.Map<Product>(productViewModel);

            if (product == null)
            {
                return BadRequest();
            }

            product.ImageUrl = await UploadFile(file, product.ImageUrl);

            if (product.Id == 0)
            {
                await _unitOfWork.ProductRepository.AddAsync(product);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction("Index");
        }

        private void ClearExistingFile(string? fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }

        private async Task<string?> UploadFile(IFormFile? file, string? oldFileName)
        {
            var fileName = oldFileName;

            if (file != null)
            {
                ClearExistingFile(oldFileName);

                fileName = string.Concat(Guid.NewGuid().ToString(), ".jpg");

                using var fileStream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, "images", fileName), FileMode.Create);
                if (fileStream != null)
                {
                    await file.CopyToAsync(fileStream);
                }

                return fileName;
            }

            return fileName;
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = _mapper.Map<ProductViewModel>(product);

            return View(productViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteSubmit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductRepository.Remove(product);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
