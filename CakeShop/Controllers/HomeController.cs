using CakeShop.Data; // �[�J using
using CakeShop.Models; // �[�J using
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // �[�J using
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Linq; // �[�J using
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks; // �[�J using

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        /*   readonly (��Ū��):�o�O�@�ӭ׹����A�M���Ω���쥦���ܳo����쪺��
             �u��b��Ӧa��Q�]�w�G
           1. �b�ŧi��쪺�P�ɶi���l��?�ȡG
           2. �b�����O���غc�禡�����i��?�ȡG
           _context �o�����u��b�]�t�����������O�]�Ҧp HomeController�^�����Q�s�� (private)�C
           _context �o����쪺�ȥu��b����Q�إ߮ɡ]�b�غc�禡���^�Q��Ȥ@���A����N����A���ܥ��ҤޥΪ�����
           (readonly)�C
         */
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // �`�J DbContext

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) // �ק�غc�禡
        {
            _logger = logger;
            _context = context; // ���
        }

        // �ק� Index ��k�� async �ìd�߳J�|
        public async Task<IActionResult> Index()
        {
            // �d�ߤ@�ǳJ�|����ܦb������ (�Ҧp�G���e 5 ���A�Υ��ӥi�[�W IsFeatured ���ҿz��)
            // �T�O Cake �ҫ��� ImageUrl �ݩ�
            var carouselCakes = await _context.Cakes
                                            .Where(c => !string.IsNullOrEmpty(c.ImageUrl)) // �u�靈�Ϥ���
                                            .OrderBy(c => Guid.NewGuid()) // �H���Ƨ� (�Ϋ� ID, �W�ٵ�)
                                            .Take(5) // ���̦h 5 ��
                                            .ToListAsync();

            // �N�J�|�C���ǻ��� View
            return View(carouselCakes);
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