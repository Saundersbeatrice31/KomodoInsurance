using KomodoInsuranceDeveloper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceUI
{
    public class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _developerTeamRepo = new DevTeamRepo();
        //Method that Runs the application
        public void Run()
        {
            //putting in seed Data
            SeedDeveloperList();
            DisplayMenu();
        }
        //Menu
        private void DisplayMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display the Options for the Managers
                Console.WriteLine("Please select an option:\n" + "1.Add Developer\n" + "2.Add a developer Team\n" + "3.Add developer to Team\n" + "4.View list of all developers\n" + "5.View List of all developer Teams\n" + "6.View developer by Unique ID\n" + "7.Update list of developers\n" + "" + "8.Update List of Developer Teams\n" + "9.Remove developer from list\n" + "10.Remove developer from team\n" +
                    "11.Exit.\n");
                //Get the managers input
                string input = Console.ReadLine();

                //Evaluate the managers input and act accordingly
                switch (input)
                {
                    case "1":
                        //Add developers
                        AddingNewDevelopers();
                        break;
                    case "2":
                        //Add a developer team
                        AddDeveloperTeams();
                        break;
                    case "3":
                        //Add a Developer to a team
                        AddDeveloperToDevTeams();
                        break;

                    case "4":
                        //view list of developers
                        DisplayAllDevelopers();
                        break;
                    case "5":
                        //view list of all teams
                        DisplayAllDeveloperTeams();
                        break;
                    case "6":
                        //view developer by UniqueID
                        AddingNewDevelopersByUniqueID();
                        break;
                    case "7":
                        //update list of developers
                        UpdateExistingDevelopersList();
                        break;
                    case "8":
                        //update list of developer Teams
                        UpdateExistingDeveloperTeams();
                        break;
                    case "9":
                        //remove developer from list
                        RemoveExistingDeveloper();
                        break;
                    case "10":
                        //Remove developer from team
                        RemoveDeveloperFromTeam();
                        break;
                    case "11":
                        //Exit menu
                        Console.WriteLine("GoodBye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 6.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create new Developer list
        private void AddingNewDevelopers()
        {
            Console.Clear();
            Developers newDevs = new Developers();
            //DevName
            Console.WriteLine("Please enter the name of the developer you want to add:");
            newDevs.DevName = Console.ReadLine();
            //Unique ID
            Console.WriteLine("Please add a Unique ID number for each developer:");
            string uniqueIdAsString = Console.ReadLine();
            newDevs.UniqueId = int.Parse(uniqueIdAsString);
            //PluralSight Membership
            Console.WriteLine("Is this developer a member of Plural Sight? (y/n)");
            string pluralSightString = Console.ReadLine().ToLower();

            if (pluralSightString == "y")
            {
                newDevs.PluralSightMember = true;
            }
            else
            {
                newDevs.PluralSightMember = false;
            }
            _developerRepo.AddDeveloperToList(newDevs);
        }
        private void AddDeveloperTeams()
        {
            Console.Clear();
            DevTeams newDevTeams = new DevTeams();
            //DevName
            Console.WriteLine("Please enter the name of the developer Team you want to add:");
            newDevTeams.TeamName = Console.ReadLine();
            //Unique ID
            Console.WriteLine("Please add a Unique ID number for the Team you want to add:");
            string uniqueIdAsString = Console.ReadLine();
            newDevTeams.TeamId = int.Parse(uniqueIdAsString);
            _developerTeamRepo.AddDeveloperTeams(newDevTeams);
        }
        private void AddDeveloperToDevTeams()
        {
            Console.Clear();
            //AddDeveloperToDevTeams();
            DisplayAllDeveloperTeams();
            DisplayAllDevelopers();
            DevTeams newDevTeams = new DevTeams();
            //DevName
            Console.WriteLine("What team do you want to add them to?");
            int teamid = int.Parse(Console.ReadLine());
            List<Developers> testing = _developerRepo.GetDevelopersList();
            Console.WriteLine("What is the name of the Dev you want to add?");
            string userinput = Console.ReadLine();
            Developers newdev = new Developers();
            foreach (var item in testing)
            {
                if (item.DevName == userinput)
                {
                    newdev = item;
                }
            }            
            _developerTeamRepo.AddDeveloperToTeams(teamid, newdev);
        }
        //View current list of Developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developers> ListOfDevelopers = _developerRepo.GetDevelopersList();
            //loop through Contents
            foreach (Developers developers in ListOfDevelopers)
            {
                Console.WriteLine($"Developer First and Last Name: {developers.DevName}\n" +
                    $"Unique ID number:{developers.UniqueId}\n" +
                    $"Is the developer a Member of Plural Sight: {developers.PluralSightMember}");
            }
        }
        private void DisplayAllDeveloperTeams()
        {
            Console.Clear();
            List<DevTeams> ListOfDeveloperTeams = _developerTeamRepo.GetDevelopersTeamsList();
            foreach (DevTeams ListOfTeams in ListOfDeveloperTeams)
            {
                Console.WriteLine(ListOfTeams.TeamName);
            }
            Console.ReadLine();
        }
        //view existing developers by Unique ID
        private void AddingNewDevelopersByUniqueID()
        {
            Console.Clear();
            //Prompt the manager to give a Unique Id
            Console.WriteLine("Please enter the Unique ID number of the developer you would like to see:");
            //Get manager input
            string uniqueIdAsString = Console.ReadLine();
            int UniqueId = int.Parse(uniqueIdAsString);
            //Find developer by Unique ID
            Developers developers = _developerRepo.GetDeveloperByUniqueId(UniqueId);
            //Display if list if it is not null
            if (developers != null)
            {
                Console.WriteLine($"Developer Name:{developers.DevName}\n" +
                    $"Unique ID number:{developers.UniqueId}\n" +
                    $"Is the developer a Member of Plural Sight: {developers.PluralSightMember}");
            }
            else
            {
                Console.WriteLine("There is no develooper associated with this ID number");
            }
        }
        //Update Existing Developer list
        private void UpdateExistingDevelopersList()
        {
            Console.Clear();
            DisplayAllDevelopers();
            //Ask manager for the ID number they want to update
            Console.WriteLine("Please enter the ID number of the developer you would like to update:");
            //Get the ID number
            string existingId = Console.ReadLine();
            int UniqueId = int.Parse(existingId);

            //building a new object
            Developers newDeveloper = new Developers();
            //Developer Name
            Console.WriteLine("Please enter the developers name you want to update:");
            newDeveloper.DevName = Console.ReadLine();
            //Unique ID
            Console.WriteLine("Please enter an ID number:");
            string existingUnId = Console.ReadLine();
            newDeveloper.UniqueId = int.Parse(existingUnId);
            //Plural sight Membership
            Console.WriteLine("Is this developer a member of Plural Sight? (y/n)");
            string pluralSightString = Console.ReadLine().ToLower();

            if (pluralSightString == "y")
            {
                newDeveloper.PluralSightMember = true;
            }
            else
            {
                newDeveloper.PluralSightMember = false;
            }
        }
        private void UpdateExistingDeveloperTeams()
        {
            Console.Clear();

            DisplayAllDeveloperTeams();
            //Ask manager for the ID number they want to update
            Console.WriteLine("Please enter the ID number of the developer team  you would like to update:");
            //Get the ID number
            string existingTeamId = Console.ReadLine();
            int UniqueId = int.Parse(existingTeamId);

            var currenteam = _developerTeamRepo.GetTeamById(UniqueId);

            Console.WriteLine("Please enter the developers name you want to update:");
            string userinput = Console.ReadLine();
            foreach (var item in currenteam.TeamMembers)
            {
                if (item.DevName == userinput)
                {

                    Console.WriteLine("Dev name");
                    item.DevName = Console.ReadLine();
                    item.PluralSightMember = bool.Parse(Console.ReadLine());
                }
            }

            _developerTeamRepo.UpdateExistingDevelopersTeams(UniqueId, currenteam);
        }
        //Remove Existing Developer 
        private void RemoveExistingDeveloper()
        {
            Console.Clear();
            DisplayAllDevelopers();
            //Get developer you want to delete
            Console.WriteLine("\n Please enter the ID number of the developer you want to remove:");
            int Id = int.Parse(Console.ReadLine());

            //call teh delete method
            bool wasRemoved = _developerRepo.RemoveDeveloperFromList(Id);
            if (wasRemoved)
            {
                Console.WriteLine("The Developer was succesfully removed.");
            }
            else
            {
                Console.WriteLine("The Developer could not be removed.");
            }
        }
        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            DisplayAllDevelopers();
            DisplayAllDeveloperTeams();
            //Get developer you want to delete from team
            Console.WriteLine("\n Please enter the ID number of the developer you want to remove from the team:");
            int Id = int.Parse(Console.ReadLine());

            //call teh delete method
            bool wasRemoved = _developerRepo.RemoveDeveloperFromList(Id);
            if (wasRemoved)
            {
                Console.WriteLine("The Developer Team was succesfully removed.");
            }
            else
            {
                Console.WriteLine("The Developer Team could not be removed.");
            }
        }
        //Seed method
        private void SeedDeveloperList()
        {
            Developers test = new Developers("Lilian Smithe", 1111, true);
            Developers test1 = new Developers("Lilian Smithe", 1111, true);
            Developers test2 = new Developers("Lilian Smithe", 1111, true);
            Developers test3 = new Developers("Lilian Smithe", 1111, true);

            _developerRepo.AddDeveloperToList(test);
            _developerRepo.AddDeveloperToList(test2);
            _developerRepo.AddDeveloperToList(test3);
            _developerRepo.AddDeveloperToList(test1);
        }
    }
}
