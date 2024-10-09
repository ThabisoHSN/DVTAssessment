using System;

namespace Assessment.Classes;

public class Building
{
    public List<Elevator> elevators = new List<Elevator>();
    public int BuildingFloors { get; set; }
    public Prompts prompts;

    public Building(int buildingFloors, int elevators, int capacity)
    {
        BuildingFloors = buildingFloors;
        prompts = new Prompts();

        //initializing the building elevators
        for (int i = 0; i < elevators; i++)
        {
            this.elevators.Add(new Elevator(i + 1, capacity));
        }
    }

    public Elevator GetElevator(int floor)
    {

        return elevators.OrderBy(o => Math.Abs(o.CurrentFloor - floor)).FirstOrDefault(f => !f.IsMoving);
    }

    public bool RequestForElevator(int floor, int passengers)
    {
        try
        {
            if (floor > BuildingFloors)
            {
                Console.WriteLine($"Number should be from 1 till {BuildingFloors}");
                return true;
            }

            //Gets the closes elevator from the requesting floor
            var elevator = GetElevator(floor);

            if (elevator is null)
            {
                Console.WriteLine("All elevators are busy please try again");
                return false;
            }

            //Check if the elevator has capacity
            if (!elevator.GetCurrentPassengerStatus(passengers))
            {
                return false;
            };


            elevator.UploadPassengers(passengers);
            elevator.MovingToFloor(floor);

            int nextFloor = prompts.GetValidInput("Which floor are you going to?");

            elevator.MovingToFloor(nextFloor);

            elevator.DirectionStatus = "Stationary";
            elevator.OffloadPassengers(passengers);

            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }
}
