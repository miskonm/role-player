using UnityEngine;

namespace RolePlayer.Game.StaticData
{
  [CreateAssetMenu(fileName = nameof(PlayerStaticData), menuName = "StaticData/Player")]
  public class PlayerStaticData : ScriptableObject
  {
    public int Hp;
    public float MoveSpeed;
  }
}
