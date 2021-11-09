using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Course.Managers.LocalizationManager;
using RolePlayer.Game.StaticData;
using UnityEditor;
using UnityEngine;

namespace Course.Editor.Config
{
  public class PlayerStatsImporter : AbstractConfigImporter
  {
    public PlayerStatsImporter() : base("1WhQl6dVvSLiR5iezh5otcrdb9aMKiwEZXTrDSf0mVcY", "Player")
    {
    }

    protected override async Task ProcessData(IList<IList<object>> values)
    {
      if (values.Count < 1)
        throw new Exception("Missing player data.");

      if (values[0].Count < 1)
        throw new Exception("Missing player data header.");

      if (values[0][0].ToString() != "HP")
        throw new Exception("Invalid HP player data header.");

      if (values[1][0].ToString() != "MoveSpeed")
        throw new Exception("Invalid MoveSpeed player data header.");

      var asset = ScriptableObject.CreateInstance<PlayerStaticData>();
      asset.Hp = int.Parse(values[0][1].ToString());
      asset.MoveSpeed = float.Parse(values[1][1].ToString());
      AssetDatabase.CreateAsset(asset, "Assets/Config/PlayerStaticData.asset");
      AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Import Player Stats", false, 1100)]
    static void Import()
    {
      new PlayerStatsImporter().DoImport();
    }
  }
}
