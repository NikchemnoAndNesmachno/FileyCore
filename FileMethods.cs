using FileyCore.Defaults;
using FileyCore.Interfaces;

namespace FileyCore;

public class FileMethod
{
    public IFileyFabric<IFileyItem> FileyFabric { get; set; } = new FileyFabric();

    public void LoadFull(IFileyItem item)
    {
        item.Files.Clear();
        LoadDirectories(item);
        LoadFiles(item);
    }
    public void LoadFiles(IFileyItem item)
    {
        if(!item.IsDirectory) return;
        var files = Directory.GetFiles(item.Path);
        foreach (var filePath in files)
        { 
            var fileObj = FileyFabric.CreateFile(filePath, item);
            item.Files.Add(fileObj);
        }
    }

    public void LoadDirectories(IFileyItem item)
    {
        if (!item.IsDirectory) return;
        var dirs = Directory.GetDirectories(item.Path);
        foreach (var filePath in dirs)
        {
            var fileObj = FileyFabric.CreateDirectory(filePath, item);
            item.Files.Add(fileObj);
        }
    }

    public IFileyItem[] GetDrives()
    {
        var drives = DriveInfo.GetDrives();
        var files = new IFileyItem[drives.Length];
        for (int i = 0; i < drives.Length; i++)
        {
            files[i] = FileyFabric.CreateDirectory(drives[i].Name);
        }
        return files;
    }

    public void Move(IFileyItem item, IFileyItem directory)
    {
        var newPath = Path.Combine(directory.Path, Path.GetFileName(item.Path));
        File.Move(item.Path, newPath);
    }

    public void Rename(IFileyItem item, string newName)
    {
        var parent = item.Parent;
        if(parent is null) return;
        var newPath = Path.Combine(parent.Path, newName);
        File.Move(item.Path, newPath);
    }
    
}