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
	public async Task BasicSettingsTest()
	{
		await Task.Delay(10);

		string boardid = fixture.BoardID;

		string apiKey = fixture.APIKey;

		string apiUrl = fixture.APIUrl;

		Assert.False(string.IsNullOrEmpty(boardid));

		Assert.False(string.IsNullOrEmpty(apiKey));

		Assert.False(string.IsNullOrEmpty(apiUrl));
	}

}

