using UnityEngine;

namespace Synty.AnimationBaseLocomotion.Samples.InputSystem
{
    [RequireComponent(typeof(Animator))]
    public class PlayerCombat : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private EquipmentSystem _equipmentSystem;

        private Animator _animator;

        private bool _weaponDrawn = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            Debug.Assert(_animator != null, "Animator is NULL!");
            Debug.Assert(_equipmentSystem != null, "EquipmentSystem is NULL!");
            Debug.Assert(_inputReader != null, "InputReader is NULL!");
        }

        private void OnEnable()
        {
            _inputReader.onDrawWeaponPerformed += ToggleWeapon;
            _inputReader.onAttackPerformed += Attack;
        }

        private void OnDisable()
        {
            _inputReader.onDrawWeaponPerformed -= ToggleWeapon;
            _inputReader.onAttackPerformed -= Attack;
        }

        private void ToggleWeapon()
        {
            if (_weaponDrawn)
            {
                _animator.SetTrigger("sheatWeapon");
                _equipmentSystem.SheathWeapon();
                _weaponDrawn = false;
            }
            else
            {
                _animator.SetTrigger("drawWeapon");
                _equipmentSystem.DrawWeapon();
                _weaponDrawn = true;
            }
        }

        private void Attack()
        {
            if (!_weaponDrawn)
            {
                
                return;
            }

            _animator.SetTrigger("attack");
            
        }
    }
}