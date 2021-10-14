using System.Collections.Generic;

namespace RolePlayer.SaveLoad
{
  public class SaveLoadContainer
  {
    public readonly List<ILoadProgress> Loaders = new List<ILoadProgress>();
    public readonly List<ISaveLoadProgress> Savers = new List<ISaveLoadProgress>();

    public void Add(ILoadProgress loader)
    {
      if(loader is ISaveLoadProgress saver)
        Savers.Add(saver);
      
      Loaders.Add(loader);
    }
  }
}
