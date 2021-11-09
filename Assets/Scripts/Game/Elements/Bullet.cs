using UnityEngine;

namespace RolePlayer.Game.Elements
{
  public class Bullet : MonoBehaviour
  {
    public float MoveSpeed;
    public float LifeTime;

    private int _damage;

    private void Update()
    {
      Move();
      CountLifeTime();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (!other.CompareTag("Player"))
        return;

      other.GetComponentInChildren<Health>().DoDamage(_damage);

      Destroy(gameObject);
    }

    public void SetDamage(int damage) =>
      _damage = damage;

    private void Move() =>
      transform.position += transform.forward * MoveSpeed * Time.deltaTime;

    private void CountLifeTime()
    {
      LifeTime -= Time.deltaTime;

      if (LifeTime <= 0)
        Destroy(gameObject);
    }
  }
}
