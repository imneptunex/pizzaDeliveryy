using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int pizzaSliceCount = 6;
    public int oilCount;
    public int cheeseCount;
    public int pizzaRecover;
    private playerPickUpObject playerPickUpObject;

    [System.Obsolete]
    private void Start()
    {
        playerPickUpObject = FindObjectOfType<playerPickUpObject>();
    }

    private void Update()
    {

        
    }




}
