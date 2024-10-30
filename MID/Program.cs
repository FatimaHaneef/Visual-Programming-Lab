using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

public class Rider : User
{
    public List<Trip> RideHistory { get; set; } = new List<Trip>();

    public Rider(string username, string password) : base(username, password) { }
}

public class Driver : User
{
    public List<Trip> RideHistory { get; set; } = new List<Trip>();

    public Driver(string username, string password) : base(username, password) { }
}

public class Trip
{
    public Rider Rider { get; set; }
    public Driver Driver { get; set; }
    public string Destination { get; set; }
    public double Fare { get; set; }
    public bool IsAccepted { get; set; }

    public Trip(Rider rider, string destination, double fare)
    {
        Rider = rider;
        Destination = destination;
        Fare = fare;
        IsAccepted = false;
    }

    public void Accept(Driver driver)
    {
        Driver = driver;
        IsAccepted = true;
    }

    public void PrintTripDetails()
    {
        Console.WriteLine($"Trip Details: \nRider: {Rider.Username}\nDriver: {(Driver != null ? Driver.Username : "Not Assigned")}\nDestination: {Destination}\nFare: {Fare}\nAccepted: {IsAccepted}");
    }
}

public class RideSharingSystem
{
    public List<Rider> riders = new List<Rider>();
    public List<Driver> drivers = new List<Driver>();
    public List<Trip> trips = new List<Trip>();

    public void RegisterRider(string username, string password)
    {
        riders.Add(new Rider(username, password));
        Console.WriteLine("Rider registered successfully.");
    }

    public void RegisterDriver(string username, string password)
    {
        drivers.Add(new Driver(username, password));
        Console.WriteLine("Driver registered successfully.");
    }

    public User Login(string username, string password)
    {
        foreach (var rider in riders)
        {
            if (rider.Username == username && rider.Password == password)
            {
                Console.WriteLine("Rider logged in successfully.");
                return rider;
            }
        }

        foreach (var driver in drivers)
        {
            if (driver.Username == username && driver.Password == password)
            {
                Console.WriteLine("Driver logged in successfully.");
                return driver;
            }
        }

        Console.WriteLine("Invalid username or password.");
        return null;
    }

    public void RequestRide(Rider rider, string destination, double fare)
    {
        Trip trip = new Trip(rider, destination, fare);
        trips.Add(trip);
        Console.WriteLine("Ride requested successfully.");
    }

    public void AcceptRide(Driver driver, int tripIndex)
    {
        if (tripIndex < 0 || tripIndex >= trips.Count)
        {
            Console.WriteLine("Invalid trip index.");
            return;
        }

        Trip trip = trips[tripIndex];
        if (!trip.IsAccepted)
        {
            trip.Accept(driver);
            driver.RideHistory.Add(trip);
            trip.Rider.RideHistory.Add(trip);
            Console.WriteLine($"Driver {driver.Username} accepted the ride.");
        }
        else
        {
            Console.WriteLine("This ride has already been accepted.");
        }
    }

    public void ViewRideHistory(User user)
    {
        List<Trip> history = user is Rider rider ? rider.RideHistory : (user as Driver).RideHistory;

        if (history.Count == 0)
        {
            Console.WriteLine("No ride history available.");
            return;
        }

        Console.WriteLine($"{user.Username}'s Ride History:");
        foreach (var trip in history)
        {
            trip.PrintTripDetails();
            Console.WriteLine();
        }
    }

    public void DisplayAllTrips()
    {
        Console.WriteLine("All Trips:");
        foreach (var trip in trips)
        {
            trip.PrintTripDetails();
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RideSharingSystem rideSharingSystem = new RideSharingSystem();
        User loggedInUser = null;

        while (true)
        {
            Console.WriteLine("\nWelcome to the Ride Sharing System!");
            Console.WriteLine("1. Register Rider");
            Console.WriteLine("2. Register Driver");
            Console.WriteLine("3. Login");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter Rider Username: ");
                    string riderUsername = Console.ReadLine();
                    Console.Write("Enter Rider Password: ");
                    string riderPassword = Console.ReadLine();
                    rideSharingSystem.RegisterRider(riderUsername, riderPassword);
                    break;

                case "2":
                    Console.Write("Enter Driver Username: ");
                    string driverUsername = Console.ReadLine();
                    Console.Write("Enter Driver Password: ");
                    string driverPassword = Console.ReadLine();
                    rideSharingSystem.RegisterDriver(driverUsername, driverPassword);
                    break;

                case "3":
                    Console.Write("Enter Username: ");
                    string loginUsername = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string loginPassword = Console.ReadLine();
                    loggedInUser = rideSharingSystem.Login(loginUsername, loginPassword);

                    if (loggedInUser is Rider rider)
                    {
                        Console.Write("Enter Destination: ");
                        string destination = Console.ReadLine();
                        Console.Write("Enter Fare: ");
                        double fare = Convert.ToDouble(Console.ReadLine());
                        rideSharingSystem.RequestRide(rider, destination, fare);
                    }
                    else if (loggedInUser is Driver driver)
                    {
                        Console.WriteLine("Available Trips:");
                        for (int i = 0; i < rideSharingSystem.trips.Count; i++)
                        {
                            if (!rideSharingSystem.trips[i].IsAccepted)
                            {
                                Console.WriteLine($"Trip Index: {i}");
                                rideSharingSystem.trips[i].PrintTripDetails();
                            }
                        }

                        Console.Write("Enter the index of the trip you want to accept: ");
                        int tripIndex = Convert.ToInt32(Console.ReadLine());
                        rideSharingSystem.AcceptRide(driver, tripIndex);
                    }
                    break;

                case "4":
                    Console.WriteLine("Exiting the system. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            // After login, allow users to view their ride history or all trips
            if (loggedInUser != null)
            {
                Console.WriteLine("\nWhat would you like to do next?");
                Console.WriteLine("1. View Ride History");
                Console.WriteLine("2. Display All Trips");
                Console.WriteLine("3. Logout");
                string nextOption = Console.ReadLine();

                switch (nextOption)
                {
                    case "1":
                        rideSharingSystem.ViewRideHistory(loggedInUser);
                        break;

                    case "2":
                        rideSharingSystem.DisplayAllTrips();
                        break;

                    case "3":
                        loggedInUser = null; // Logout
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}