using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EggHuntApp.Models;
using EggHuntApp.Data;

namespace EggHuntApp.Pages;

public class LeaderboardModel : PageModel
{
    private readonly EggHuntContext _context;
    public LeaderboardModel(EggHuntContext context)
    {
        _context = context;
    }

    public List<LeaderboardEntry> Leaderboard { get; set; } = new();

    public async Task OnGetAsync()
    {
        Leaderboard = await _context.EggsFound
            .GroupBy(e => e.Username)
            .Select(g => new LeaderboardEntry
            {
                Username = g.Key,
                EggCount = g.Count(),
                LastFound = g.Max(e => e.FoundAt)
            })
            .OrderByDescending(e => e.EggCount)
            .ToListAsync();
    }

    public class LeaderboardEntry
    {
        public string Username { get; set; } = "";
        public int EggCount { get; set; }
        public DateTime LastFound { get; set; }
    }
}


