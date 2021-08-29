using Microsoft.AspNetCore.Mvc;
using Practica01_Lab.Models;
using Practica01_Lab.Data;
using System.Linq;

namespace Practica01_Lab.Controllers
{
    public class ProductoController:Controller
    {
         private readonly ApplicationDBContext _context;

         public ProductoController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.DataProductos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto objProducto)
        {
            _context.Add(objProducto);
            _context.SaveChanges();
            ViewData["Message"] = "El producto ya esta registrado"; 
            return View();
        }

        public IActionResult Edit(int id)
        {
            Producto objProducto=_context.DataProductos.Find(id);
            if(objProducto==null){
                return NotFound();
            }

            return View(objProducto);
        }

        [HttpPost]

        public IActionResult Edit(int id,[Bind("Id,Email,Name,Phone,Comment,Gender")] Producto objProducto)
        {
            _context.Update(objProducto);
            _context.SaveChanges();
            ViewData["Message"] = "El producto ha sido actualizado";
            return View(objProducto);
        }

        public IActionResult Delete(int id)
        {
            Producto objProducto=_context.DataProductos.Find(id);
            _context.DataProductos.Remove(objProducto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}