using System;

namespace Assessment.Classes;

public class SystemSetup : Prompts
{
    public int BuildingFloors { get; set; }
    public int Elevators { get; set; }
    public int Capacity { get; set; }
    public SystemSetup()
    {
        this.BuildingFloors = GetValidInput("How many floors does your building have?");
        this.Elevators = GetValidInput("How many elevators?");
        this.Capacity = GetValidInput("How many people can one elevator take at a time?");
    }
}
