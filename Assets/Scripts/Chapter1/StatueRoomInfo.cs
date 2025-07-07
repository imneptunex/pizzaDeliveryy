using UnityEngine;

public class StatueRoomInfo : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    private bool hasTriggered = false; // New flag to track if we've triggered

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
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

    public void EnableDoor()
    {
        Debug.Log("Works");
        door1.transform.tag = "FirstMissionRightDoor";
        door2.transform.tag = "FirstMissionLeftDoor";

        door1.transform.gameObject.layer = LayerMask.NameToLayer("Grabable");
        door2.transform.gameObject.layer = LayerMask.NameToLayer("Grabable");
    }
}