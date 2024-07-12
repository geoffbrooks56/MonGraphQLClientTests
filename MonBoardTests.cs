using Xunit;
using MonGraphQLClient;
using Microsoft.Extensions.Logging;

namespace MonGraphQLClientTests;

[Collection("MonGraphQLClientTests collection")]
public class MonBoardTests
{
	BaseFixture fixture;
	ILogger logger;

	public MonBoardTests(BaseFixture fixture)
	{
		this.fixture = fixture;	
		this.logger = fixture.LoggerFactory.CreateLogger<MonBoardTests>();
	}

	[Fact]
	public async Task BasicSettingsTest()
	{
		await Task.Delay(10);

		Assert.False(string.IsNullOrEmpty(fixture.BoardID));

		Assert.False(string.IsNullOrEmpty(fixture.APIKey));

		Assert.False(string.IsNullOrEmpty(fixture.APIUrl));
	}

	[Fact]
	public async Task GetMasterBoardByBorardIdTest()
	{
		List<MonGroup> groupsForBoard =  await Agent.QueryBoardGroups(fixture.BoardID, logger);

		Assert.True(groupsForBoard.Any());
	}
}

