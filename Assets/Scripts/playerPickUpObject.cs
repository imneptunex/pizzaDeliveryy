using UnityEngine;

public class playerPickUpObject : MonoBehaviour
{

    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private LayerMask headerLayerMask;
    [SerializeField] private GameObject interactionHeader;
    [SerializeField] private GameObject selectionHeader;

    [SerializeField] private GameObject weaponWheel;
    [SerializeField] private GameObject statBar;

    private objectGrabable objectGrabable;
    private objectInteractable objectInteractable;
    private StatueTrigger statueTrigger;
    public ObjectSO currentObjectSO;

    private GameObject heldObject;
    public bool grabbing = false;
    private float pickupdistance = 10f;

    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform raycastPoint;

    public bool inDialouge;

    private bool holding = false;

    private charonTalking charonTalking;

    [System.Obsolete]
    private void Start()
    {
        charonTalking = FindObjectOfType<charonTalking>();
    }


    void Update()
    {
        CheckGrabable();

        CheckInteractwhileGrab();

        DropObject();

        CheckGrabHeader();

        if (inDialouge)
        {
            interactionHeader.SetActive(false);
        }

    }

    public void ActivateinDialouge()
    {
        weaponWheel.SetActive(false);
        statBar.SetActive(false);
        inDialouge = true;
    }

    public void DeActivateinDialouge()
    {
        weaponWheel.SetActive(true);
        statBar.SetActive(true);
        inDialouge = false;
    }

    private void CheckGrabable()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit raycastHitt, pickupdistance, pickUpLayerMask))
            {

                Debug.Log("pressed");
                if (raycastHitt.transform.TryGetComponent(out objectGrabable))
                {

                    objectGrabable.Grab(objectGrabPointTransform);
                    grabbing = true;

                    currentObjectSO = raycastHitt.transform.GetComponent<objectGrabable>().objectsSO;
                    heldObject = raycastHitt.transform.gameObject;
                    holding = true;

                }

                if (raycastHitt.transform.TryGetComponent(out objectInteractable))
                {
                    if(charonTalking.missionActive)
                    {
                        if (raycastHitt.transform.CompareTag("FirstMissionRightDoor"))
                        {
                            raycastHitt.transform.rotation = Quaternion.Euler(0f, 162f, 0f);
                            raycastHitt.transform.gameObject.layer = LayerMask.NameToLayer("Default");
                            raycastHitt.transform.tag = "Untagged";

                        }
                        else if (raycastHitt.transform.CompareTag("FirstMissionLeftDoor"))
                        {
                            raycastHitt.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            raycastHitt.transform.gameObject.layer = LayerMask.NameToLayer("Default");
                            raycastHitt.transform.tag = "Untagged";

                        }
                    }
                    

                    objectInteractable.Interact();
                }

            }

        }
    }



    private void CheckGrabHeader()
    {
        
        if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit raycastHit, pickupdistance, headerLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out objectInteractable))
            {
                interactionHeader.SetActive(true);

                //check

            }
            if(raycastHit.transform.TryGetComponent(out statueTrigger))
            {
                //Debug.Log("log");
                //interactionHeader.SetActive(true);
                selectionHeader.SetActive(true);
            }


        }
        else
        {
            interactionHeader.SetActive(false);
            selectionHeader.SetActive(false);
        }



       

    }

    private void CheckInteractwhileGrab()
    {
        if (Input.GetKeyDown(KeyCode.E) && holding)
        {
            

            if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit raycastHi, pickupdistance, interactLayerMask))
            {
                if (raycastHi.transform.TryGetComponent(out objectInteractable))
                {
                    Debug.Log("holding and interacting");
                    objectInteractable.Interact();

                    objectGrabable.Drop();
                    objectGrabable = null;
                    grabbing = false;

                    heldObject = null;
                    currentObjectSO = null;
                    holding = false;
                }
            }

        }

    }

    private void DropObject()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (objectGrabable != null)
            {
                objectGrabable.Drop();
                objectGrabable = null;
                grabbing = false;

                // Clear held object data
                heldObject = null;
                currentObjectSO = null;
                holding = false;
            }

        }

    }
}