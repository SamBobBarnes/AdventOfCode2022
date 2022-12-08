namespace AdventOfCode2022.Day7;

class Command
{
    public Command(string command)
    {
        var commandList = command.Split(" ").ToList();
        switch(commandList[0])
        {
            case "$":
                if(commandList[1] == "cd")
                {
                    Type = CommandType.Cd;
                    Name = commandList[2];
                }
                else
                {
                    Type = CommandType.Ls;
                }
                break;
            case "dir":
                Type = CommandType.Folder;
                Name = commandList[1];
                break;
            default:
                Type = CommandType.File;
                Name = commandList[1];
                Size = int.Parse(commandList[0]);
                break;
        }
    }

    public string Type;
    public string Name;
    public int Size;

    public new string ToString()
    {
        switch (Type)
        {
            case "cd":
                return $"cd {Name}";
            case "ls":
                return $"ls";
            case "folder":
                return $"dir {Name}";
            case "file":
                return $"{Name} {Size.ToString()}";
            default:
                return "crap!";
        } 
    }
}

class CommandType
{
    public static string Cd = "cd";
    public static string Ls = "ls";
    public static string Folder = "folder";
    public static string File = "file";
}