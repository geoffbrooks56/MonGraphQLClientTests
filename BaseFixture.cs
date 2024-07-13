using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MonGraphQLClientTests;

public class BaseFixture : IDisposable
{
	public string BoardID;
	public string APIKey;
	public string APIUrl;
	public ILoggerFactory LoggerFactory;

	public BaseFixture()
	{
		var config = new ConfigurationBuilder()
			.AddJsonFile("local.settings.json")
			.Build();

		BoardID = config.GetSection("Values:MondayMasterBoardId").Value;
		APIKey = config.GetSection("Values:MondayAPIToken").Value;
		APIUrl = config.GetSection("Values:MondayURL").Value;

		Environment.SetEnvironmentVariable("MondayAPIToken", APIKey);
		Environment.SetEnvironmentVariable("MondayURL", APIUrl);
		Environment.SetEnvironmentVariable("MondayMasterBoardId", BoardID);

		var serviceProvider = new ServiceCollection()
			.AddLogging()
			.BuildServiceProvider();

		LoggerFactory = serviceProvider.GetService<ILoggerFactory>();
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	
	}


