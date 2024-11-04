namespace FileyCore.Interfaces;

public interface IFileyFabric<out TFile> 
    where TFile: IFileyItem
{
    TFile CreateFile(string path, IFileyItem? parent = default);
    TFile CreateDirectory(string path, IFileyItem? parent = default);
}