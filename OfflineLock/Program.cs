using System;
namespace ConcurrencyTest;
public class DataResource
{
    public string Data { get; set; }
    public int Version { get; set; }
}

public class Database
{
    public static DataResource GetResource()
    {
        // Simuler hentning af ressourcen fra en database
        return new DataResource { Data = "Original data", Version = 1 };
    }

    public static void SaveResource(DataResource resource)
    {
        // Simuler gemning af opdateret ressource i databasen
        Console.WriteLine("Gemmer opdateret ressource i databasen");
    }
}

public class Program
{
    public static string UpdateData(DataResource resource, string newData)
    {
        // Simuler hentning af aktuel ressource fra databasen
        DataResource currentData = Database.GetResource();

        if (currentData.Version == resource.Version)
        {
            // Versionskontrol passerer, opdater data
            currentData.Data = newData;
            currentData.Version++;

            // Simuler gemning af opdateret ressource i databasen
            Database.SaveResource(currentData);
            return "Opdatering udført med succes";
        }
        else
        {
            // Versionskonflikt, håndter konflikten
            return "Versionskonflikt: Ressourcen er blevet opdateret af en anden bruger.";
        }
    }

    public static void Main()
    {
        // Brug af koden
        DataResource resource = new DataResource { Data = "Original data", Version = 1 };
        string result = UpdateData(resource, "Nyt data");
        Console.WriteLine(result);
    }
}
