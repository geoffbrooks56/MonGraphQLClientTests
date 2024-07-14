using Xunit;
using MonGraphQLClient;
using Microsoft.Extensions.Logging;

namespace MonGraphQLClientTests;

[Collection("MonGraphQLClientTests collection")]
public class MonQueryTests
{
	readonly BaseFixture fixture;
	readonly ILogger logger;

	public MonQueryTests(BaseFixture fixture)
	{
		this.fixture = fixture;
		this.logger = fixture.LoggerFactory.CreateLogger<MonBoardTests>();
	}

	[Fact]
	public void BuildSimpleQueryTest()
	{
		/*
		{
			"query": "query {boards (ids: 6422224156) {groups {title id}}}" 
		}
		 */

		Query query = new()
		{
			OperationType = OperationTypeStrings.Query,
			ObjectType = "query",		
		};

		query.Argument.Name = "boards";
		query.Argument.Variables.Add(new() { Name = "ids", Value = fixture.BoardID });

		Variable groupVar = new()
		{
			Name = "groups",
			SubVariables = []
		};

		groupVar.SubVariables.Add(new() { Name = "title" });
		groupVar.SubVariables.Add(new() { Name = "id" });

		query.Outputs.Add(groupVar);

		string queryString = QueryBuilder.Parse(query);

	}
}