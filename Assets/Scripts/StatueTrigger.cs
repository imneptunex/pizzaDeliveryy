using UnityEngine;

public class StatueTrigger : MonoBehaviour
{

    private bool playerInZone = false;

    [SerializeField] private GameObject royalStatue;
    [SerializeField] private GameObject manStatue;
    [SerializeField] private GameObject shoulderwomenStatue;
    [SerializeField] private GameObject womenStatue;

    private playerPickUpObject playerPickUpObject;

    private void Start()
    {
        playerPickUpObject = GameObject.Find("Player").GetComponent<playerPickUpObject>();
    }
    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Talk();

        }

    }

    void OnTriggerEnter(Collider other)
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

    void Talk()
    {
        if (this.CompareTag("royal"))
        {
            royalStatue.SetActive(true);
            playerPickUpObject.ActivateinDialouge();

        }
        else if (this.CompareTag("man"))
        {
            manStatue.SetActive(true);
            playerPickUpObject.ActivateinDialouge();

        }
        else if (this.CompareTag("women"))
        {
            womenStatue.SetActive(true);
            playerPickUpObject.ActivateinDialouge();

        }
        else if (this.CompareTag("carryWomen"))
        {
            shoulderwomenStatue.SetActive(true);
            playerPickUpObject.ActivateinDialouge();

        }
    }

    public void CloseTalk()
    {
        royalStatue.SetActive(false);
        manStatue.SetActive(false);
        womenStatue.SetActive(false);
        shoulderwomenStatue.SetActive(false);

        playerPickUpObject.DeActivateinDialouge();
    }
}
