using UnityEngine;

public class StatueRoomInfo : MonoBehaviour
{
    
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            door1.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            door2.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

            door1.transform.tag = "Untagged";
            door2.transform.tag = "Untagged";
            door1.transform.gameObject.layer = LayerMask.NameToLayer("Default");
            door2.transform.gameObject.layer = LayerMask.NameToLayer("Default");


        }
    }

    
}
