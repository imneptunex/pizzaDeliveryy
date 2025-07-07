using UnityEngine;

public class InventoryAddObject : MonoBehaviour
{

    private StatueRoomInfo statueRoomInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        statueRoomInfo = FindObjectOfType<StatueRoomInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoldStone()
    {
        statueRoomInfo.EnableDoor();
    }

    public void RedStone()
    {

    }
}
