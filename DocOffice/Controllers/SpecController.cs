using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DocOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DocOffice.Controllers
{
  public class SpecController : Controller
  {
    private readonly DocOfficeContext _db;

    public SpecController(DocOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Spec> model = _db.Specs.ToList();
      return View(model);
    }
  

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Spec spec)
  {
    _db.Specs.Add(spec);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    var thisSpec = _db.Specs
        .Include(spec => spec.JoinEntities)
        .ThenInclude(join => join.Doctor)
        .FirstOrDefault(spec => spec.SpecId == id);
    return View(thisSpec);
  }

  public ActionResult Delete(int id)
    {
    var thisSpec = _db.Specs.FirstOrDefault(spec => spec.SpecId == id);
    return View(thisSpec);
    }
  }
}