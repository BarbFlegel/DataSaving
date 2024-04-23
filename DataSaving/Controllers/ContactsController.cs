using DataSaving.Data;
using DataSaving.Models;
using DataSaving.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataSaving.Controllers;
public class ContactsController : Controller
{
    private readonly ApplicationDbContext dbContext;

    public ContactsController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddContactViewModel viewModel)
    {
        var contact = new Contact
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            Phone = viewModel.Phone
        };

        await dbContext.Contacts.AddAsync(contact);
        _ = await dbContext.SaveChangesAsync();

        return RedirectToAction("List", "Contacts");
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var contacts = await dbContext.Contacts.ToListAsync();
        return View(contacts);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var contact = await dbContext.Contacts.FindAsync(id);
        return View(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Contact viewModel)
    {
        var contact = await dbContext.Contacts.FindAsync(viewModel.Id);
        if (contact is not null)
        {
            contact.FirstName=viewModel.FirstName;
            contact.LastName=viewModel.LastName;
            contact.Email=viewModel.Email;  
            contact.Phone=viewModel.Phone;

            await dbContext.SaveChangesAsync();
        }

        return RedirectToAction("List", "Contacts");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Contact viewModel)
    {
        var contact = await dbContext.Contacts
            .AsNoTracking()
            .FirstOrDefaultAsync(x=> x.Id == viewModel.Id);
        if (contact is not null)
        {
            dbContext.Contacts.Remove(viewModel);
            await dbContext.SaveChangesAsync();
        }
        return RedirectToAction("List", "Contacts");
    }
}
