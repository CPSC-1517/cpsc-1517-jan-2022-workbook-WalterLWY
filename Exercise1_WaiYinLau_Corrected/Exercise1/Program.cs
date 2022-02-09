using TrainSystem.data;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Train System:");
Console.WriteLine("==============");

// Variables Declaration
Engine Engine = CreateEngine();
RailCar RailCar = CreateRailCar();
Train MyTrain = CreateTrain(Engine, RailCar);

// Methods - Create Object
Engine CreateEngine()
{
    Console.WriteLine("Demo: creating A Train Engine:\n");
    // Base Case: Good Data
    Engine TrainEngine = new Engine("Dummy", "Dummy", 100000, 4000); 
    try
    {
        //Test 1: Greedy Good Engine
        TrainEngine = new Engine("CP 8002", "48807", 147700, 4400);
        DisplayString($"Greedy Good Engine: {TrainEngine.ToString()}");

        //Test 2: Greedy Good Engine : Trim Space before / after Model input
        // TrainEngine = new Engine("       CP 8002      ", "48807", 147700, 3500);
        // DisplayString($"Greedy Good Engine - Trim Space before/after Model: {TrainEngine.ToString()}");

        //Test 3: Greedy Good Engine : Trim Space before / after Serial Number input
        // TrainEngine = new Engine("CP 8002", "    48807    ", 147700, 3500);
        // DisplayString($"Greedy Good Engine - Trim Space before/after SerialNumber: {TrainEngine.ToString()}");

        //Test 4: Greedy Good Engine : Weight Rounding to Nearest 100
        // TrainEngine = new Engine("CP 8002", "48807", 147782, 3567);
        // DisplayString($"Greedy Good Engine - Round Weight to nearest 100: {TrainEngine.ToString()}");

        //Test 5: Greedy Good Engine : HP Rounding to Nearest 100
        // TrainEngine = new Engine("CP 8002", "48807", 147700, 3567);
        // DisplayString($"Greedy Good Engine - Round HP to nearest 100: {TrainEngine.ToString()}");

        //Test 6: Checking Exception - Bad Data - Model: null
        // TrainEngine = new Engine("", "48807", 147700, 1850);
        // Expected: Display error message:
        // "Create Engine Failed: Model cannot leave blank or null."

        //Test 7: Checking Exception - Bad Data - Serial Number: null
        // TrainEngine = new Engine("CP 8002", "", 147700, 1850);
        // Expected: Display error message:
        // "Create Engine Failed: Serial Number cannot leave blank or null."

        //Test 8: Checking Exception - Bad Data - Weight : Negative Value
        // TrainEngine = new Engine("CP 8002", "48807", -147700, 3500);
        // Expected: Display error message:
        // "Create Engine Failed: Weights must be positive and non-zero whole numbers"

        //Test 9: Checking Exception - Bad Data - Weight : Zero
        // TrainEngine = new Engine("CP 8002", "48807", 0, 3500);
        // Expected: Display error message:
        // "Create Engine Failed: Weights must be positive and non-zero whole numbers"

        //Test 10: Checking Exception - Bad Data - HP: Negative Value
        // TrainEngine = new Engine("CP 8002", "48807", 147700, -200);
        // Expected: Display error message:
        // "Create Engine Failed: Horse Power must be a positive number."

        //Test 11: Checking Exception - Bad Data - HP: <3500 or >5500
        // TrainEngine = new Engine("CP 8002", "48807", 147700, 1850);
        // Expected: Display error message:
        // "Create Engine Failed: Horse Power must be a positive whole number between 3,500 and 5,500."

    }
    catch (ArgumentException ex)
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)
    {
        DisplayString("Run time error : " + ex.Message);
    }
    return TrainEngine;
}

