using Xunit;
using MonGraphQLClient;
using Microsoft.Extensions.Logging;
using MonGraphQLClientTests.Attributes;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestCollectionOrderer(ordererTypeName: "MonGraphQLClientTests.PriorityOrderer",ordererAssemblyName: "MonGraphQLClientTests")]

namespace MonGraphQLClientTests;

[Collection("MonGraphQLClientTests collection")]
[TestCaseOrderer(ordererTypeName: "MonGraphQLClientTests.PriorityOrderer", ordererAssemblyName: "MonGraphQLClientTests")]
public class MonBoardTests
{
	BaseFixture fixture;
	ILogger logger;

	string groupIdToDelete;

	public MonBoardTests(BaseFixture fixture)
	{
		this.fixture = fixture;	
		this.logger = fixture.LoggerFactory.CreateLogger<MonBoardTests>();
	}

	[Fact, TestPriority(1)]
	public async Task BasicSettingsTest()
	{
		await Task.Delay(2000);

		Assert.False(string.IsNullOrEmpty(fixture.BoardID));

		Assert.False(string.IsNullOrEmpty(fixture.APIKey));

		Assert.False(string.IsNullOrEmpty(fixture.APIUrl));
	}

	[Fact, TestPriority(2)]
	public async Task GetMasterBoardByBoardIdTest()
	{
		await Task.Delay(2000);

		List<MonGroup> groupsForBoard =  await Agent.QueryBoardGroups(fixture.BoardID, logger);

		Assert.True(groupsForBoard.Count > 0);
	}

	[Fact, TestPriority(3)]
	public async Task AddGroupTest()
	{
		await Task.Delay(2000);

		MonGroup group = new()
		{
			BoardId = fixture.BoardID,
			Title = "AddGroupTest Test Group"
		};

		group.GroupId = await Agent.AddMonGroup(group, logger);

		groupIdToDelete = group.GroupId;

		Assert.False(string.IsNullOrEmpty(group.GroupId));
	}

	[Fact, TestPriority(4)]
	public async Task DeleteGroupTest()
	{
		await Task.Delay(2000);

		MonGroup group = new()
		{
			BoardId = fixture.BoardID,
			
		};

		bool groupDeleteOk = await Agent.DeleteMonGroup(fixture.BoardID, groupIdToDelete, logger);

		Assert.True(groupDeleteOk);
	}
}

