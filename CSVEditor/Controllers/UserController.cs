namespace CSVEditor.Controllers;

using Data;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class UserController : Controller
{
    private CSVDbContext _dbcontext;

    public UserController(CSVDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _dbcontext.UserRecords.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file is null || file.Length == 0)
        {
            ErrorLogger.LogError(new Exception("File is empty or null"));
            return BadRequest("File is empty or null");
        }
        
        using  Stream stream = file.OpenReadStream();
        
        List<UserRecord> recs = CSVReader.ReadCSV(stream, out List<string> csvErrors);

        foreach (string error in csvErrors)
        {
            ModelState.AddModelError("", error);
            ErrorLogger.LogError(new Exception(error));
        }

        foreach (UserRecord? rec in recs)
        {
            ValidationContext context = new ValidationContext(rec);
            List<ValidationResult> results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(rec, context, results, true))
            {
                foreach (ValidationResult r in results)
                {
                    ModelState.AddModelError("", r.ErrorMessage);
                    ErrorLogger.LogError(new Exception(r.ErrorMessage));
                }
            }
        }

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.
                SelectMany(v => v.Errors).
                Select(e => e.ErrorMessage).ToList();
            return BadRequest(new {csvErrors = errors});
        }
        
        await _dbcontext.AddRangeAsync(recs);
        await _dbcontext.SaveChangesAsync();

        return Ok(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UserRecord record)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState.Values.
            SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
        
        _dbcontext.Update(record);
        
        await _dbcontext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var record = await _dbcontext.UserRecords.FindAsync(id);
        
        if(record is null) return NotFound("Record not found");
        
        _dbcontext.Remove(record);
        
        await _dbcontext.SaveChangesAsync();
        return Ok();
    }
}