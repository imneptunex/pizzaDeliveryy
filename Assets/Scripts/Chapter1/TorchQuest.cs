using UnityEngine;

public class TorchQuest : MonoBehaviour
{
    public GameObject torch;
    public GameObject torchPlacer;


    public GameObject door1;
    public GameObject door2;
    public float doorRotationSpeed = 2f;

    public bool openDoors = false;
    private Quaternion door1TargetRotation;
    private Quaternion door2TargetRotation;


    private playerPickUpObject playerPickUp;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoors)
        {
            objectGrabable grabable = torch.GetComponent<objectGrabable>();
            objectInteractable interactable = torchPlacer.GetComponent<objectInteractable>();


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
    }



    public void TorchInteract()
    {
        
            Rigidbody rb = torch.GetComponent<Rigidbody>();


            MeshCollider meshcolliderdoor2 = door2.GetComponent<MeshCollider>();
        Debug.Log("torch");
            torch.transform.position = new Vector3((float)-4.19500017, (float)3.46199989, (float)-10.1359997);
        // DISABLE RB
        rb.isKinematic = true;


        // Set door colliders to trigger
        MeshCollider meshcolliderdoor1 = door1.GetComponent<MeshCollider>();
            meshcolliderdoor1.isTrigger = true;
            meshcolliderdoor2.isTrigger = true;

            // Set target rotations
            door1TargetRotation = Quaternion.Euler(-50, 90, -90);
            door2TargetRotation = Quaternion.Euler(-50, 270, 90);
            openDoors = true;
        }



    
}


