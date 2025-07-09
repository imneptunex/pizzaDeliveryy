using UnityEngine;
using System.Collections; // Required for coroutines

public class StatueRoomInfo : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private AudioClip[] voiceLines; // Assign 3 audio clips in Inspector
    [SerializeField] private GameObject[] subtitleObjects; // Assign 3 subtitle GameObjects in Inspector
    [SerializeField] private float delayBetweenLines = 2f; // Adjust as needed

    private AudioSource audioSource;
    private bool hasTriggered = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            Debug.Log("Triggered voice lines");

            // Open doors (your existing code)
            door1.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            door2.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            door1.transform.tag = "Untagged";
            door2.transform.tag = "Untagged";
            door1.layer = LayerMask.NameToLayer("Default");
            door2.layer = LayerMask.NameToLayer("Default");

            StartCoroutine(PlayVoiceLinesSequentially());
        }
    }

    IEnumerator PlayVoiceLinesSequentially()
    {
        for (int i = 0; i < voiceLines.Length; i++)
        {
            // Enable current subtitle
            subtitleObjects[i].SetActive(true);

            // Play voice line
            audioSource.PlayOneShot(voiceLines[i]);

            // Wait for clip length + optional delay
            yield return new WaitForSeconds(voiceLines[i].length + delayBetweenLines);

            // Disable current subtitle
            subtitleObjects[i].SetActive(false);
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


