using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tx_github_actions.Models;

namespace tx_github_actions.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {

            using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl()) {
                tx.Create();

                tx.Selection.FontSize = 420;
                tx.Text = "Text Control";
                tx.Select(0, 4);
                tx.Selection.Bold = true;
                
                var sHtml = "";

                tx.Save(out sHtml, TXTextControl.StringStreamType.HTMLFormat);

                ViewModel model = new ViewModel() {
                    Html = sHtml
                };

                return View(model);
            }
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}