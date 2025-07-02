using UnityEngine;

public class SkillSet : MonoBehaviour
{

    private Inventory inventory;

    [System.Obsolete]
    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HandlePizzaSkill();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HandleOilSkill();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HandleCheeseSkill();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            HandlePizzaRecover();
        }

    }

    private void HandlePizzaSkill()
    {
        
            if (inventory.pizzaSliceCount > 2)
            {
                Debug.Log("pizza throwing");
                inventory.pizzaSliceCount -= 1;


            }
            else if (inventory.pizzaSliceCount == 2)
            {
                Debug.Log("if you throw another pizza, you will fail");
                inventory.pizzaSliceCount -= 1;

            }
            else
            {
                inventory.pizzaSliceCount -= 1;
                Debug.Log("game over");
            }
        

    }


   private void HandleOilSkill()
   {
        if (inventory.oilCount > 0)
        {
            Debug.Log("oil throw");
            inventory.cheeseCount -= 1;
        }

        else
        {

            Debug.Log("You dont have any oil left");
        }


    }



    private void HandleCheeseSkill()
   {
        if (inventory.cheeseCount > 0)
        {
            Debug.Log("cheese throwing");
            inventory.cheeseCount -= 1;

        }
        
        else
        {
           
            Debug.Log("You dont have any cheese left");
        }


    }

    private void HandlePizzaRecover()
    {
        if (inventory.pizzaRecover > 0)
        {
            inventory.pizzaSliceCount += 1;
            inventory.pizzaRecover -= 1;
        }
        else
        {
            Debug.Log("you cannot recover pizza because you dont have any recoverer");
        }
    }
}
