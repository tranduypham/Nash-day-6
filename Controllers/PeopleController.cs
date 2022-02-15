using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET.mvc.crud.Models;
using System.Net;

namespace ASP.NET.mvc.crud.Controllers;

public class PeopleController : Controller
{
    private readonly ILogger<PeopleController> _logger;

    public PeopleController(ILogger<PeopleController> logger)
    {
        _logger = logger;
    }

    public static List<PersonModel> people = new List<PersonModel>{
            new PersonModel{
                Id = 1,
                LastName = "Pham",
                FirstName = "Duy",
                Gender = "Male"
            },
            new PersonModel{
                Id = 2,
                LastName = "Hoang",
                FirstName = "Giay",
                Gender = "Female"
            },
            new PersonModel{
                Id = 3,
                LastName = "Le",
                FirstName = "Hoang",
                Gender = "Male"
            },
        };
    public IActionResult Index(){
        return View(people);
    }

    public IActionResult Add(){
        return View();
    }
    [HttpPost]
    public IActionResult Add(PersonModel person){
        var newPerson = new PersonModel{
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender
        };
        people.Add(newPerson);
        return RedirectToAction("Index");
        // return Content($"Name: {person.FirstName} {person.LastName}, Gender: {person.Gender}");
    }
    public IActionResult Edit(int id){
        var person = (from per in people
                    where per.Id == id
                    select per).ToList().First();
        // var person = people.Where(x=>x.)
        if(person!=null){
            return View(person);
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Edit(PersonModel person){
        // var editPerson = (from per in people
        //             where per.Id == person.Id
        //             select per).ToList().First();
        var editPerson = people.Where(x=>x.Id == person.Id).FirstOrDefault();
        if(editPerson!=null){
            editPerson.LastName = person.LastName;
            editPerson.FirstName = person.FirstName;
            editPerson.Gender = person.Gender;
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Delete(int id){
        var deletePerson = people.Where(x=>x.Id == id).FirstOrDefault();
        if(deletePerson!=null){
            if(people.Remove(deletePerson))
                return Ok();
        }
        return NotFound();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
