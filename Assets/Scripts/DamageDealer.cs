using UnityEngine;
using System.Collections.Generic;

public class DamageDealer : MonoBehaviour
{
    bool canDealDamage;
    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    List<GameObject> hasDealtDamage;

    
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 26; // ✅ Correct layer!

            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                Debug.Log("Raycast hit: " + hit.transform.name);

                if (hit.transform.TryGetComponent(out SkeletonEnemy skeletonEnemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    Debug.Log("debug");
                    skeletonEnemy.TakeDamage(weaponDamage);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
            else
            {
                Debug.Log("Raycast hit nothing");
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
