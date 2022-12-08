namespace AdventOfCode2022.Day7;

class Folder
{
    private Folder(string name, Folder parent)
    {
        Name = name;
        ParentFolder = parent;
        Depth = parent.GetDepth() + 1;
    }

    public Folder(string name)
    {
        Name = name;
        Depth = 0;
    }

    private int Depth;
    public string Name { get; }
    private Folder ParentFolder;
    private List<Folder> SubFolders;
    private List<File> SubFiles;

    public void AddSubFile(string name, int size)
    {
        if(SubFiles == null) SubFiles = new List<File>();
        SubFiles.Add(new File(size, name, Depth + 1));
    }

    private void AddFolder(string name)
    {
        if(SubFolders == null) SubFolders = new List<Folder>();
        SubFolders.Add(new Folder(name, this));
    }

    public int GetDepth()
    {
        return Depth;
    }

    public Folder GetParent()
    {
        return ParentFolder;
    }

    public int GetSize()
    {
        var size = 0;
        if (SubFiles != null)
        {
            SubFiles.ForEach(x =>
            {
                size += x.Size;
            });
        }
        if(SubFolders != null)
        {
            SubFolders.ForEach(x => {
                size += x.GetSize();
            });
        }
        return size;
    }

    public Dictionary<string,int> GetFolderSizes()
    {
        var name = Name + "_" + RandomString(8);
        var sizes = new Dictionary<string, int>() { { name, GetSize() } };
        if (SubFolders != null)
        {
            SubFolders.ForEach(x => {
                var folderSizes = x.GetFolderSizes();
                foreach(var item in folderSizes)
                {
                    sizes.Add(item.Key, item.Value);
                }
            });
        }
        return sizes;
    }

    public Folder Goto(string name)
    {
        AddFolder(name);
        return SubFolders[SubFolders.Count - 1];
    }

    public Folder TopLevel()
    {
        if (Name == "/") return this;
        return ParentFolder.TopLevel();
    }

    public string PrintTree()
    {
        var depth = "";
        for (int i = 0; i < Depth; i++) depth += "  ";
        var tree = $"{depth}- {Name} (dir) {GetSize()}\r\n";

        if (SubFiles != null)
        {
            SubFiles.ForEach(x =>
            {
                tree += x.PrintTree() + "\r\n";
            });
        }

        if (SubFolders != null)
        {
            SubFolders.ForEach(x =>
            {
                tree += x.PrintTree();
            });
        }

        return tree;
    }

    private static Random random = new Random();

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}

class File
{
    public File(int size, string name, int depth)
    {
        Size = size;
        Name = name;
        Depth = depth;
    }

    private int Depth;
    public int Size;
    public string Name;

    public string PrintTree()
    {
        var depth = "";
        for (int i = 0; i < Depth; i++) depth += "  ";
        return $"{depth}- {Name} {Size}";
    }
}