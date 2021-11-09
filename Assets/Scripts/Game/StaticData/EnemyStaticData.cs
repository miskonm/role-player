using UnityEngine;

namespace RolePlayer.Game.StaticData
{
  [CreateAssetMenu(fileName = nameof(EnemyStaticData), menuName = "StaticData/Enemy")]
  public class EnemyStaticData : ScriptableObject
  {
    public int Damage;
    public float Cooldown;
  }
}
