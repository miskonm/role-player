using System;
using UnityEngine;
using Zenject;

namespace Foundation
{
    public sealed class CharacterWeapon :
        AbstractService<ICharacterWeapon>, ICharacterWeapon, IOnUpdate, IOnAttackAnimationEnded
    {
        [Serializable]
        public struct SelectableWeapon
        {
            public AbstractWeapon Weapon;
            public GameObject Visual;
            public AbstractWeaponAttack Attack;
            public string InputActionName;
        }

        [SerializeField] AbstractWeapon initialWeapon;
        [SerializeField] [ReadOnly] AbstractWeapon currentWeapon;
        [SerializeField] [ReadOnly] AbstractWeapon attackingWeapon;
        [SerializeField] [ReadOnly] float cooldownAfterAttack;

        public AbstractWeapon CurrentWeapon => (attackingWeapon != null ? attackingWeapon : currentWeapon);
        public AbstractWeapon AttackingWeapon => attackingWeapon;
        public ObserverList<IOnCharacterAttack> OnAttack { get; } = new ObserverList<IOnCharacterAttack>();

        [SerializeField] SelectableWeapon[] weapons;

        [InjectOptional] IPlayer player = default;
        [InjectOptional] IInventory inventory = default;
        [Inject] IInputManager inputManager = default;
        [Inject] ISceneState sceneState = default;
        [Inject] CharacterAnimationEvents animationEvents = default;

        public override void Start()
        {
            base.Start();
            SetCurrentWeaponForce(initialWeapon);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(sceneState.OnUpdate);
            Observe(animationEvents.OnAttackEnded);
        }

        public bool CanAttack()
        {
            // Нельзя атаковать, если сейчас уже атакуем
            if (attackingWeapon != null)
                return false;

            // Нельзя атаковать, если нет оружия
            if (currentWeapon == null)
                return false;

            // Нельзя атаковать, если не хватает патронов
            return currentWeapon.CanShoot(inventory != null ? inventory.RawStorage : null);
        }

        public void Attack()
        {
            if (!CanAttack())
                return;

            AbstractWeaponAttack attack = null;
            foreach (var it in weapons) {
                if (it.Weapon == currentWeapon) {
                    attack = it.Attack;
                    break;
                }
            }

            if (!currentWeapon.PrepareShoot(inventory != null ? inventory.RawStorage : null, attack))
                return;

            attackingWeapon = currentWeapon;
            foreach (var it in OnAttack.Enumerate())
                it.Do(attackingWeapon);
        }

        public void EndAttack(bool applyCooldown)
        {
            DebugOnly.Check(attackingWeapon != null, "Unexpected EndAttack.");

            AbstractWeaponAttack attack = null;
            foreach (var it in weapons) {
                if (it.Weapon == currentWeapon) {
                    attack = it.Attack;
                    break;
                }
            }

            attackingWeapon.EndShoot(attack);

            if (applyCooldown) {
                cooldownAfterAttack = attackingWeapon.AttackCooldownTime;
                if (cooldownAfterAttack > 0.0f)
                    return;
            }

            attackingWeapon = null;
            UpdateWeaponVisibility();
        }

        public void SetCurrentWeapon(AbstractWeapon weapon)
        {
            if (currentWeapon != weapon)
                SetCurrentWeaponForce(weapon);
        }

        void SetCurrentWeaponForce(AbstractWeapon weapon)
        {
            currentWeapon = weapon;
            if (attackingWeapon == null)
                UpdateWeaponVisibility();
        }

        void UpdateWeaponVisibility()
        {
            foreach (var it in weapons) {
                if (it.Visual != null)
                    it.Visual.SetActive(currentWeapon == it.Weapon);
            }
        }

        void IOnAttackAnimationEnded.Do()
        {
            DebugOnly.Check(attackingWeapon != null, "Unexpected attack animation end event.");
            EndAttack(applyCooldown: true);
        }

        void IOnUpdate.Do(float timeDelta)
        {
            if (cooldownAfterAttack > 0.0f) {
                cooldownAfterAttack -= timeDelta;
                if (cooldownAfterAttack <= 0.0f)
                    EndAttack(applyCooldown: false);
            }

            if (player != null) {
                var input = inputManager.InputForPlayer(player.Index);

                if (weapons != null) {
                    foreach (var weapon in weapons) {
                        if (input.Action(weapon.InputActionName).Triggered)
                            SetCurrentWeapon(weapon.Weapon);
                    }
                }
            }
        }
    }
}
