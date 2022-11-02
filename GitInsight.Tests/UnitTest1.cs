namespace GitInsight.Tests;
using System.Diagnostics;
using System.Globalization;
using LibGit2Sharp;
//using (var repo = new Repository(@"/Users/sushi/code/sushi/Xamarin.Forms.Renderer.Tests"))


//søndag d.25 setember - 2 commits
//Torsdag d.6 october - 6 commits
//Fredag d.7 october - 3 commits
//Lørdag d.8 october - 10 commits
//Søndag d.9 october - 1 commits
//Torsdag d.13 october - 3 commits

public class UnitTest1
{
    [Fact]
    public void GithubIsStillTheSame()
    {
        //Arrange
        var repoPath = @"C:\Users\eikbo\Skrivebord\BDSA\BDSA_PROJECT\TestGithubStorage\assignment-05";
        var counter = 0;

        //Act
        using (var repo = new Repository(repoPath))
        {
            var logs = repo.Commits.ToList();
            foreach (var log in logs)
            {
                counter++;
            }
        }
        //Actual

        Assert.Equal(31, counter);

    }


        [Fact]
    public void October8Has10Commits()
    {
        //Arrange
        var dateArray = GitInsight.CommitFrequencyMode();
        //Act
            Calendar euCalendar = new GregorianCalendar();
            var octoberDate = new DateTime(2022,10,08, euCalendar);
            Console.WriteLine(octoberDate);
            var octoberCount = 0;
            foreach (DateTime item in dateArray)
            {

                if (item.CompareTo(octoberDate) == 0)
                {
                    Console.WriteLine("HIT!");
                    octoberCount = octoberCount + 1;
                }

            }

        //Actual

        Assert.Equal(10, octoberCount);

    }

           [Fact]
    public void EikboHas11Commits()
    {
        //Arrange
        var counter = 0;
        var pointer = 0;
        var authorArray = GitInsight.FindAllUsersInRepo();
        var dateArray = GitInsight.CommitUserFrequencyMode();

        //Act
        for (int i = 0; i < authorArray.Count; i++)
        {
            if(authorArray[i].Equals("eikbo")){
                pointer = i;
                counter = dateArray[i].Count;
            }
        }

        //Actual

        Assert.Equal(11, counter);

    }

              [Fact]
    public void EikboHas10CommitsOnOct8()
    {
        //Arrange
        var counter = 0;
        var pointer = 0;
        Calendar euCalendar = new GregorianCalendar();
        var authorArray = GitInsight.FindAllUsersInRepo();
        var dateArray = GitInsight.CommitUserFrequencyMode();

        //Act
        for (int i = 0; i < authorArray.Count; i++)
        {
            if(authorArray[i].Equals("eikbo")){
                pointer = i;
            }
        }

        foreach (var item in dateArray[pointer])
        {
            if(item.CompareTo(new DateTime(2022,10,08,euCalendar)) == 0){
                counter++;
            }
        }

        //Actual

        Assert.Equal(10, counter);

    }
}