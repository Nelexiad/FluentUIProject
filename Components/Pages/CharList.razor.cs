using FluentCumbia.Managers;
using FluentCumbia.Models.FinalFantasy;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;




namespace FluentCumbia.Components.Pages
{
	public partial class CharList

	{
		[Inject] protected FinalFantasyManager _finalFantasyManager { get; set; }
        string nameFilter = string.Empty;
        bool _clearItems = false;

        protected IQueryable<Character> Characters;

        Func<Character, string?> rowClass = x => x.Name.StartsWith("A") ? "highlighted-row" : null;
        Func<Character, string?> rowStyle = x => x.Name.StartsWith("Au") ? "background-color: var(--highlight-bg);" : null;

        IQueryable<Character>? FilteredItems => Characters?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));
        private void HandleCountryFilter(ChangeEventArgs args)
        {
            if (args.Value is string value)
            {
                nameFilter = value;
            }
        }

        private void HandleClear()
        {
            if (string.IsNullOrWhiteSpace(nameFilter))
            {
                nameFilter = string.Empty;
            }
        }
        private async Task ToggleItemsAsync()
        {
            if (_clearItems)
            {
                Characters = null;
            }
            else
            {
                Characters = (await _finalFantasyManager.GetCharactersAsync()).AsQueryable();
            }
        }
        protected override async Task OnInitializedAsync()
		{
			var list = await _finalFantasyManager.GetCharactersAsync();
			Characters = list.AsQueryable();
		}

	}
}
