using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject hitVFX;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("you are dead");
    }
    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);
    }
}
