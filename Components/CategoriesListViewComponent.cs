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
                .Categories
                .Select(c => new Models.CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Url = c.Url
                })
                .ToList());
        }
    }
}