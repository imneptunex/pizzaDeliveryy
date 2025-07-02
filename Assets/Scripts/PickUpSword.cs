using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    [SerializeField] private bool hasSword;
    [SerializeField] private GameObject oldSword;
    private Animator animator;

    void Start()
    {
        hasSword = false;
        animator = GetComponent<Animator>();
    }


    private void Update()
    {

        HandleSwordEnable();


    }

    private void HandleSwordEnable()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            if(!hasSword)
            {
                // animator trigger "withdrawSword"
                animator.SetTrigger("withdrawSword");
                Debug.Log("getting sword");
                oldSword.gameObject.SetActive(true);
                hasSword = true;
                 


            }
        }
    }
}
