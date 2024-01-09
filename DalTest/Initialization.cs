namespace DalTest;
using DalApi;
using DO;

public static class Initialization
{
    private static IEngineer? s_dalEngineer;
    private static ITask? s_dalTask;
    private static IDependency? s_dalDepeytikyndency;

    private static readonly Random s_rand = new(); // random number generator


    private static void createEngineer()
    {
        string[] engineerNames =
        {
        "Dani Levi", "Eli Amar", "Yair Cohen",
        "Ariela Levin", "Dina Klein", "Shira Israelof"
    };

        foreach (var _name in engineerNames)
        {
            int MIN_ID = 10000000;
            int MAX_ID = 99999999;
            int MIN_SALARY = 100;
            int MAX_SALARY = 10000000;
            int _id;
            do
                _id = s_rand.Next(MIN_ID, MAX_ID); // generate a random ID
            while (s_dalEngineer!.Read(_id) != null); // check if the ID is already in use

            string _email = _name.Replace(' ', '.').ToLower() + "@gmail.com"; ///   generate a random email

            double _salary = s_rand.NextDouble() * (MAX_SALARY - MIN_SALARY) + MIN_SALARY; // generate a random salary

            Engineer newEng = new(_id, _name, _email, _salary, EngineerExperience.Beginner); // create a new engineer

            s_dalEngineer!.Create(newEng); // add the new engineer to the database
        }

    }



    public static void createTask()
    {
        string[] taskNames =
        {"Change oil and filter",
    "Rotate tires and check pressure",
    "Replace brake pads",
    "Inspect and replace spark plugs",
    "Perform engine tune-up",
    "Flush and replace coolant",
    "Replace air filter",
    "Align wheels",
    "Check and replace transmission fluid",
    "Inspect and replace belts and hoses",
    "Test and replace car battery",
    "Replace windshield wipers",
    "Clean and condition leather seats",
    "Inspect and replace shock absorbers",
    "Adjust handbrake",
    "Check and top up power steering fluid",
    "Inspect and replace exhaust system components",
    "Test and replace headlights/taillights",
    "Refill windshield washer fluid",
    "Inspect and replace cabin air filter",
    "Adjust clutch (if applicable)",
    "Inspect and clean throttle body",
    "Check and replace fuel filter",
    "Inspect and clean brake calipers",
    "Test and replace ignition coils",
    "Inspect and replace wheel bearings",
    "Check and adjust tire alignment",
    "Inspect and replace oxygen sensors",
    "Clean and polish exterior",
    "Inspect and replace engine mounts",
    "Check and replace PCV valve",
    "Inspect and replace steering rack components",
    "Test and replace alternator",
    "Inspect and replace tie rod ends",
    "Check and replace differential fluid",
    "Inspect and clean mass airflow sensor",
    "Clean and condition dashboard",
    "Inspect and replace ball joints",
    "Test and replace starter motor",
    "Inspect and replace thermostat"
     };
        string[] taskDescription = {
    "Replace the engine oil and its filter to maintain engine health.",
    "Ensure even tire wear by rotating tires and checking their pressure.",
    "Install new brake pads to maintain braking performance.",
    "Check and replace spark plugs for optimal engine performance.",
    "Perform maintenance tasks to enhance engine efficiency.",
    "Flush and replace the engine coolant to prevent overheating.",
    "Replace the air filter for improved air intake.",
    "Align wheels to ensure straight and safe driving.",
    "Maintain transmission health by checking and replacing its fluid.",
    "Inspect and replace worn-out belts and hoses to prevent breakdowns.",
    "Test and replace the car battery when necessary.",
    "Replace worn-out windshield wipers for clear visibility.",
    "Clean and condition leather seats for longevity.",
    "Ensure a comfortable and smooth ride by inspecting and replacing shock absorbers.",
    "Adjust the handbrake to ensure it works properly.",
    "Check and top up power steering fluid for smooth steering.",
    "Inspect and replace parts of the exhaust system to prevent leaks and noise.",
    "Ensure proper visibility by testing and replacing headlights/taillights.",
    "Refill windshield washer fluid for clear visibility.",
    "Inspect and replace cabin air filter for clean air inside the vehicle.",
    "Adjust the clutch for smooth gear changes (if applicable).",
    "Keep the throttle body clean for proper engine function.",
    "Check and replace the fuel filter for fuel efficiency.",
    "Inspect and clean brake calipers for effective braking.",
    "Test and replace faulty ignition coils.",
    "Inspect and replace worn-out wheel bearings.",
    "Check and adjust tire alignment for even tire wear.",
    "Replace worn-out oxygen sensors for proper emission control.",
    "Clean and polish the exterior for a shiny look.",
    "Inspect and replace damaged engine mounts.",
    "Check and replace the PCV valve for proper ventilation.",
    "Inspect and replace steering rack components for smooth steering.",
    "Test and replace a faulty alternator.",
    "Inspect and replace worn-out tie rod ends.",
    "Check and replace differential fluid for smooth operation.",
    "Inspect and clean the mass airflow sensor for proper air intake.",
    "Clean and condition the dashboard for a fresh look.",
    "Inspect and replace worn-out ball joints.",
    "Test and replace a faulty starter motor.",
    "Inspect and replace a faulty thermostat for proper engine temperature control." };
        


    }
}


