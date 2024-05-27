using AutoMapper;
using ECommerce.Core.Pagination;
using ECommerce.DataAccess.Repository;
using ECommerce.Models.ViewModels;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(PagedOptions options)
        {
            var companies = _unitOfWork.CompanyRepository.GetAsync(options);
            var companyViewModels = _mapper.Map<CompanyPageViewModel>(companies);
            return View(companyViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var company = _mapper.Map<Company>(companyViewModel);

            if (company == null)
            {
                return BadRequest();
            }

            await _unitOfWork.CompanyRepository.AddAsync(company);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id.Value);

            if (company == null)
            {
                return NotFound();
            }

            var companyViewModel = _mapper.Map<CompanyViewModel>(company);

            return View(companyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel companyViewModel)
        {
            if (companyViewModel == null)
            {
                return BadRequest();
            }

            var updatedCompany = _mapper.Map<Company>(companyViewModel);

            _unitOfWork.CompanyRepository.Update(updatedCompany);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id.Value);

            if (company == null)
            {
                return NotFound();
            }

            var companyViewModel = _mapper.Map<CompanyViewModel>(company);

            return View(companyViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteSubmit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id.Value);

            if (company == null)
            {
                return NotFound();
            }

            _unitOfWork.CompanyRepository.Remove(company);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
