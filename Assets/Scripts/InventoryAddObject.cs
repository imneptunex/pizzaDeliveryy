using UnityEngine;
using UnityEngine.UI; // Required for Text component (if using UI Text)
using TMPro; // Required for TextMeshPro

public class InventoryAddObject : MonoBehaviour
{
    private StatueRoomInfo statueRoomInfo;
    private int missionCounter = 0;
    [SerializeField] private TextMeshProUGUI missionText; // Assign in Inspector

    [System.Obsolete]
    void Start()
    {
        statueRoomInfo = FindObjectOfType<StatueRoomInfo>();
        UpdateMissionText();
    }

    public void GoldStone()
    {
        missionCounter++;
        statueRoomInfo.EnableDoor();
        UpdateMissionText();

        Debug.Log($"Gold Stone collected! Total: {missionCounter}/2");
    }

    public void RedStone()
    {
        missionCounter++;
        UpdateMissionText();

        Debug.Log($"Red Stone collected! Total: {missionCounter}/2");
    }

    private void UpdateMissionText()
    {
        if (missionText != null)
        {
            missionText.text = $"Find Soul Stones for Charon. {missionCounter}/2";

            // Optional: Change color when complete
            if (missionCounter >= 2)
            {
                missionText.color = Color.green;
            }
        }
    }
}