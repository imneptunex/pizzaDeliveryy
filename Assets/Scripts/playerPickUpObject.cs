using UnityEngine;

public class playerPickUpObject : MonoBehaviour
{

    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private LayerMask interactLayerMask;

    private objectGrabable objectGrabable;
    private objectInteractable objectInteractable;
    public ObjectSO currentObjectSO;

    private GameObject heldObject;
    public bool grabbing = false;
    private float pickupdistance = 10f;

    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform raycastPoint;

    public bool inDialouge;

    private bool holding = false;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {     
           if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit raycastHit, pickupdistance, pickUpLayerMask))
            {
                    if(objectGrabable == null)
                    {
                        if (raycastHit.transform.TryGetComponent(out objectGrabable))
                        {

                            objectGrabable.Grab(objectGrabPointTransform);
                            grabbing = true;

                            currentObjectSO = raycastHit.transform.GetComponent<objectGrabable>().objectsSO;
                            heldObject = raycastHit.transform.gameObject;
                        holding = true;

                        }

                        if(raycastHit.transform.TryGetComponent(out objectInteractable))
                        {
                        Debug.Log("just interacting");
                        objectInteractable.Interact();
                        }

                    }
                    
                    
            }

        }


        if(Input.GetKeyDown(KeyCode.E) && holding)
        {
            Debug.Log("holding");

            if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit raycastHit, pickupdistance, interactLayerMask))
            {
                if(raycastHit.transform.TryGetComponent(out objectInteractable))
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(objectGrabable != null)
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

    public void ActivateinDialouge()
    {
        inDialouge = true;
    }

   public void DeActivateinDialouge()
    {
        inDialouge = false;
    }




}
