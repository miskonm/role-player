using RolePlayer.Data;

namespace RolePlayer.SaveLoad
{
  public interface ISaveLoadProgress : ILoadProgress
  {
    void Save(ProgressData data);
  }
}
