using FluentCumbia.Managers;
using FluentCumbia.Models.FinalFantasy;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Net.Http.Headers;




namespace FluentCumbia.Components.Pages
{
	public partial class CharList

	{
		[Inject] protected FinalFantasyManager _finalFantasyManager { get; set; }



		protected IQueryable<Character> Characters;

		protected override async Task OnInitializedAsync()
		{
			var list = await _finalFantasyManager.GetCharactersAsync();
			Characters = list.AsQueryable();
		}

	}
}
