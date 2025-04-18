using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EggHuntApp.Models;
using EggHuntApp.Data;
using System.Text.Json;

namespace EggHuntApp.Pages
{ 
 public class IndexModel : PageModel
 {
    private readonly EggHuntContext _context;
    public IndexModel(EggHuntContext context)
    {
        _context = context;
    }

    public async Task <IActionResult>OnPostFoundEggAsync()
    {
        using var reader = new StreamReader(Request.Body);
        var body = await reader.ReadToEndAsync();
        var egg = JsonSerializer.Deserialize<EggFound>(body);
        if (egg is null || string.IsNullOrEmpty(egg.Username)) return BadRequest();
        _context.EggsFound.Add(egg);
        await _context.SaveChangesAsync();
        return new JsonResult(new { success = true });
    }
 }
}