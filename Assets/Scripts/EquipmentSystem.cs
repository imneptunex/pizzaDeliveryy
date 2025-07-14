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
            Destroy(currentWeaponInSheath);
    }

    private IEnumerator SheathWeaponRoutine()
    {
        yield return new WaitForSeconds(0.3f);

   
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
            Destroy(currentWeaponInHand);
    }

    public void StartDealDamage()
    {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().EndDealDamage();
    }

}