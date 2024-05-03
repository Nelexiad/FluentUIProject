using FluentCumbia.Models.FinalFantasy;
using FluentCumbia.Services;

namespace FluentCumbia.Managers
{
	public class FinalFantasyManager
	{
		protected FinalFantasyService _finalFantasyService {  get; set; }

		public FinalFantasyManager(FinalFantasyService finalFantasyService)
		{
			_finalFantasyService = finalFantasyService;
		}

		public async Task<List<Character>> GetCharactersAsync()
		{
			return await _finalFantasyService.GetCharacterList();
		}
	}
}
