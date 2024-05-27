using AutoMapper;
using ECommerce.Core.Pagination;
using ECommerce.DataAccess.Repository;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(PagedOptions options)
        {
            var categories = _unitOfWork.CategoryRepository.GetAsync(options);
            var categoryViewModels = _mapper.Map<CategoryPageViewModel>(categories);
            return View(categoryViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var category = _mapper.Map<Category>(categoryViewModel);

            if (category == null)
            {
                return BadRequest();
            }

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);

            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null)
            {
                return BadRequest();
            }

            var updatedCategory = _mapper.Map<Category>(categoryViewModel);

            _unitOfWork.CategoryRepository.Update(updatedCategory);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);

            return View(categoryViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteSubmit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoryRepository.Remove(category);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
