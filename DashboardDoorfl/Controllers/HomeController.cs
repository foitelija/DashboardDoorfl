using DashboardDoorfl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DashboardDoorfl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MessageDbContext _context;

        public HomeController(ILogger<HomeController> logger, MessageDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int pg = 1)
        {
            var items = _context.IncomingMessages.ToList();

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = _context.IncomingMessages.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Index(DateTime start, DateTime end, string reciver, string regNum)
        {

            var response = await _context.IncomingMessages.ToListAsync();

            if (!String.IsNullOrEmpty(reciver))
            {
                response = response.Where(x => x.Reciever.Contains(reciver)).ToList();
            }
            if(start > DateTime.MinValue)
            {
                response = response.Where(x => x.RegDate == start).ToList();
            }
            if(end > DateTime.MinValue && start > DateTime.MinValue)
            {
                response = response.Where(x => x.RegDate >= start && x.RegDate <= end).ToList();
            }
            if (!String.IsNullOrEmpty(regNum))
            {
                response = response.Where(x => x.RegNum.Contains(regNum)).ToList();
            }

            return View(response);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var message = _context.IncomingMessages.FirstOrDefault(e => e.IncomingMessageID == id);

            var result = new MessagesModel()
            {
                IncomingMessageID = id,
                RegNum = message.RegNum,
                RegDate = message.RegDate,
                Status = message.Status
            };

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(MessagesModel model)
        {
            _context.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
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