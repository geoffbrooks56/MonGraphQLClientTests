using Xunit;
using MonGraphQLClient;
using Microsoft.Extensions.Logging;

namespace MonGraphQLClientTests;

[Collection("MonGraphQLClientTests collection")]
public class MonBoardTests
{
	readonly BaseFixture fixture;
	readonly ILogger logger;

	public MonBoardTests(BaseFixture fixture)
	{
		this.fixture = fixture;	
		this.logger = fixture.LoggerFactory.CreateLogger<MonBoardTests>();
	}

	[Fact]
	public void BasicSettingsTest()
	{	
		Assert.False(string.IsNullOrEmpty(fixture.BoardID));

		Assert.False(string.IsNullOrEmpty(fixture.APIKey));

		Assert.False(string.IsNullOrEmpty(fixture.APIUrl));
	}

	[Fact]
	public async Task GetMasterBoardByBoardIdTest()
	{
		List<MonGroup> groupsForBoard =  await Agent.QueryBoardGroups(fixture.BoardID, logger);

		Assert.True(groupsForBoard.Count > 0);
	}

	[Fact]
	public async Task AddDeleteGroupTest()
	{		
		MonGroup group = new()
		{
			BoardId = fixture.BoardID,
			Title = "Test Group"
		};

		group.GroupId = await Agent.AddMonGroup(group, logger);

		Assert.False(string.IsNullOrEmpty(group.GroupId));

		//-------------------------------------------------------------------------------------------

		bool groupDeleteOk = await Agent.DeleteMonGroup(fixture.BoardID, group.GroupId, logger);

		Assert.True(groupDeleteOk);
	}	
}