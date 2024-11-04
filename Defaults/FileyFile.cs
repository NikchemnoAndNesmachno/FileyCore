using FileyCore.Interfaces;

namespace FileyCore.Defaults;

public class FileyFile: IFileyItem
{
    public IFileyItem? Parent { get; set; }
    public string Path { get; set; } = "";
    public string Name { get; set; } = "";
    public bool IsDirectory { get; set; } = false;
    
    public IList<IFileyItem> Files { get; set; } = [];
}