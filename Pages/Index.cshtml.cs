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

        //public async Task <IActionResult>OnPostFoundEggAsync()
        //{
        //    using var reader = new StreamReader(Request.Body);
        //    var body = await reader.ReadToEndAsync();
        //        var egg = JsonSerializer.Deserialize<EggFound>(body);
        //    if (egg is null || string.IsNullOrEmpty(egg.Username)) return BadRequest();
        //    _context.EggsFound.Add(egg);
        //    await _context.SaveChangesAsync();
        //    return new JsonResult(new { success = true });
        //}
        public async Task<IActionResult> OnPostFoundEggAsync()
        {
            try
            {
                using var reader = new StreamReader(Request.Body);
                var body = await reader.ReadToEndAsync();

                var egg = JsonSerializer.Deserialize<EggFound>(body); // No longer needs special options


                if (egg is null || string.IsNullOrEmpty(egg.Username))
                {
                    return BadRequest("Invalid EggFound data.");
                }

                // Important: explicitly set FoundAt if you don't trust client timestamps
                egg.FoundAt = DateTime.UtcNow;

                _context.EggsFound.Add(egg);
                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true });
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON deserialization error: {ex.Message}");
                return BadRequest("Error deserializing JSON.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in FoundEgg: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

    }
}