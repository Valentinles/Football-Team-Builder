using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FTB.Data;
using FTB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FTB.Web.Pages.Players
{
    public class AddModel : PageModel
    {
        public AddModel(FtbContext context)
        {
            this.Context = context;
        }

        public FtbContext Context { get; set; }

        [BindProperty]
        [Display(Name = "Team")]
        public int TeamId{ get; set; }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string PlayerName { get; set; }

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public string Biography { get; set; }

        [BindProperty]
        public string PlayerImage { get; set; }

        public IEnumerable<SelectListItem> Teams { get; set; }

        public void OnGet()
        {
            this.Teams = this.Context.Teams.Select(t => new SelectListItem()
            {
                Text = t.Name,
                Value = t.Id.ToString()
            })
            .ToList();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var team = this.Context.Teams.Find(TeamId);


            var player = new Player()
            {
                PlayerName = this.PlayerName,
                Age = this.Age,
                Biography = this.Biography,
                PlayerImage = this.PlayerImage,
                TeamId = team.Id
            };
            this.Context.Players.Add(player);
            this.Context.SaveChanges();
            return RedirectToPage("/Players/Information", new { id = player.Id });
        }
    }
}