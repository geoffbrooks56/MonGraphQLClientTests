using Microsoft.Extensions.Configuration;

namespace MonGraphQLClientTests;
public class BaseFixture : IDisposable
{
	public string BoardID;
	public string APIKey;
	public string APIUrl;
	public HttpClient HttpClient { get; set; }

	public BaseFixture()
	{
		var config = InitConfiguration();

		BoardID = config.GetSection("Values:MondayMasterBoardId").Value;
		APIKey = config.GetSection("Values:MondayAPIToken").Value;
		APIUrl = config.GetSection("Values:MondayURL").Value;
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	public static IConfiguration InitConfiguration()
	{
		var config = new ConfigurationBuilder()
		    .AddJsonFile("local.settings.json")			
			.Build();

		return config;
	}
}
