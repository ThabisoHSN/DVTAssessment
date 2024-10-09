using Assessment.Classes;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            //Initialise and setup the building floor and how many elevators are in the building
            var prompts = new SystemSetup();

            var operations = new Operation(prompts.BuildingFloors, prompts.Elevators, prompts.Capacity);

            int option;

            do
            {
                //Determines which operations to run
                option = operations.RunOperations();

                switch (option)
                {
                    case 1:
                        //Check for the current status of all the elevators
                        await operations.PerformStatusCheck();
                        break;
                    case 2:
                        //Performs the elevator operations
                        await operations.PerformElevatorOperations();
                        break;
                    default:
                        break;
                }
            } while (option != 3);

        }
        catch (Exception e)
        {
            Console.WriteLine("Error at Main" + e.Message);
        }


    }
}
