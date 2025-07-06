using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public System.Collections.Generic.List<SlotforItem> hotbarSlots; // link each ItemSlot here


    
    public void AddItem(Sprite itemIcon)
    {
        foreach (SlotforItem slot in hotbarSlots)
        {
            if (slot.icon.sprite == null)
            {
                
                slot.icon.sprite = itemIcon;
                break;
            }
        }
    }


}
