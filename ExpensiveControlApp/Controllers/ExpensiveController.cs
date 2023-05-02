using ExpensiveControlApp.DTOs;
using ExpensiveControlApp.Models;
using ExpensiveControlApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpensiveControlApp.Controllers
{
    public class ExpensiveController : Controller
    {
        private readonly ILogger<ExpensiveController> _logger;
        private readonly IExpensiveServices _expensiveServices;

        public ExpensiveController(ILogger<ExpensiveController> logger, IExpensiveServices expensiveServices)
        {
            _logger = logger;
            _expensiveServices= expensiveServices;
        }

        public async Task<IActionResult> Index()
        {
            ListExpensiveDTO listExpensiveDTO = new ListExpensiveDTO();
            listExpensiveDTO.Itens = await _expensiveServices.FindBy(listExpensiveDTO.StartDate, listExpensiveDTO.EndDate);
            return View(listExpensiveDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ListExpensiveDTO listExpensiveDTO)
        {
            try
            {
                listExpensiveDTO.Itens = await _expensiveServices.FindBy(listExpensiveDTO.StartDate, listExpensiveDTO.EndDate);
                return View(listExpensiveDTO);
            }
            catch(Exception wx)
            {
                ModelState.AddModelError("Custom Error", wx.Message);
                return View(listExpensiveDTO);
            }
          
        }
       
        public async Task<IActionResult> Creat()
        {
            CreateExpensiveDTO createExpensiveDTO = new CreateExpensiveDTO();
            return View(createExpensiveDTO);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creat(CreateExpensiveDTO createExpensiveDTO)
        {
            try 
            {
                await _expensiveServices.create(createExpensiveDTO);
                return RedirectToAction("index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);
                return View(createExpensiveDTO);
            }
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}