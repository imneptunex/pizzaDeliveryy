using UnityEngine;
using System.Collections;

public class DoorChecker : MonoBehaviour
{
    private charonTalking charonTalking;
    private bool playerInZone = false;
    [SerializeField] private GameObject doorLockedText;

    [System.Obsolete]
    private void Start()
    {
        charonTalking = FindObjectOfType<charonTalking>();
        doorLockedText.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && !charonTalking.missionActive && Input.GetKeyDown(KeyCode.E))
        {
            
            doorLockedText.SetActive(true);
            StartCoroutine(ShowChoiceAfterDelay(0.5f));
        }
    }
    private IEnumerator ShowChoiceAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorLockedText.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("debhug");
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
           
        }
    }

   

}
