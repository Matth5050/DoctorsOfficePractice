using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DocOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DocOffice.Controllers
{
  public class DoctorController : Controller
  {
    private readonly DocOfficeContext _db;

    public DoctorController(DocOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Doctors.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.SpecId = new SelectList(_db.Specs, "SpecId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor, int SpecId)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      if (SpecId != 0)
      {
        _db.SpecDoctor.Add(new SpecDoctor() { SpecId = SpecId, DoctorId = doctor.DoctorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

     public ActionResult AddSpec(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      ViewBag.SpecId = new SelectList(_db.Specs, "SpecId", "Name");
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult AddSpec(Doctor doctor, int SpecId)
    {
      if (SpecId != 0)
      {
        _db.SpecDoctor.Add(new SpecDoctor() { SpecId = SpecId, DoctorId = doctor.DoctorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
    var thisDoctor = _db.Doctors
        .Include(doctor => doctor.JoinEntities)
        .ThenInclude(join => join.Spec)
        .FirstOrDefault(doctor => doctor.DoctorId == id);
    return View(thisDoctor);
    }

    public ActionResult Edit(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      ViewBag.SpecId = new SelectList(_db.Specs, "SpecId", "Name");
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult Edit(Doctor doctor, int SpecId)
    {
      if (SpecId != 0)
      {
        _db.SpecDoctor.Add(new SpecDoctor() { SpecId = SpecId, DoctorId = doctor.DoctorId });
      }
      _db.Entry(doctor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
    var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
    return View(thisDoctor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
    var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
    _db.Doctors.Remove(thisDoctor);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  [HttpPost]
  public ActionResult DeleteSpec(int joinId)
  {
    var joinEntry = _db.SpecDoctor.FirstOrDefault(entry => entry.SpecDoctorId == joinId);
    _db.SpecDoctor.Remove(joinEntry);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}
}