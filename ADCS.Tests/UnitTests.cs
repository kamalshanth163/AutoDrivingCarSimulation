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
            _mockSimulatorService = new Mock<ISimulatorService>();
            _mockSimulatorRepository = new Mock<ISimulatorRepository>();
            _mockDriveService = new Mock<IDriveService>();
            _controller = new SimulatorController(_mockSimulatorService.Object);
        }

        [Test]
        public async Task Execute_WithValidData_ReturnsSimulation()
        {
            // Arrange
            var instruction = new Instruction("10 10", "1 2 N", "FFRFFFRRLF");

            _mockSimulatorRepository.Object.SetField(instruction.FieldInput);
            _mockSimulatorRepository.Object.CreatePositionAndDirection(instruction.PositionInput, out Position position, out Direction direction);

            var expectedResult = "4 3 S";

            var expectedResult2 = new Simulation()
            {
                Field = new FieldDto(),
                CarStart = new Car
                {
                    Position = new Position(1, 2),
                    Direction = new Direction("N")
                },
                CarEnd = new Car
                {
                    Position = new Position(4, 3),
                    Direction = new Direction("S")
                }
            };

            _mockSimulatorService.Setup(service => service.Execute(instruction)).ReturnsAsync(expectedResult2);

            // Act
            var result = await _controller.Execute(instruction);
            var result2 = await _controller.Execute(instruction, true);

            // Assert
            var actionResult = result as OkObjectResult;
            var actionResult2 = result2 as OkObjectResult;

            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult2);

            Assert.AreEqual(expectedResult, actionResult.Value);
            Assert.AreEqual(expectedResult2, actionResult2.Value);

        }


        [Test]
        public async Task Execute_WithInValidCommand_ReturnSimulation()
        {
            // Arrange
            var instruction = new Instruction("10 10", "0 0 S", "FF");

            _mockSimulatorRepository.Object.SetField(instruction.FieldInput);
            _mockSimulatorRepository.Object.CreatePositionAndDirection(instruction.PositionInput, out Position position, out Direction direction);

            var expectedResult = "0 0 S";

            var expectedResult2 = new Simulation()
            {
                Field = new FieldDto(),
                CarStart = new Car
                {
                    Position = new Position(0, 0),
                    Direction = new Direction("S")
                },
                CarEnd = new Car
                {
                    Position = new Position(0, 0),
                    Direction = new Direction("S")
                }
            };

            _mockSimulatorService.Setup(service => service.Execute(instruction)).ReturnsAsync(expectedResult2);

            // Act
            var result = await _controller.Execute(instruction);
            var result2 = await _controller.Execute(instruction, true);

            // Assert
            var actionResult = result as OkObjectResult;
            var actionResult2 = result2 as OkObjectResult;

            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult2);

            Assert.AreEqual(expectedResult, actionResult.Value);
            Assert.AreEqual(expectedResult2, actionResult2.Value);

        }
    }
}