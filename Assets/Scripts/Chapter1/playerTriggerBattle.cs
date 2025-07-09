using UnityEngine;

public class playerTriggerBattle : MonoBehaviour
{
    [SerializeField] GameObject[] skeletons;

    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    private bool hasTriggered = false; // New flag to track if we've triggered


    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            StartSkeletonAnim();

            hasTriggered = true; // Set flag so this won't run again
            Debug.Log("entered");

            door1.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            door2.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

            door1.transform.tag = "Untagged";
            door2.transform.tag = "Untagged";
            door1.transform.gameObject.layer = LayerMask.NameToLayer("Default");
            door2.transform.gameObject.layer = LayerMask.NameToLayer("Default");


        }
    }

    void StartSkeletonAnim()
    {

        foreach(GameObject skeleton in skeletons)
        {
            skeleton.SetActive(true);
        }

        
    }

    public void EnableDoor()
    {
        Debug.Log("Works");
        door1.transform.tag = "FirstMissionRightDoor";
        door2.transform.tag = "FirstMissionLeftDoor";

        door1.transform.gameObject.layer = LayerMask.NameToLayer("Grabable");
        door2.transform.gameObject.layer = LayerMask.NameToLayer("Grabable");
    }
}
