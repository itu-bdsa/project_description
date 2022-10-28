namespace GitInsight;

using static Mode;
class Control
{
    private Data? _repo;
    private Mode _mode;
    private Boolean _isLoaded;
    public void Run() {
        var isRunning = true;
        _isLoaded = false;

        while (isRunning)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "author":
                    _mode = AUTHOR;
                    break;
                case "frequency":
                    _mode = FREQUENCY;
                    break;
                case "print":
                    if (!_isLoaded){
                        Console.WriteLine("no dataset loaded");
                    } else
                    {
                        _repo!.print(_mode);
                    }
                    break;
                case "newpath":
                    Console.WriteLine("Insert path:");
                    var path = Console.ReadLine();
                    _repo = new Data(path!);
                    _isLoaded = true;
                    break;
                case "help":
                    Console.WriteLine("'newpath' to set new repository path.");
                    Console.WriteLine("'author' to switch to AUTHOR mode.");
                    Console.WriteLine("'frequency' to switch to FREQUENCY mode.");
                    Console.WriteLine("'print' to print repository details.");
                    Console.WriteLine("'exit' to exit program");
                    break;
                case "exit":
                        isRunning = false;
                    break;
                default:
                    Console.WriteLine("Command doesn't exist. Type 'help' for commandlist");
                    break;
            }
        }
    }
}