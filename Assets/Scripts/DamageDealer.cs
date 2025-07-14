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

            int layerMask = 1 << 26; 

            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                

                if (hit.transform.TryGetComponent(out SkeletonEnemy skeletonEnemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                   
                    skeletonEnemy.TakeDamage(weaponDamage);
                    skeletonEnemy.HitVFX(hit.point);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
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
