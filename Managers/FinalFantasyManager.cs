using FluentCumbia.Models.FinalFantasy;
using FluentCumbia.Services;

namespace FluentCumbia.Managers
{
    public class FinalFantasyManager
    {
        protected FinalFantasyService _finalFantasyService { get; set; }

        public FinalFantasyManager(FinalFantasyService finalFantasyService)
        {
            _finalFantasyService = finalFantasyService;
        }

        protected List<Character> charQuery { get; set; }
        public async Task<List<Character>> GetCharactersAsync()
        {
            if (charQuery == null)
            {
                var responseList = await _finalFantasyService.GetCharacterList();
                charQuery = responseList;
                return charQuery;

            }
            else { return charQuery; }
        }
    }
}
