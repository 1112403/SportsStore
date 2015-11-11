using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository repository;

        public HomeController(ICustomerRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public PartialViewResult Login()
        {
            return PartialView(repository.Customers);
        }
	}
}