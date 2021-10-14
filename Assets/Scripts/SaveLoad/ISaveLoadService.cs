using RolePlayer.Data;

namespace RolePlayer.SaveLoad
{
  public interface ISaveLoadService
  {
    ProgressData ProgressData { get; }

    void Register(ILoadProgress loader);
    void Save();
    void Load();
  }
}
