using Assessment.Classes;

class Program
{
    static async Task Main(string[] args)
    {
        var prompts = new SystemSetup();

        

        var operations = new Operation(prompts.BuildingFloors, prompts.Elevators, prompts.Capacity);

        int option;

        do
        {
            option = operations.RunOperations();
            switch (option)
            {
                case 1:
                    await operations.PerformStatusCheck();
                    break;
                case 2:
                    await operations.PerformElevatorOperations();
                    break;
                default:
                    break;
            }
        } while (option != 3);

    }
}
