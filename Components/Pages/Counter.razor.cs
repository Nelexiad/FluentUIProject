
using FluentCumbia.Managers;
using Microsoft.AspNetCore.Components;
using FluentCumbia.Models.FinalFantasy;

namespace FluentCumbia.Components.Pages
{
    public partial class Counter
    {
       [Inject] FinalFantasyManager _finalFantasyManager {  get; set; }


        protected IQueryable<Character> CharactersFF;

        protected override async Task OnInitializedAsync()
        {
            var list = await _finalFantasyManager.GetCharactersAsync();
            CharactersFF = list.AsQueryable();
        }
    }
}
