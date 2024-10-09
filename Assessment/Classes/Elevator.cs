using System;
using Assessment.Constants;

namespace Assessment.Classes;

public class Elevator
{

    public int Id { get; set; }
    public int CurrentFloor { get; set; }
    public int CurrentPassengers { get; set; }
    public int MaxPassengers { get; set; }
    public bool IsMoving { get; set; }
    public string DirectionStatus { get; set; }

    public Elevator(int id, int maximumCapacity)
    {
        Id = id;
        IsMoving = false;

        DirectionStatus = DirectionConstants.DirectionStationary;
        CurrentFloor = 1;
        CurrentPassengers = 0;
        MaxPassengers = maximumCapacity;

    }

    public void MovingToFloor(int floor)
    {
        try
        {

            if (floor == CurrentFloor)
            {
                Console.WriteLine($"Elevator {Id} is current on floor {CurrentFloor}");
                return;
            }

            IsMoving = true;
            DirectionStatus = floor > CurrentFloor ? DirectionConstants.DirectionUp : DirectionConstants.DirectionDown;
            Console.WriteLine($"Elevator {Id} is moving {DirectionStatus} to floor {floor}");

            while (CurrentFloor != floor)
            {

                Thread.Sleep(2000);
                CurrentFloor += DirectionStatus == "Up" ? 1 : -1;

                if (CurrentFloor != floor)
                {
                    Console.WriteLine($"Elevator {Id} is on floor {CurrentFloor} moving {DirectionStatus}");
                }
            }

            IsMoving = false;
            Console.WriteLine($"Elevator {Id} has arrived at floor {floor}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error at MovingToFloor" +ex.ToString());
        }
    }

    public bool GetCurrentPassengerStatus(int passengers)
    {
        if (passengers + CurrentPassengers > MaxPassengers)
        {
            Console.WriteLine($"Elevator {Id} has maximum capacity of {MaxPassengers}");
            return false;
        }

        return true;
    }

    public void UploadPassengers(int passengers)
    {
        CurrentPassengers += passengers;
    }
    public void OffloadPassengers(int passengers)
    {
        CurrentPassengers -= passengers;
    }
}
