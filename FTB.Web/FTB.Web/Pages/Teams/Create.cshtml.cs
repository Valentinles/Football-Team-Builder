using System.ComponentModel.DataAnnotations;
using FTB.Data;
using FTB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FTB.Web.Pages.Teams
{
    public class CreateModel : PageModel
    {
        public CreateModel(FtbContext context)
        {
            this.Context = context;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Nationality { get; set; }

        [BindProperty]
        public string League { get; set; }

        [BindProperty]
        [DataType(DataType.ImageUrl)]
        [Display(Name="Crest")]
        public string TeamLogo { get; set; }

        public FtbContext Context { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var team = new Team()
            {
                Name = this.Name,
                Nationality = this.Nationality,
                League = this.League,
                TeamLogo = this.TeamLogo
            };
            this.Context.Teams.Add(team);
            this.Context.SaveChanges();
            return RedirectToPage("/Teams/AllTeams");
        }
    }
}