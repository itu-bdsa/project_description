﻿using System.Linq.Expressions;
using System.Collections;
using LibGit2Sharp;
namespace GitInsight;

public class GitInsight
{
    int hewwo;
    public static void Main(string[] args)
    {
        //user inputs commandline switch /fm or /am to pick a program
        if (args[0].Equals("/fm"))
        {
            CommitFrequencyMode();
        }
        else if (args[0].Equals("/am"))
        {
            CommitUserFrequencyMode();
        }
        else
        {
            //if the user didnt write anything or wrote something that wasnt an existing mode:
            // this will loop if the user continueues to do the same as previous, until the user writes an elegible mode
            var blocker = true;
            while (blocker == true)
            {
                Console.WriteLine("Please chose from this list of modes:");
                Console.WriteLine("Frequency mode:   /fm");
                Console.WriteLine("Author mode:      /am");
                string usermode = Console.ReadLine();
                if (usermode.Equals("/fm"))
                {
                    CommitFrequencyMode();
                    blocker = false;
                }
                else if (usermode.Equals("/am"))
                {
                    CommitUserFrequencyMode();
                    blocker = false;
                }
            }

        }
    }

    public static ArrayList CommitFrequencyMode()
    {
        var repoPath = @"C:\Users\eikbo\Skrivebord\BDSA\BDSA_PROJECT\TestGithubStorage\assignment-05";
        var fileOffset = @"C:\Users\annem\Desktop\BDSA_PROJECT\GitInsight.Tests\assignment-05\GildedRose\obj\project.assets.json";
        var fileOffsetFwdSlash = fileOffset.Replace("\\", "/");
        using (var repo = new Repository(repoPath))
        {
            var commitArray = repo.Commits.ToList();
            ArrayList dateArray = new ArrayList();
            for (int i = 0; i < commitArray.Count; i++)
            {
                string[] tempDateArray = commitArray[i].Author.When.ToString().Split(" ");
                dateArray.Add(DateTime.Parse(tempDateArray[0]));
            }

            dateArray.Sort();
            foreach (var item in dateArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(dateArray.Count);
            var currentDate = dateArray[0];
            var currentDateCount = 0;
            foreach (DateTime item in dateArray)
            {

                if (item.CompareTo(currentDate) == 0)
                {
                    currentDateCount = currentDateCount + 1;
                }
                else
                {
                    Console.WriteLine(currentDateCount + " " + currentDate.ToString());
                    currentDate = item;
                    currentDateCount = 1;
                }

            }
            Console.WriteLine(currentDateCount + " " + currentDate.ToString());
            return dateArray;


            //var dates = loges.GroupBy(x => x.Author.When.Date).Count();//.SelectMany(x=>x).ToList();
            //Console.WriteLine(dates);
            /*foreach (var date in dates){
                //Console.WriteLine(date.Take(2));
                foreach (var stuff in date){
                    Console.WriteLine(stuff);
                } 
            }*/

            //foreach (var log in loges){
            //  Console.WriteLine(log + " " + log.Author.When.Date);
            //}
        }
    }

    public static List<List<DateTime>> CommitUserFrequencyMode()
    {
        var repoPath = @"C:\Users\eikbo\Skrivebord\BDSA\BDSA_PROJECT\TestGithubStorage\assignment-05";
        using (var repo = new Repository(repoPath))
        {
            var commitArray = repo.Commits.ToList();
            //var dateAuthorArray = new List<List<String>>();
            var authorArray = FindAllUsersInRepo();
            var dateArray = new List<List<DateTime>>();

            foreach (var item in authorArray)
            {
                dateArray.Add(new List<DateTime>());
            }


            for (int i = 0; i < commitArray.Count; i++)
            {

                string[] tempAuthorArray = commitArray[i].Author.ToString().Split(" ");

                for (int m = 0; m < authorArray.Count; m++)
                {
                    if (authorArray[m].Equals(tempAuthorArray[0]))
                    {
                        string[] tempDateArray = commitArray[i].Author.When.ToString().Split(" ");
                        dateArray[m].Add(DateTime.Parse(tempDateArray[0]));
                    }

                }

            }

            foreach (var item in dateArray)
            {
                item.Sort();
            }
            var authorCounter = 0;
            foreach (var item in dateArray)
            {

                Console.WriteLine(authorArray[authorCounter]);
                var currentDate = item[0];
                var currentDateCount = 1;
                for (int i = 0; i < item.Count - 1; i++)
                {
                    if (item[i].CompareTo(currentDate) == 0)
                    {
                        currentDateCount = currentDateCount + 1;
                    }
                    else
                    {
                        Console.WriteLine(currentDateCount + " " + currentDate.ToString());
                        currentDate = item[i];
                        currentDateCount = 1;
                    }
                }
                Console.WriteLine(currentDateCount + " " + currentDate.ToString());
                Console.WriteLine("");
                authorCounter = authorCounter + 1;
            }

            return dateArray;


        }
    }

    public static List<String> FindAllUsersInRepo(){
    var repoPath = @"C:\Users\eikbo\Skrivebord\BDSA\BDSA_PROJECT\TestGithubStorage\assignment-05";
        using (var repo = new Repository(repoPath))
        {

            var commitArray = repo.Commits.ToList();
            var authorArray = new List<String>();

             for (int i = 0; i < commitArray.Count; i++)
            {
                string[] tempAuthorArray = commitArray[i].Author.ToString().Split(" ");
                if (!authorArray.Contains(tempAuthorArray[0]))
                {
                    authorArray.Add(tempAuthorArray[0]);
                }
            }

            return authorArray;
        }
    }
}