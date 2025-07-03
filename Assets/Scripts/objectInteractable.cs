using UnityEngine;

public class objectInteractable : MonoBehaviour
{

    //Scripts
    private TorchQuest torchQuest;
    private playerPickUpObject playerPickUp;

    [System.Obsolete]
    private void Start()
    {
        torchQuest = FindObjectOfType<TorchQuest>();
        playerPickUp = GameObject.Find("Player").GetComponent<playerPickUpObject>();

    }


    private void Update()
    {



    }

    public void Interact()
    {
        
        if(playerPickUp.currentObjectSO != null)
        {
            if (playerPickUp.currentObjectSO.Name == "torch")
            {

                torchQuest.TorchInteract();
            }
        }
        


    }

   


}