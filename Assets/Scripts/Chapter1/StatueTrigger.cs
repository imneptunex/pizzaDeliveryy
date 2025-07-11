using UnityEngine;

public class StatueTrigger : MonoBehaviour
{

    private bool playerInZone = false;

    [SerializeField] private GameObject royalStatue;
    [SerializeField] private GameObject manStatue;
    [SerializeField] private GameObject shoulderwomenStatue;
    [SerializeField] private GameObject womenStatue;

    [SerializeField] private GameObject SoulStone;

    [SerializeField] private GameObject offFX;
    [SerializeField] private GameObject onFX;


    [SerializeField] private AudioSource statueAudioSource;
    [SerializeField] private AudioClip royalClip;
    [SerializeField] private AudioClip manClip;
    [SerializeField] private AudioClip womenClip;
    [SerializeField] private AudioClip carryClip;

    private playerPickUpObject playerPickUpObject;

    private void Start()
    {
        playerPickUpObject = GameObject.Find("Player").GetComponent<playerPickUpObject>();
        offFX.SetActive(true);
        SoulStone.SetActive(false);
    }
    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Talk();

        }

        if (playerInZone && Input.GetKeyDown(KeyCode.F))
        {
            SelectStatue();

        }

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

    void Talk()
    {
        if (this.CompareTag("royal"))
        {
            PlayVoice(royalClip);
            royalStatue.SetActive(true);
            playerPickUpObject.ActivateinDialouge();

        }
        else if (this.CompareTag("man"))
        {
            PlayVoice(manClip);
            manStatue.SetActive(true);
            playerPickUpObject.ActivateinDialouge();

        }
        else if (this.CompareTag("women"))
        {
            PlayVoice(womenClip);
            womenStatue.SetActive(true);
            playerPickUpObject.ActivateinDialouge();

        }
        else if (this.CompareTag("carryWomen"))
        {
            PlayVoice(carryClip);
            shoulderwomenStatue.SetActive(true);
            playerPickUpObject.ActivateinDialouge();

        }
    }

    public void CloseTalk()
    {
        royalStatue.SetActive(false);
        manStatue.SetActive(false);
        womenStatue.SetActive(false);
        shoulderwomenStatue.SetActive(false);

        playerPickUpObject.DeActivateinDialouge();
    }

    void SelectStatue()
    {
        
         if (this.CompareTag("man"))
        {
            Debug.Log("correct");
            SoulStone.SetActive(true);
            offFX.SetActive(false);
            onFX.SetActive(true);

            

        }
         else
        {
            Debug.Log("select again");
        }
       
        
    }


    private void PlayVoice(AudioClip clip)
    {
        if (clip == null) return;
        statueAudioSource.clip = clip;
        statueAudioSource.Play();
    }


}
