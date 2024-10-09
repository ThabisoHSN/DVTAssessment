using System;

namespace Assessment.Classes;

public class Operation: Building
{

    public Operation(int buildingFloors, int elevators, int capacity) : base(buildingFloors, elevators,capacity)
    {

    }

    public async Task PerformStatusCheck()
    {
        await Task.Delay(0);
        foreach (var item in elevators)
        {
            Console.WriteLine($"Elevator {item.Id} current status is " + (item.IsMoving ? $" moving {item.DirectionStatus}" : $"{item.DirectionStatus}") + $" ,current floor {item.CurrentFloor}");
        }

    }

    public async Task PerformElevatorOperations()
    {
        
        int exit = 1;
        await Task.Delay(0);

        while (exit == 1)
        {
            
            int floor = prompts.GetValidInput("On which floor are you");
            int passengers = prompts.GetValidInput("Enter number of passengers waiting");
            
            //Requests and performs the elevator operations
            RequestForElevator(floor, passengers);
            
            exit = prompts.GetValidInput($"Who you like to continue\n 1 : Yes \n 2 : No");

            if(exit == 0){
                break;
            }
        }

    }

    public int RunOperations(){
        return prompts.GetValidInput($"Select Option \n 1 : View Elevator Status\n 2 : Use Elevators\n 3 : Exit");        
    }

}
