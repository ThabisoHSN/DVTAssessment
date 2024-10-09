using System;
using Assessment.Classes;

namespace UnitTest;

public class ElevatorTest
{
[Fact]
    public void MovingToFloorShouldUpdateFloorAndDirection()
    {
        var elevator = new Elevator(1, 10);

        elevator.MovingToFloor(5);

        Assert.Equal(5, elevator.CurrentFloor);
        Assert.Equal("Up", elevator.DirectionStatus);
        Assert.False(elevator.IsMoving);
    }

    [Fact]
    public void MovingToFloorShouldMoveDownAndStop()
    {

        var elevator = new Elevator(1, 10);
        elevator.MovingToFloor(2);

        elevator.MovingToFloor(5);

        Assert.Equal(5, elevator.CurrentFloor);
        Assert.Equal("Up", elevator.DirectionStatus);
        Assert.False(elevator.IsMoving);
    }

    [Fact]
    public void ShouldReturnFalseWhenExceedsCapacity()
    {

        var elevator = new Elevator(1, 10);

        var result = elevator.GetCurrentPassengerStatus(12);

        Assert.False(result);
    }

    [Fact]
    public void ShouldReturnTrueWhenWithinCapacity()
    {
        var elevator = new Elevator(1, 10);

        var result = elevator.GetCurrentPassengerStatus(8);

        Assert.True(result);
    }
}
