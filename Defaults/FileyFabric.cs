using FileyCore.Interfaces;

namespace FileyCore.Defaults;

public class FileyFabric: IFileyFabric<FileyFile>
{
    public FileyFile CreateFile(string path, IFileyItem? parent=default) => new()
    {
        Path = path,
        IsDirectory = false,
        Parent = parent
    };

    public FileyFile CreateDirectory(string path, IFileyItem? parent=default) => new()
    {
        Path = path,
        IsDirectory = true,
        Parent = parent
        
    };
}