using FluentCumbia.Models.FinalFantasy;

namespace FluentCumbia.Services
{
	public class FinalFantasyService
	{
		public async Task<List<Character>> GetCharacterList()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://www.moogleapi.com/api/v1/characters"),
				
			};
			var response = await client.SendAsync(request);
			string json = await response.Content.ReadAsStringAsync();

			List<Character> characters = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Character>>(json);
			return characters;
		}
	}
}
