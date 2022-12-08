using System.Collections.Generic;

namespace AdventOfCode2022.Day7;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(7,1);
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
        //Console.WriteLine(topLevel.PrintTree());
        var total = 0;
        var folderSizes = topLevel.GetFolderSizes();

        foreach (var item in folderSizes)
        {
            if (item.Value <= 100000) total += item.Value;
            Console.WriteLine($"Key = {item.Key}, Value = {item.Value}");
        }
        return total;
    }
}