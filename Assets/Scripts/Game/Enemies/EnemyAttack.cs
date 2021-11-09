using RolePlayer.Game.Elements;
using RolePlayer.Game.Player;
using UnityEngine;

namespace RolePlayer.Game.Enemies
{
  public class EnemyAttack : MonoBehaviour
  {
    public float AttackDelay;
    public int Damage;
    public Bullet BulletPrefab;

    [SerializeField]
    private float _timer;
    private Transform _playerTransform;

    private void Awake() =>
      ResetTimer();

    private void Start() =>
      _playerTransform = FindObjectOfType<PlayerMove>().transform;

    private void Update()
    {
      _timer -= Time.deltaTime;

      if (_timer > 0)
        return;

      Shoot();
      ResetTimer();
    }

    private void ResetTimer() =>
      _timer = AttackDelay;

    private void Shoot()
    {
      Bullet bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
      bullet.transform.LookAt(_playerTransform);
      bullet.SetDamage(Damage);
    }
  }
}
