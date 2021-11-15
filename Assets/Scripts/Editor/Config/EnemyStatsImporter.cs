using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation.Editor;
using RolePlayer.Game.StaticData;
using UnityEditor;
using UnityEngine;

namespace Course.Editor.Config
{
  public class EnemyStatsImporter : AbstractConfigImporter
  {
    private const string AssetPath = "Assets/Configs/StaticData/EnemyStaticData.asset";

    public EnemyStatsImporter() : base("1WhQl6dVvSLiR5iezh5otcrdb9aMKiwEZXTrDSf0mVcY", "Enemies")
    {
    }

    protected override async Task ProcessData(IList<IList<object>> values)
    {
      if (values.Count < 1)
        throw new Exception("Missing Enemies data.");

      if (values[0].Count < 1)
        throw new Exception("Missing Enemies data header.");

      if (values[0][0].ToString() != "Damage")
        throw new Exception("Invalid Damage Enemies data header.");

      if (values[1][0].ToString() != "Cooldown")
        throw new Exception("Invalid Cooldown Enemies data header.");

      var asset = ScriptableObject.CreateInstance<EnemyStaticData>();
      asset.Damage = int.Parse(values[0][1].ToString());
      asset.Cooldown = float.Parse(values[1][1].ToString());
      AssetDatabase.CreateAsset(asset, AssetPath);
      AssetDatabase.SaveAssets();

      await Progress(1);
    }

    [MenuItem("Tools/Import Enemy Stats", false, 1100)]
    static void Import()
    {
      new EnemyStatsImporter().DoImport();
    }
  }
}
