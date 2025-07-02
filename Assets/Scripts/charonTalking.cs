using System.Collections;
using UnityEngine;

public class charonTalking : MonoBehaviour
{
    private bool playerInZone = false;

    [SerializeField] private GameObject firstDialogue;

    [SerializeField] private GameObject playerFirstChoice;
    [SerializeField] private GameObject playerPizzaChoice;

    [SerializeField] private GameObject playerChoiceA;

    [SerializeField] private GameObject playerChoiceB;

    [SerializeField] private GameObject playerChoiceC;

    [SerializeField] private GameObject askPizzaCharon;

    [SerializeField] private GameObject pizzaChoice1;
    [SerializeField] private GameObject pizzaChoice2;

    private playerPickUpObject playerPickUpObject;

    public bool firstDialoguePlayed;


    [System.Obsolete]
    void Start()
    {
        playerPickUpObject = FindObjectOfType<playerPickUpObject>();

        firstDialoguePlayed = false;
        firstDialogue.SetActive(false);
        playerFirstChoice.SetActive(false);
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

   

    public void Talk()
    {
        firstDialogue.SetActive(true);
        firstDialoguePlayed = true;
        playerPickUpObject.ActivateinDialouge();


        StartCoroutine(ShowChoiceAfterDelay(1.5f)); // 1-second delay

    }

    private IEnumerator ShowChoiceAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerFirstChoice.SetActive(true);
    }

    public void FirstChoice()
    {
        playerChoiceA.SetActive(true);
        Debug.Log("first");
        firstDialogue.SetActive(false);
        playerFirstChoice.SetActive(false);
    }

    public void SecondChoice()
    {
        playerChoiceB.SetActive(true);
        Debug.Log("second");
        firstDialogue.SetActive(false);
        playerFirstChoice.SetActive(false);
    }

    public void ThirdChoice()
    {
        playerChoiceC.SetActive(true);
        Debug.Log("third");
        firstDialogue.SetActive(false);
        playerFirstChoice.SetActive(false);
    }

    public void AskForPizza()
    {
        playerChoiceA.SetActive(false);
        playerChoiceB.SetActive(false);
        playerChoiceC.SetActive(false);

        askPizzaCharon.SetActive(true);

        StartCoroutine(ShowAfterDelay(0.5f)); // 1-second delay

    }

    private IEnumerator ShowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerPizzaChoice.SetActive(true);
    }

    public void pizzaChoiceA()
    {
        playerPizzaChoice.SetActive(false);
        askPizzaCharon.SetActive(false);
        pizzaChoice1.SetActive(true);
    }

    public void pizzaChoiceB()
    {
        playerPizzaChoice.SetActive(false);
        askPizzaCharon.SetActive(false);
        pizzaChoice2.SetActive(true);

    }

}
