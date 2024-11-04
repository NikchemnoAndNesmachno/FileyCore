namespace FileyCore.Interfaces;

public interface IFileyItem
{
    IFileyItem? Parent { get; set; }
    string Path { get; set; }
    string Name { get; set; }
    bool IsDirectory { get; set; }
    IList<IFileyItem> Files { get; set; }
}