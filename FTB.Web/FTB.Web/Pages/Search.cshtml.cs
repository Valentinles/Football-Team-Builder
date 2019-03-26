using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FTB.Data;
using FTB.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FTB.Web.Pages
{
    public class SearchModel : PageModel
    {
        public SearchModel(FtbContext context)
        {
            this.Context = context;
            this.SearchResults = new List<SearchViewModel>();
        }

        public FtbContext Context { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<SearchViewModel> SearchResults { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(this.SearchTerm))
            {
                return;
            }

            var foundTeams = this.Context.Teams
                .Where(t => t.Name.Contains(SearchTerm))
                .OrderBy(t => t.Name)
                .Select(t => new SearchViewModel()
                {
                    SearchResult=t.Name,
                    Id=t.Id,
                    Type="Team"
                }).ToList();

            var foundPlayers = this.Context.Players
                .Where(p => p.PlayerName.Contains(SearchTerm))
                .OrderBy(p => p.PlayerName)
                .Select(p => new SearchViewModel()
                {
                    SearchResult=p.PlayerName,
                    Id=p.Id,
                    Type="Player"
                }).ToList();

            this.SearchResults.AddRange(foundTeams);
            this.SearchResults.AddRange(foundPlayers);

            foreach (var result in SearchResults)
            {
                string markedResult=Regex.Replace(
                    result.SearchResult, 
                    $"({this.SearchTerm})",
                    match=>$"<strong class= \"text-danger\">{match.Groups[0].Value}</strong>",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);
                result.SearchResult = markedResult;
            }
        }
    }
}