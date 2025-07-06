using UnityEngine;

public class playerTriggerBattle : MonoBehaviour
{
    [SerializeField] GameObject[] skeletons;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartSkeletonAnim();

        }
    }

    void StartSkeletonAnim()
    {

        foreach(GameObject skeleton in skeletons)
        {
            skeleton.SetActive(true);
        }

        
    }
}
