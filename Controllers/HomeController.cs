using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingdojo.Models;
using DbConnection;

namespace quotingdojo.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Quote newQuote)
        {
            string query = $"INSERT INTO quotes (name,quote) VALUE ('{newQuote.name}', '{newQuote.quote}')";
            DbConnector.Execute(query);
            return RedirectToAction("Show");
        }

        [Route("quotes")]
        [HttpGet]
        public IActionResult Show()
        {
            List<Dictionary<string, object>> allQuotes = DbConnector.Query($"SELECT * FROM quotes");
            return View("Quotes", allQuotes);
        }
    }
}
