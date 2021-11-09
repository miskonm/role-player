using System;
using RolePlayer.Game.Elements;
using RolePlayer.Game.Enemies;
using RolePlayer.Game.Player;
using RolePlayer.Game.StaticData;
using UnityEngine;

namespace RolePlayer.Game.Manager
{
  public class StaticDataSetter : MonoBehaviour
  {
    [Header("Player")]
    public Health PlayerHealth;
    public PlayerMove PlayerMove;
    public PlayerStaticData PlayerData;

    [Header("Enemy")]
    public EnemyAttack EnemyAttack;
    public EnemyStaticData EnemyData;

    private void Awake()
    {
      PlayerHealth.Setup(PlayerData.Hp);
      PlayerMove.MoveSpeed = PlayerData.MoveSpeed;

      EnemyAttack.Damage = EnemyData.Damage;
      EnemyAttack.AttackDelay = EnemyData.Cooldown;
    }
  }
}