RailCar CreateRailCar()
{
    Console.WriteLine("\nDemo: Creating A Rail Car:\n");
    // Base Case: Good Data
    RailCar NewRailCar = new RailCar("dummy", 1000, 2000, 3000, RailCarType.Box_Car, false); 
    try
    {
        //Test 1: Greedy Good RailCar
        NewRailCar = new RailCar("18172", 2500, 4000, 4500, RailCarType.Box_Car, true);
        DisplayString($"Greedy Good RailCar: {NewRailCar.ToString()}");

        //Test 2: Greedy Good RailCar : Trim Space before / after Serial Number input
        // NewRailCar = new RailCar("   18172   ", 2500, 4000, 4586, RailCarType.Box_Car, true);
        // DisplayString($"Greedy Good RailCar - Trim Space before/after Serial Number: {NewRailCar.ToString()}");

        //Test 3: Greedy Good RailCar : LightWeight - Rounding to Nearest 100
        // NewRailCar = new RailCar("18172", 2158, 4000, 4500, RailCarType.Box_Car, true);
        // DisplayString($"Greedy Good RailCar: Rounding LightWeight to nearest 100 {NewRailCar.ToString()}");

        //Test 4: Greedy Good RailCar : Capacity - Rounding to Nearest 100
        // NewRailCar = new RailCar("18172", 2500, 4325, 4500, RailCarType.Box_Car, true);
        // DisplayString($"Greedy Good RailCar: Rounding Capacity to nearest 100 {NewRailCar.ToString()}");

        //Test 5: Greedy Good RailCar : LoadLimit - Rounding to Nearest 100
        // NewRailCar = new RailCar("18172", 2500, 4000, 4586, RailCarType.Box_Car, true);
        // DisplayString($"Greedy Good RailCar: Rounding LoadLimit to nearest 100 {NewRailCar.ToString()}");

        //Test 6: Checking Exception - Bad Data - Serial Number: null
        // NewRailCar = new RailCar("", 2500, 4000, 4500, RailCarType.Box_Car, true);
        // Expected: Display error message:
        // "Create RailCar Failed: Serial Number cannot leave blank or null."

        //Test 7: Checking Exception - Bad Data - LightWeight : Zero
        // NewRailCar = new RailCar("18172", 0, 4000, 4500, RailCarType.Box_Car, true);
        // Expected: Display error message:
        // "Create RailCar Failed: Light Weights must be positive and non-zero whole numbers"

        //Test 8: Checking Exception - Bad Data - LightWeight : Negative Value
        // NewRailCar = new RailCar("18172", -2500, 4000, 4500, RailCarType.Box_Car, true);
        // Expected: Display error message:
        // "Create RailCar Failed: Light Weights must be positive and non-zero whole numbers"

        //Test 9: Checking Exception - Bad Data - Capacity : Zero
        // NewRailCar = new RailCar("18172", 2500, 0, 4500, RailCarType.Box_Car, true);
        // Expected: Display error message:
        // "Create RailCar Failed: Capacity must be positive and non-zero whole numbers"

        //Test 10: Checking Exception - Bad Data - Capacity : Negative Value
        // NewRailCar = new RailCar("18172", 2500, -4000, 4500, RailCarType.Box_Car, true);
        // Expected: Display error message:
        // "Create RailCar Failed: Capacity must be positive and non-zero whole numbers"

        //Test 11: Checking Exception - Bad Data - Capacity > Load Limit
        // NewRailCar = new RailCar("18172", 2500, 5500, 4500, RailCarType.Box_Car, true);
        // Expected: Display error message:
        // "Create RailCar Failed: Capacity must always less than the Load Limit."

        //Test 12: Checking Exception - Bad Data - LoadLimit: Zero
        // NewRailCar = new RailCar("18172", 2500, 4000, 0, RailCarType.Box_Car, true);
        // Expected: Display error message:
        // "Create RailCar Failed: Capacity must always less than the Load Limit."

        //Test 13: Checking Exception - Bad Data - LoadLimit: Negative Value
        // NewRailCar = new RailCar("18172", 2500, 4000, -4500, RailCarType.Box_Car, true);
        // Expected: Display error message:
        // "Create RailCar Failed: Capacity must always less than the Load Limit."

        //Testing RecordScaleWeight Method
        //Test 14: Good Data: Gross Weight 3000 (Net Weight: 500; IsFull = false)
        // NewRailCar = new RailCar("18172", 2500, 4000, 4500, RailCarType.Box_Car, true);
        // NewRailCar.RecordScaleWeight(3000);
        // DisplayString($"Greedy Good RailCar: {NewRailCar.ToString()}");
        // DisplayString($"{NewRailCar.GrossWeight},{NewRailCar.NetWeight},{NewRailCar.IsFull}");

        //Test 15: Good Data: Gross Weight 6300 (Net Weight: 3800 (95% full); IsFull = true)
        // NewRailCar = new RailCar("18172", 2500, 4000, 4500, RailCarType.Box_Car, true);
        // NewRailCar.RecordScaleWeight(6300);
        // DisplayString($"Greedy Good RailCar: {NewRailCar.ToString()}");
        // DisplayString($"{NewRailCar.GrossWeight},{NewRailCar.NetWeight},{NewRailCar.IsFull}");

        //Test 16: Bad Data: Negative Gross Weight 
        // NewRailCar = new RailCar("18172", 2500, 4000, 4500, RailCarType.Box_Car, true);
        // DisplayString($"Greedy Good RailCar: {NewRailCar.ToString()}");
        // NewRailCar.RecordScaleWeight(-3000);
        // Expected: Display error message:
        // "Record Scale Failed : Weights must be positive and non-zero whole numbers."

        //Test 17: Bad Data: Gross Weight < Light Weight
        // NewRailCar = new RailCar("18172", 2500, 4000, 4500, RailCarType.Box_Car, true);
        // DisplayString($"Greedy Good RailCar: {NewRailCar.ToString()}");
        // NewRailCar.RecordScaleWeight(1000);
        // Expected: Display error message:
        // "Record Scale Failed : Scale Error -
        //  Gross Weights must be greater than the Light Weight of the Rail Car"

        //Test 18: Bad Data: Gross Weight 10000 > Gross Load Limit 7000
        // NewRailCar = new RailCar("18172", 2500, 4000, 4500, RailCarType.Box_Car, true);
        // DisplayString($"Greedy Good RailCar: {NewRailCar.ToString()}");
        // NewRailCar.RecordScaleWeight(10000);
        // Expected: Display error message:
        // "Record Scale Failed : Unsafe Load - 
        //  For safety, a rail car should be loaded so that Gross Weight
        //  is less than the sum of its stenciled Load Limit + Light Weight."
    }
    catch (ArgumentException ex)
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)
    {
        DisplayString("Run time error : " + ex.Message);
    }
    return NewRailCar;
}

Train CreateTrain(Engine engine, RailCar railcar)
{
    Console.WriteLine("\nDemo: creating A Train:\n");
    // Base Case: Good Data
    Train theTrain = new Train(engine);

    try
    {
        theTrain.AddRailCar(railcar);
        theTrain.AddRailCar(new("AddNew",2000,10000,15000,RailCarType.Box_Car,true));
        DisplayTrain(theTrain);
    }
    catch (ArgumentException ex)
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)
    {
        DisplayString("Run time error : " + ex.Message);
    }
    return theTrain;
}

// Methods - Display
static void DisplayString(string text)
{
    Console.WriteLine(text);
}

static void DisplayTrain(Train train)
{
    DisplayString($"Train Engine: {train.Engine}\n" +
                  $"Train Gross Weight: {train.GrossWeight}\n" +
                  $"Train Max Gross Weight: {train.MaxGrossWeight}");
    if (train.RailCars != null)
    {
        Console.WriteLine("Rail Car Details: ");
        int count = 1;
        foreach (var railcar in train.RailCars)
        {
            DisplayString($"{count} : {railcar.ToString()}");
            count++;
        }
    }
    DisplayString($"Total Cars: {train.TotalCars}");
}