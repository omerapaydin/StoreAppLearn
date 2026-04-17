using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppLearn.Data.Abstract;

namespace StoreAppLearn.Components
{
    public class CategoriesListViewComponent: ViewComponent
    {
        private readonly IStoreRepository _storeRepository;
        public CategoriesListViewComponent(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_storeRepository
                .Products
                .Select(p => p.Categories.FirstOrDefault()!.Name)
                .Distinct()
                .OrderBy(c => c));
        }
    }
}