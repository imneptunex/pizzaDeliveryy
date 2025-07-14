using System.Collections;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject weaponSheath;

    private GameObject currentWeaponInHand;
    private GameObject currentWeaponInSheath;

    private void Start()
    {
        // Start with weapon in sheath
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
    }

    /// <summary>
    /// Call to draw weapon with delay.
    /// </summary>
    public void DrawWeapon()
    {
        StartCoroutine(DrawWeaponRoutine());
    }

    /// <summary>
    /// Call to sheath weapon with delay.
    /// </summary>
    public void SheathWeapon()
    {
        StartCoroutine(SheathWeaponRoutine());
    }

    private IEnumerator DrawWeaponRoutine()
    {
        yield return new WaitForSeconds(0.28f);

        // Spawn weapon in hand, destroy sheath version
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);

        if (currentWeaponInSheath != null)
            Destroy(currentWeaponInSheath);
    }

    private IEnumerator SheathWeaponRoutine()
    {
        yield return new WaitForSeconds(0.3f);

        // Spawn weapon in sheath, destroy hand version
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);

        if (currentWeaponInHand != null)
            Destroy(currentWeaponInHand);
    }
}