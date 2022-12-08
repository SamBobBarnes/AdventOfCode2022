namespace AdventOfCode2022.Day7;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(7,2);
        var input = LoadInput(7);
        var commandList = input.Select(x => new Command(x)).ToList();
        var currentFolder = new Folder("/");

        commandList.ForEach(c =>
        {
            if(c.Type == CommandType.Cd)
            {
                if(c.Name == "..")
                {
                    currentFolder = currentFolder.GetParent();
                }
                else if(c.Name == "/")
                {

                }
                else
                {
                    currentFolder = currentFolder.Goto(c.Name);
                }
            }
            else if (c.Type == CommandType.File)
            {
                currentFolder.AddSubFile(c.Name, c.Size);
            }
        });


        var topLevel = currentFolder.TopLevel();
        var totalSpace = 70000000;
        var spaceNeeded = 30000000;
        var spaceUsed = topLevel.GetSize();
        var spaceRemaining = totalSpace - spaceUsed;
        var spaceToRemove = spaceNeeded - spaceRemaining;
        Console.WriteLine(spaceUsed);
        Console.WriteLine(spaceRemaining);
        Console.WriteLine(spaceToRemove);
        var smallestFolder = 30000000;
        var folderSizes = topLevel.GetFolderSizes();

        foreach (var item in folderSizes)
        {
            if (item.Value <= smallestFolder && item.Value > spaceToRemove) smallestFolder = item.Value;
            Console.WriteLine($"Key = {item.Key}, Value = {item.Value}");
        }
        Console.WriteLine(spaceToRemove);
        return smallestFolder;
    }
}