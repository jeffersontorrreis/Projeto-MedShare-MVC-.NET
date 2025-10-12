using MedShare.Context;
using MedShare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedShare.Controllers {
    public class DoadorsController : Controller {
        private readonly AppDbContext _context;
        public DoadorsController(AppDbContext context) {
            _context = context;
        }

        /*Função que traz os atributos da classe Doador e mostra na tela.*/
        public async Task<IActionResult> Index() {
            var dados = await _context.Doadors.ToListAsync();

            return View(dados);
        }

        /*Abaixo a função que representa get para recuperação dos dados inseridos*/
        public IActionResult Create() 
        {
            return View();
        }

        /*Abaixo a função que representa post para inserir dados*/
        [HttpPost]
        public async Task<IActionResult> Create(Doador doador) 
        {
            if (ModelState.IsValid) 
            {
                _context.Doadors.Add(doador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(doador);
        }
    }
}
