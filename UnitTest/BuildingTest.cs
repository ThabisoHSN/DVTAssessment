using System;
using Assessment.Classes;

namespace UnitTest;

public class BuildingTest
{
    [Fact]
    public void ShouldReturnClosestAvailableElevator()
    {

        var building = new Building(10, 3, 10);

        building.elevators[0].CurrentFloor = 3;
        building.elevators[1].CurrentFloor = 5;
        building.elevators[2].CurrentFloor = 8;

        var elevator = building.GetElevator(4);

        Assert.Equal(1, elevator.Id);
    }


    [Fact]
    public void ShouldNotAllowTooManyPassengers()
    {

        var building = new Building(10, 3, 5);
        building.elevators[0].CurrentPassengers = 4;

        var result = building.RequestForElevator(2, 3);

        Assert.False(result);
    }
}
