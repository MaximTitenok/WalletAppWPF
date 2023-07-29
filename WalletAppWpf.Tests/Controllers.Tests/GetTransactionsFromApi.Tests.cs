using FluentAssertions;
using System.Security.RightsManagement;
using System.Text.RegularExpressions;
using WalletAppWPF.Controller;
using WalletAppWPF;
using WalletAppWPF.Models;

namespace WalletAppWpf.Tests.Controllers.Tests
{
    public class GetTransactionsFromApiTests
    {


        [Theory]
        [InlineData(2)]
        public async Task GetTransactionsFromApi_GetTransactions_Should_Return_TransactionsList(int userId)
        {
            // Arrange
            var getTransactions = new GetTransactionsFromApi();
            // Act
            var result = await getTransactions.GetTransactions(userId);

            // Assert
            result.Should().NotBeNull(); 
            result.Should().BeAssignableTo<IEnumerable<LatestTransactions>>(); 
        }
        [Theory]
        [InlineData(1, 1)] 
        public async Task GetTransactionsFromApi_GetTransaction_ShouldReturnValidTransaction(int userId, long transactionId)
        {
            // Act
            var getTransactions = new GetTransactionsFromApi();
            var result = await getTransactions.GetTransaction(userId, transactionId);
            
            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<LatestTransactions>();
        }
    }
}