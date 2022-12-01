using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprenderMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AprenderMVC.Controllers
{
    public class InscritosController : Controller
    {
        private readonly AprenderMVCContext _context;

        public InscritosController(AprenderMVCContext context)
        {
            _context = context;
        }

        // GET: Inscritos
        public async Task<IActionResult> Index()
        {
            var aprenderMVCContext = _context.Inscrito.Include(i => i.Pessoa).Include(i => i.Turma);
            return View(await aprenderMVCContext.ToListAsync());
        }

        // GET: Inscritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscrito == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscrito
                .Include(i => i.Pessoa)
                .Include(i => i.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscrito == null)
            {
                return NotFound();
            }

            return View(inscrito);
        }

        // GET: Inscritos/Create
        public IActionResult Create()
        {
            ViewData["IdPessoa"] = new SelectList(_context.Pessoa, "Id", "Id");
            ViewData["IdTurma"] = new SelectList(_context.Turma, "Id", "Id");
            ViewBag.PessoaDesc = new SelectList(_context.Pessoa, "Id", "Nome");
            ViewBag.CursoDesc = new SelectList(_context.Turma, "Id", "Curso.Descricao");
            return View();
        }

        // POST: Inscritos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTurma,IdPessoa,Nota,Resultado")] Inscrito inscrito)
        {
            if (ModelState.IsValid)
            {
                // usando a regra de negocio para, conforme a nota, gravar tipodeAprovacao
                Inscrito mod = new Inscrito();
                var sResultado = mod.VerificaAprovacao(inscrito.Nota);
                inscrito.Resultado = sResultado;

                _context.Add(inscrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPessoa"] = new SelectList(_context.Pessoa, "Id", "Id", inscrito.IdPessoa);
            ViewData["IdTurma"] = new SelectList(_context.Turma, "Id", "Id", inscrito.IdTurma);
            ViewBag.PessoaDesc = new SelectList(_context.Pessoa, "Id", "Nome", inscrito.IdPessoa);
            ViewBag.CursoDesc = new SelectList(_context.Turma, "Id", "Curso.Descricao",inscrito.IdTurma);
            return View(inscrito);
        }

        // GET: Inscritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscrito == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscrito.FindAsync(id);
            if (inscrito == null)
            {
                return NotFound();
            }
            ViewData["IdPessoa"] = new SelectList(_context.Pessoa, "Id", "Id", inscrito.IdPessoa);
            ViewData["IdTurma"] = new SelectList(_context.Turma, "Id", "Id", inscrito.IdTurma);
            ViewBag.PessoaDesc = new SelectList(_context.Pessoa, "Id", "Nome", inscrito.IdPessoa);
            ViewBag.CursoDesc = new SelectList(_context.Turma, "Id", "Curso.Descricao", inscrito.IdTurma);
            return View(inscrito);
        }

        // POST: Inscritos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTurma,IdPessoa,Nota,Resultado")] Inscrito inscrito)
        {
            if (id != inscrito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscritoExists(inscrito.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPessoa"] = new SelectList(_context.Pessoa, "Id", "Id", inscrito.IdPessoa);
            ViewData["IdTurma"] = new SelectList(_context.Turma, "Id", "Id", inscrito.IdTurma);
            ViewBag.PessoaDesc = new SelectList(_context.Pessoa, "Id", "Nome", inscrito.IdPessoa);
            ViewBag.CursoDesc = new SelectList(_context.Turma, "Id", "Curso.Descricao", inscrito.IdTurma);
            return View(inscrito);
        }

        // GET: Inscritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscrito == null)
            {
                return NotFound();
            }

            var inscrito = await _context.Inscrito
                .Include(i => i.Pessoa)
                .Include(i => i.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscrito == null)
            {
                return NotFound();
            }

            return View(inscrito);
        }

        // POST: Inscritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscrito == null)
            {
                return Problem("Entity set 'AprenderMVCContext.Inscrito'  is null.");
            }
            var inscrito = await _context.Inscrito.FindAsync(id);
            if (inscrito != null)
            {
                _context.Inscrito.Remove(inscrito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscritoExists(int id)
        {
            return _context.Inscrito.Any(e => e.Id == id);
        }
    }
}
