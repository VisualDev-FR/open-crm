using OpenCRM.Controllers;
using Moq;
using OpenCRM.Interfaces;
using OpenCRM.Dtos;

namespace OpenCRM.Tests.Controllers;


public class AuthControllerTests
{
    [Fact]
    public void Login_WithValidCredentials_ReturnsOkResult()
    {
        // Arrange
        var mockService = new Mock<IAuthService>();
        mockService.Setup(s => s.LoginAsync(It.IsAny<LoginRequestDto>()))
            .ReturnsAsync("jwtToken");

        var controller = new AuthController(mockService.Object);

        // Act
        var result = controller.Login(new LoginRequest { Email = "test@example.com", Password = "1234" });

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("fake-jwt-token", okResult.Value);
    }
}