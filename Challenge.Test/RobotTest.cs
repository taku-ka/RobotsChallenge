

using Challenge.Models;
using Challenge.Service;

namespace Challenge.Test;

public class RobotTest
{
    [Fact]
    public void RobotCompleteCommand()
    {
        var marsSurface = new MarsSurface(5, 3);
        var robotService = new RobotService(marsSurface);
        var robotPosition = new RobotPosition(1, 1, Direction.E);
        var output = robotService.MovePosition(robotPosition, "RFRFRFRF");

        Assert.Equal("1 1 E", output);
    }

    [Fact]
    public void RobotGetsLost()
    {
        var marsSurface = new MarsSurface(5, 3);
        var robotService = new RobotService(marsSurface);
        var output = robotService.MovePosition(new RobotPosition(3, 2, Direction.N), "FRRFLLFFRRFLL");

        Assert.Equal("3 3 N LOST", output);
    }

    [Fact]
    public void RobotAvoidFalling()
    {
        var marsSurface = new MarsSurface(5, 3);
        var robotService = new RobotService(marsSurface);
        robotService.MovePosition(new RobotPosition(3, 2, Direction.N), "FRRFLLFFRRFLL");

        var output = robotService.MovePosition(new RobotPosition(0, 3, Direction.W), "LLFFFLFLFL");
        Assert.Equal("2 3 S", output);
    }
}
