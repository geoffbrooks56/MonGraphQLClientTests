using Xunit;

namespace MonGraphQLClientTests;

[Collection("MonGraphQLClientTests collection")]
public class MonBoardTests
{
	BaseFixture fixture;
	public MonBoardTests(BaseFixture fixture)
	{
		this.fixture = fixture;
	}

	[Fact]
	public async Task Test1()
	{
		await Task.Delay(100);

		string boardid = fixture.BoardID;

		string apiKey = fixture.APIKey;

		string apiUrl = fixture.APIUrl;

		Assert.False(string.IsNullOrEmpty(boardid));

		Assert.False(string.IsNullOrEmpty(apiKey));

		Assert.False(string.IsNullOrEmpty(apiUrl));
	}

}

