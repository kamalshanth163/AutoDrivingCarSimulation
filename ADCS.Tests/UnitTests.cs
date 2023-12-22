using ADCS.API.Controllers;
using ADCS.Application;
using ADCS.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ADCS.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private SimulatorController _controller;
        private Mock<ISimulatorService> _mockSimulatorService;
        private Mock<ISimulatorRepository> _mockSimulatorRepository;
        private Mock<IDriveService> _mockDriveService;

        [SetUp]
        public void Setup()
        {
            _controller = new SimulatorController(_mockSimulatorService.Object);
            _mockSimulatorService = new Mock<ISimulatorService>();
            _mockSimulatorRepository = new Mock<ISimulatorRepository>();
            _mockDriveService = new Mock<IDriveService>();
        }

        [Test]
        public async Task Execute_WithValidData_ReturnsSimulationWithSuccess()
        {
            // Arrange
            var instruction = new Instruction("10 10", "1 2 N", "FFRFFFRRLF");

            //var field = _mockSimulatorRepository.Object.CreateField(instruction.FieldInput);

            //_mockSimulatorRepository.Object.CreatePositionAndDirection(instruction.PositionInput, out Position position, out Direction direction);

            // Mock the Execute method of ISimulatorService
            var simulatedResult = new Simulation(); // Create a sample simulation result
            _mockSimulatorService.Setup(service => service.Execute(instruction)).ReturnsAsync(simulatedResult);

            // Act
            var result = await _controller.Execute(instruction);

            // Assert
            Assert.IsInstanceOf<ActionResult<Simulation>>(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(simulatedResult, result.Value);
        }
    }
}