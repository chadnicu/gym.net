using Gym.Models;

namespace Gym.Data
{
    public class DbInitializer
    {
        public static void Initialize(GymContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Branches.
            if (context.Branches.Any())
            {
                return;   // DB has been seeded
            }

            // branches
            var branches = new Branch[] {
       new Branch{BranchId=1,City="Chișinău",Address="Strada Socoleni 7",Founded=DateTime.Parse("2018-09-11")},
    new Branch{BranchId=2,City="Chișinău",Address="Strada Ștefan cel Mare 10",Founded=DateTime.Parse("2019-02-15")},
    new Branch{BranchId=3,City="Chișinău",Address="Strada Mihai Viteazul 25",Founded=DateTime.Parse("2017-03-20")},
    new Branch{BranchId=4,City="Bălți",Address="Strada Independenței 4",Founded=DateTime.Parse("2016-04-12")},
    new Branch{BranchId=5,City="Cahul",Address="Strada Ion Creangă 16",Founded=DateTime.Parse("2015-05-30")},
    new Branch{BranchId=6,City="Orhei",Address="Strada Vasile Lupu 19",Founded=DateTime.Parse("2014-07-22")},
    new Branch{BranchId=7,City="Ungheni",Address="Strada Miorița 2",Founded=DateTime.Parse("2013-08-11")},
    new Branch{BranchId=8,City="Soroca",Address="Strada Libertății 5",Founded=DateTime.Parse("2012-09-05")},
    new Branch{BranchId=9,City="Comrat",Address="Strada Tineretului 14",Founded=DateTime.Parse("2011-10-20")},
    new Branch{BranchId=10,City="Edineț",Address="Strada Trandafirilor 18",Founded=DateTime.Parse("2010-11-25")},
    new Branch{BranchId=11,City="Drochia",Address="Strada Mihail Sadoveanu 8",Founded=DateTime.Parse("2009-12-15")},
    new Branch{BranchId=12,City="Hîncești",Address="Strada Eminescu 9",Founded=DateTime.Parse("2018-01-18")},
    new Branch{BranchId=13,City="Ialoveni",Address="Strada Grigore Vieru 12",Founded=DateTime.Parse("2017-02-10")},
    new Branch{BranchId=14,City="Anenii Noi",Address="Strada Alexandru cel Bun 15",Founded=DateTime.Parse("2016-03-11")},
    new Branch{BranchId=15,City="Strășeni",Address="Strada Traian 6",Founded=DateTime.Parse("2015-04-20")},
    new Branch{BranchId=16,City="Călărași",Address="Strada Moldova 7",Founded=DateTime.Parse("2014-05-10")},
    new Branch{BranchId=17,City="Cimișlia",Address="Strada Bogdan Petriceicu Hasdeu 13",Founded=DateTime.Parse("2013-06-01")},
    new Branch{BranchId=18,City="Rezina",Address="Strada Mihail Kogălniceanu 17",Founded=DateTime.Parse("2012-07-11")},
    new Branch{BranchId=19,City="Glodeni",Address="Strada George Coșbuc 3",Founded=DateTime.Parse("2011-08-21")},
    new Branch{BranchId=20,City="Rîbnița",Address="Strada Basarabiei 9",Founded=DateTime.Parse("2010-09-09")}
            };

            foreach (Branch b in branches)
            {
                context.Branches.Add(b);
            }
            context.SaveChanges();


            // equipments
            var equipments = new Equipment[]
            {
     new Equipment{Name="Leg Extension",Brand="Nautilus",MuscleGroup="Quadriceps",Price=5000,PurchasedAt=DateTime.Parse("2024-09-11"),BranchId=1},
    new Equipment{Name="Chest Press",Brand="Hammer Strength",MuscleGroup="Chest",Price=7000,PurchasedAt=DateTime.Parse("2024-08-15"),BranchId=2},
    new Equipment{Name="Treadmill",Brand="NordicTrack",MuscleGroup="Cardio",Price=4500,PurchasedAt=DateTime.Parse("2024-07-20"),BranchId=3},
    new Equipment{Name="Squat Rack",Brand="Rogue",MuscleGroup="Legs",Price=8000,PurchasedAt=DateTime.Parse("2024-06-11"),BranchId=4},
    new Equipment{Name="Lat Pulldown",Brand="Technogym",MuscleGroup="Back",Price=5500,PurchasedAt=DateTime.Parse("2024-05-05"),BranchId=5},
    new Equipment{Name="Dumbbells Set",Brand="Bowflex",MuscleGroup="Full Body",Price=3000,PurchasedAt=DateTime.Parse("2024-04-10"),BranchId=6},
    new Equipment{Name="Leg Press",Brand="Life Fitness",MuscleGroup="Legs",Price=6500,PurchasedAt=DateTime.Parse("2024-03-15"),BranchId=7},
    new Equipment{Name="Smith Machine",Brand="Precor",MuscleGroup="Full Body",Price=7500,PurchasedAt=DateTime.Parse("2024-02-18"),BranchId=8},
    new Equipment{Name="Rowing Machine",Brand="Concept2",MuscleGroup="Cardio",Price=4000,PurchasedAt=DateTime.Parse("2024-01-20"),BranchId=9},
    new Equipment{Name="Cable Crossover",Brand="Cybex",MuscleGroup="Chest",Price=6000,PurchasedAt=DateTime.Parse("2023-12-15"),BranchId=10},
    new Equipment{Name="Elliptical",Brand="Sole Fitness",MuscleGroup="Cardio",Price=5000,PurchasedAt=DateTime.Parse("2023-11-25"),BranchId=11},
    new Equipment{Name="Bench Press",Brand="Rogue",MuscleGroup="Chest",Price=4500,PurchasedAt=DateTime.Parse("2023-10-05"),BranchId=12},
    new Equipment{Name="Seated Row",Brand="Body Solid",MuscleGroup="Back",Price=5500,PurchasedAt=DateTime.Parse("2023-09-18"),BranchId=13},
    new Equipment{Name="Incline Press",Brand="Hammer Strength",MuscleGroup="Chest",Price=7000,PurchasedAt=DateTime.Parse("2023-08-10"),BranchId=14},
    new Equipment{Name="Bicep Curl Machine",Brand="Technogym",MuscleGroup="Arms",Price=3500,PurchasedAt=DateTime.Parse("2023-07-01"),BranchId=15},
    new Equipment{Name="Pec Deck",Brand="Life Fitness",MuscleGroup="Chest",Price=6000,PurchasedAt=DateTime.Parse("2023-06-05"),BranchId=16},
    new Equipment{Name="Spin Bike",Brand="Peloton",MuscleGroup="Cardio",Price=4000,PurchasedAt=DateTime.Parse("2023-05-12"),BranchId=17},
    new Equipment{Name="Glute Machine",Brand="Nautilus",MuscleGroup="Glutes",Price=5000,PurchasedAt=DateTime.Parse("2023-04-10"),BranchId=18},
    new Equipment{Name="Pull-up Bar",Brand="Iron Gym",MuscleGroup="Back",Price=1500,PurchasedAt=DateTime.Parse("2023-03-22"),BranchId=19},
    new Equipment{Name="Abdominal Crunch Machine",Brand="Precor",MuscleGroup="Abs",Price=3000,PurchasedAt=DateTime.Parse("2023-02-15"),BranchId=20}

            };


            foreach (Equipment e in equipments)
            {
                context.Equipments.Add(e);
            }
            context.SaveChanges();

            // clients
            var clients = new Client[]
            {
    new Client{ClientId=1,FirstName="Nicolae",LastName="Titulescu",Email="nicolaetitulescu@gmail.com",BirthDate=DateTime.Parse("2000-09-11")},
    new Client{ClientId=2,FirstName="Maria",LastName="Popescu",Email="mariapopescu@gmail.com",BirthDate=DateTime.Parse("1995-03-22")},
    new Client{ClientId=3,FirstName="Ion",LastName="Ionescu",Email="ionionescu@gmail.com",BirthDate=DateTime.Parse("1988-07-30")},
    new Client{ClientId=4,FirstName="Elena",LastName="Marin",Email="elenamarin@gmail.com",BirthDate=DateTime.Parse("1992-12-01")},
    new Client{ClientId=5,FirstName="Andrei",LastName="Vasilescu",Email="andreivasilescu@gmail.com",BirthDate=DateTime.Parse("1990-01-15")},
    new Client{ClientId=6,FirstName="Oana",LastName="Georgescu",Email="oanageorgescu@gmail.com",BirthDate=DateTime.Parse("1993-04-20")},
    new Client{ClientId=7,FirstName="Alex",LastName="Sava",Email="alexsava@gmail.com",BirthDate=DateTime.Parse("1985-05-25")},
    new Client{ClientId=8,FirstName="Diana",LastName="Toma",Email="dianatoma@gmail.com",BirthDate=DateTime.Parse("1998-08-30")},
    new Client{ClientId=9,FirstName="Sorin",LastName="Iordache",Email="soriniordache@gmail.com",BirthDate=DateTime.Parse("1997-11-05")},
    new Client{ClientId=10,FirstName="Carmen",LastName="Bălănescu",Email="carmenbalanescu@gmail.com",BirthDate=DateTime.Parse("1996-06-14")},
    new Client{ClientId=11,FirstName="Radu",LastName="Rădulescu",Email="raduradulescu@gmail.com",BirthDate=DateTime.Parse("1989-02-28")},
    new Client{ClientId=12,FirstName="Anca",LastName="Luca",Email="ancluca@gmail.com",BirthDate=DateTime.Parse("1987-09-09")},
    new Client{ClientId=13,FirstName="Florin",LastName="Păun",Email="florinpaun@gmail.com",BirthDate=DateTime.Parse("1994-10-21")},
    new Client{ClientId=14,FirstName="Bianca",LastName="Munteanu",Email="biancamunteanu@gmail.com",BirthDate=DateTime.Parse("1991-08-05")},
    new Client{ClientId=15,FirstName="Vlad",LastName="Călin",Email="vladcalin@gmail.com",BirthDate=DateTime.Parse("1986-12-12")},
    new Client{ClientId=16,FirstName="Cristina",LastName="Sîrbu",Email="cristinairbu@gmail.com",BirthDate=DateTime.Parse("1992-07-30")},
    new Client{ClientId=17,FirstName="Gabriel",LastName="Botez",Email="gabrielbotez@gmail.com",BirthDate=DateTime.Parse("1984-03-15")},
    new Client{ClientId=18,FirstName="Irina",LastName="Dumitrescu",Email="irinadumitrescu@gmail.com",BirthDate=DateTime.Parse("1999-05-05")},
    new Client{ClientId=19,FirstName="Mihai",LastName="Nistor",Email="mihainistor@gmail.com",BirthDate=DateTime.Parse("1990-11-25")},
    new Client{ClientId=20,FirstName="Stefan",LastName="Cojocaru",Email="stefancojocaru@gmail.com",BirthDate=DateTime.Parse("1985-01-19")}
 };

            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            // subscriptions
            var subscriptions = new Subscription[]
            {
    new Subscription{Started=DateTime.Parse("2024-09-11"), Expires=DateTime.Parse("2024-10-11"), ClientId=1, BranchId=1},
    new Subscription{Started=DateTime.Parse("2024-08-01"), Expires=DateTime.Parse("2024-09-01"), ClientId=2, BranchId=1},
    new Subscription{Started=DateTime.Parse("2024-07-15"), Expires=DateTime.Parse("2024-08-15"), ClientId=3, BranchId=2},
    new Subscription{Started=DateTime.Parse("2024-06-10"), Expires=DateTime.Parse("2024-07-10"), ClientId=4, BranchId=3},
    new Subscription{Started=DateTime.Parse("2024-05-20"), Expires=DateTime.Parse("2024-06-20"), ClientId=5, BranchId=4},
    new Subscription{Started=DateTime.Parse("2024-04-25"), Expires=DateTime.Parse("2024-05-25"), ClientId=6, BranchId=5},
    new Subscription{Started=DateTime.Parse("2024-03-15"), Expires=DateTime.Parse("2024-04-15"), ClientId=7, BranchId=6},
    new Subscription{Started=DateTime.Parse("2024-02-10"), Expires=DateTime.Parse("2024-03-10"), ClientId=8, BranchId=7},
    new Subscription{Started=DateTime.Parse("2024-01-05"), Expires=DateTime.Parse("2024-02-05"), ClientId=9, BranchId=8},
    new Subscription{Started=DateTime.Parse("2023-12-01"), Expires=DateTime.Parse("2024-01-01"), ClientId=10, BranchId=9},
    new Subscription{Started=DateTime.Parse("2023-11-20"), Expires=DateTime.Parse("2023-12-20"), ClientId=11, BranchId=10},
    new Subscription{Started=DateTime.Parse("2023-10-15"), Expires=DateTime.Parse("2023-11-15"), ClientId=12, BranchId=11},
    new Subscription{Started=DateTime.Parse("2023-09-30"), Expires=DateTime.Parse("2023-10-30"), ClientId=13, BranchId=12},
    new Subscription{Started=DateTime.Parse("2023-08-25"), Expires=DateTime.Parse("2023-09-25"), ClientId=14, BranchId=13},
    new Subscription{Started=DateTime.Parse("2023-07-10"), Expires=DateTime.Parse("2023-08-10"), ClientId=15, BranchId=14},
    new Subscription{Started=DateTime.Parse("2023-06-05"), Expires=DateTime.Parse("2023-07-05"), ClientId=16, BranchId=15},
    new Subscription{Started=DateTime.Parse("2023-05-15"), Expires=DateTime.Parse("2023-06-15"), ClientId=17, BranchId=16},
    new Subscription{Started=DateTime.Parse("2023-04-20"), Expires=DateTime.Parse("2023-05-20"), ClientId=18, BranchId=17},
    new Subscription{Started=DateTime.Parse("2023-03-15"), Expires=DateTime.Parse("2023-04-15"), ClientId=19, BranchId=18},
    new Subscription{Started=DateTime.Parse("2023-02-01"), Expires=DateTime.Parse("2023-03-01"), ClientId=20, BranchId=19}

            };


            foreach (Subscription s in subscriptions)
            {
                context.Subscriptions.Add(s);
            }
            context.SaveChanges();
        }
    }
}

