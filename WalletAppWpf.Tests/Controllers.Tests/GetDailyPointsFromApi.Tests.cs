using FluentAssertions;
using System.Text.RegularExpressions;
using WalletAppWPF.Controller;

namespace WalletAppWpf.Tests.Controllers.Tests
{
    public class GetDailyPointsFromApiTests
    {
        [Fact]
        public async Task GetDailyPointsFromApi_GetDailyPointsField_Should_Return_String()
        {
            // Arrange
            GetDailyPointsFromApi getDailyPointsFromApi = new GetDailyPointsFromApi();

            // Act
            string result = await getDailyPointsFromApi.GetDailyPointsField();
            string regex = Regex.Match(result,@"\d+").Value;
            int.TryParse(regex, out int points);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            points.Should().BeGreaterOrEqualTo(0);

            if (points > 1000)
            {
                result.Should().MatchRegex(@"^\d+K$"); // if points > 1000 => "{points}K"
            }
            else
            {
                result.Should().MatchRegex(@"^\d+$"); // if points <= 1000 => points
            }

        }
    }
}