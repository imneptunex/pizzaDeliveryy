using UnityEngine;

public class charonTalking : MonoBehaviour
{
    private bool playerInZone = false;

    [SerializeField] private GameObject firstDialogue;

    //[SerializeField] private GameObject secondDialogue;

    //[SerializeField] private GameObject thirdDialogue;

    private playerPickUpObject playerPickUpObject;

    public bool firstDialoguePlayed;


    [System.Obsolete]
    void Start()
    {
        playerPickUpObject = FindObjectOfType<playerPickUpObject>();

        firstDialoguePlayed = false;
        firstDialogue.SetActive(false);
        //secondDialogue.SetActive(false);
        //thirdDialogue.SetActive(false);
        playerPickUpObject.DeActivateinDialouge();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;

        }
    }


    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Talk();
            Debug.Log("pressed E");
        }
    }

   

    void Talk()
    {
        firstDialogue.SetActive(true);
        firstDialoguePlayed = true;
        playerPickUpObject.ActivateinDialouge();

    }




    // charon: Ahh, a new one. Who are you
    // player: I am here to deliver a pizza to Hades
    // charon: mmh smells delicious, mind if a grab a piece?
    // player: CHOIDE: GIVE A SLICE - DONT GIVE
    // Charon: Whatever, no drahma no pass.
    // player: a what?
    // Charon: Agh, i am sick of this why no one has their drahmas lately. I will create one for you, i need 2 soul stones. Dont be late!
    // Player: CHOICE: Soul stones? What is this a joke? - OK.
    // Charon: If CHOICED 1ST ONE: Just find some glowy stones man, believe me you will understand when you see them.
}
