using UnityEngine;

public class GuardianTalking : MonoBehaviour
{

    

    private bool playerInZone = false;
    public AudioSource firstAudioSource;

    public AudioSource secondAudioSource;

    public bool firstDialoguePlayed;

    [SerializeField] private GameObject firstDialogue;

    [SerializeField] private GameObject secondDialogue;

    [SerializeField] private GameObject thirdDialogue;

    private playerPickUpObject playerPickUpObject;

    public GameObject door1;
    public GameObject door2;
    public float doorRotationSpeed = 2f;

    public bool openDoors = false;

    private Quaternion door1TargetRotation;
    private Quaternion door2TargetRotation;

    [System.Obsolete]
    void Start()
    {
        playerPickUpObject = FindObjectOfType<playerPickUpObject>();

        firstDialoguePlayed = false;
         firstDialogue.SetActive(false);
        secondDialogue.SetActive(false);
        thirdDialogue.SetActive(false);
        playerPickUpObject.DeActivateinDialouge();
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

    void Update()
    {
        if (openDoors)
        {
           
            door1.transform.rotation = Quaternion.RotateTowards(
                door1.transform.rotation,
                door1TargetRotation,
                doorRotationSpeed * Time.deltaTime * 100f // speed multiplier
            );

            door2.transform.rotation = Quaternion.RotateTowards(
                door2.transform.rotation,
                door2TargetRotation,
                doorRotationSpeed * Time.deltaTime * 100f
            );



        }

        if (playerInZone && Input.GetKeyDown(KeyCode.E) && !firstAudioSource.isPlaying && firstDialoguePlayed == false)
        {
            Talk();

        }
    }

    void Talk()
    {
        firstDialogue.SetActive(true);
        firstDialoguePlayed = true;
        playerPickUpObject.ActivateinDialouge();

        if (firstAudioSource != null)
        {
            firstAudioSource.Play();
        }
    }

    public void Firstclick()
    {
        Debug.Log("click");
        secondDialogue.SetActive(true);
        firstDialogue.SetActive(false);

        if (firstAudioSource.isPlaying)
        {
            firstAudioSource.Stop();
        }


    }

    public void Secondclick()
    {
        thirdDialogue.SetActive(true);
        secondDialogue.SetActive(false);

        secondAudioSource.Play();

    }



   public void Thirdclick()
    {
        if (secondAudioSource.isPlaying)
        {
            secondAudioSource.Stop();
        }


        thirdDialogue.SetActive(false);

        MeshCollider meshcolliderdoor2 = door2.GetComponent<MeshCollider>();

        // Set door colliders to trigger
        MeshCollider meshcolliderdoor1 = door1.GetComponent<MeshCollider>();
        meshcolliderdoor1.isTrigger = true;
        meshcolliderdoor2.isTrigger = true;

        // Set target rotations
        door1TargetRotation = Quaternion.Euler(0, -58, 0);
        door2TargetRotation = Quaternion.Euler(0, 70, 0);
        openDoors = true;

        playerPickUpObject.DeActivateinDialouge();


    }



}