using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class charonTalking : MonoBehaviour
{
    [Header("Dialogue UI References")]
    [SerializeField] private GameObject firstDialogue;
    [SerializeField] private GameObject playerFirstChoice;
    [SerializeField] private GameObject playerPizzaChoice;
    [SerializeField] private GameObject playerChoiceA;
    [SerializeField] private GameObject playerChoiceB;
    [SerializeField] private GameObject playerChoiceC;
    [SerializeField] private GameObject askPizzaCharon;
    [SerializeField] private GameObject pizzaChoice1;
    [SerializeField] private GameObject pizzaChoice2;
    [SerializeField] private GameObject playerDrahma;
    [SerializeField] private GameObject charonSoul1;
    [SerializeField] private GameObject charonSoul2;
    [SerializeField] private GameObject playerDrahmaChoice;
    [SerializeField] private GameObject charonDrahmaA;
    [SerializeField] private GameObject charonDrahmaB;
    [SerializeField] private GameObject charonDrahmaC;
    [SerializeField] private GameObject charonDrahmaD;
    [SerializeField] private GameObject SoulStoneMission;

    [Header("Voice Configuration")]
    [SerializeField] private AudioSource charonAudioSource;
    [SerializeField] private AudioClip talkClip;
    [SerializeField] private AudioClip firstChoiceClip;
    [SerializeField] private AudioClip secondChoiceClip;
    [SerializeField] private AudioClip thirdChoiceClip;
    [SerializeField] private AudioClip askPizzaClip;
    [SerializeField] private AudioClip pizzaChoiceAClip;
    [SerializeField] private AudioClip pizzaChoiceBClip;
   
    [SerializeField] private AudioClip soul1Clip;
    [SerializeField] private AudioClip soul2Clip;
    [SerializeField] private AudioClip soulOptAClip;
    [SerializeField] private AudioClip soulOptBClip;
    [SerializeField] private AudioClip soulOptCClip;
    [SerializeField] private AudioClip soulOptDClip;
    

    private bool playerInZone = false;
    public bool missionActive = false;
    public bool firstDialoguePlayed = false;
    private playerPickUpObject playerPickUpObject;

    [System.Obsolete]
    void Start()
    {
        InitializeComponents();
        ResetAllUI();
    }

    [System.Obsolete]
    void InitializeComponents()
    {
        playerPickUpObject = FindObjectOfType<playerPickUpObject>();

        if (charonAudioSource == null)
        {
            charonAudioSource = gameObject.AddComponent<AudioSource>();
            charonAudioSource.spatialBlend = 0f; // 2D sound
        }
    }

    void ResetAllUI()
    {
        firstDialogue.SetActive(false);
        playerFirstChoice.SetActive(false);
        playerChoiceA.SetActive(false);
        playerChoiceB.SetActive(false);
        playerChoiceC.SetActive(false);
        askPizzaCharon.SetActive(false);
        playerPizzaChoice.SetActive(false);
        pizzaChoice1.SetActive(false);
        pizzaChoice2.SetActive(false);
        playerDrahma.SetActive(false);
        charonSoul1.SetActive(false);
        charonSoul2.SetActive(false);
        playerDrahmaChoice.SetActive(false);
        charonDrahmaA.SetActive(false);
        charonDrahmaB.SetActive(false);
        charonDrahmaC.SetActive(false);
        charonDrahmaD.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            ForceStopDialogue();
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E) && !charonAudioSource.isPlaying)
        {
            Talk();
        }
    }

    private void ForceStopDialogue()
    {
        charonAudioSource.Stop();
        ResetAllUI();
        playerPickUpObject.DeActivateinDialouge();
    }

    public void Talk()
    {
        charonAudioSource.Stop();
        firstDialogue.SetActive(true);
        playerPickUpObject.ActivateinDialouge();
        PlayVoice(talkClip);
        StartCoroutine(ShowChoiceAfterDelay(0.5f));
    }

    private IEnumerator ShowChoiceAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerFirstChoice.SetActive(true);
    }

    public void FirstChoice()
    {
        charonAudioSource.Stop();
        playerChoiceA.SetActive(true);
        firstDialogue.SetActive(false);
        playerFirstChoice.SetActive(false);
        PlayVoice(firstChoiceClip);
    }

    public void SecondChoice()
    {
        charonAudioSource.Stop();
        playerChoiceB.SetActive(true);
        firstDialogue.SetActive(false);
        playerFirstChoice.SetActive(false);
        PlayVoice(secondChoiceClip);
    }

    public void ThirdChoice()
    {
        charonAudioSource.Stop();
        playerChoiceC.SetActive(true);
        firstDialogue.SetActive(false);
        playerFirstChoice.SetActive(false);
        PlayVoice(thirdChoiceClip);
    }

    public void AskForPizza()
    {
        charonAudioSource.Stop();
        playerChoiceA.SetActive(false);
        playerChoiceB.SetActive(false);
        playerChoiceC.SetActive(false);
        askPizzaCharon.SetActive(true);
        PlayVoice(askPizzaClip);
        StartCoroutine(ShowAfterDelay(0.5f));
    }

    private IEnumerator ShowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerPizzaChoice.SetActive(true);
    }

    public void pizzaChoiceA()
    {
        charonAudioSource.Stop();
        playerPizzaChoice.SetActive(false);
        askPizzaCharon.SetActive(false);
        pizzaChoice1.SetActive(true);
        PlayVoice(pizzaChoiceAClip);
    }

    public void pizzaChoiceB()
    {
        charonAudioSource.Stop();
        playerPizzaChoice.SetActive(false);
        askPizzaCharon.SetActive(false);
        pizzaChoice2.SetActive(true);
        PlayVoice(pizzaChoiceBClip);
    }

    public void playerDrahmaText()
    {
        charonAudioSource.Stop();
        pizzaChoice1.SetActive(false);
        pizzaChoice2.SetActive(false);
        playerDrahma.SetActive(true);
        
    }

    public void CharonSoul1()
    {
        charonAudioSource.Stop();
        playerDrahma.SetActive(false);
        charonSoul1.SetActive(true);
        PlayVoice(soul1Clip);
    }

    public void CharonSoul2()
    {
        charonAudioSource.Stop();
        charonSoul1.SetActive(false);
        charonSoul2.SetActive(true);
        PlayVoice(soul2Clip);
        StartCoroutine(ShowAfterTheDelay(0.5f));
    }

    private IEnumerator ShowAfterTheDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerDrahmaChoice.SetActive(true);
    }

    public void CharonSoulOptA()
    {
        charonAudioSource.Stop();
        charonSoul2.SetActive(false);
        playerDrahmaChoice.SetActive(false);
        charonDrahmaA.SetActive(true);
        PlayVoice(soulOptAClip);
    }

    public void CharonSoulOptB()
    {
        charonAudioSource.Stop();
        charonSoul2.SetActive(false);
        playerDrahmaChoice.SetActive(false);
        charonDrahmaB.SetActive(true);
        PlayVoice(soulOptBClip);
    }

    public void CharonSoulOptC()
    {
        charonAudioSource.Stop();
        charonSoul2.SetActive(false);
        playerDrahmaChoice.SetActive(false);
        charonDrahmaC.SetActive(true);
        PlayVoice(soulOptCClip);
    }

    public void CharonSoulOptD()
    {
        charonAudioSource.Stop();
        charonSoul2.SetActive(false);
        playerDrahmaChoice.SetActive(false);
        charonDrahmaD.SetActive(true);
        PlayVoice(soulOptDClip);
    }

    public void ExitDialougeCharon()
    {
        charonAudioSource.Stop();
        charonDrahmaA.SetActive(false);
        charonDrahmaB.SetActive(false);
        charonDrahmaC.SetActive(false);
        charonDrahmaD.SetActive(false);
        
        playerPickUpObject.DeActivateinDialouge();
        SoulStoneMission.SetActive(true);
        missionActive = true;

        ResetAllUI();
    }

    private void PlayVoice(AudioClip clip)
    {
        if (clip == null) return;
        charonAudioSource.clip = clip;
        charonAudioSource.Play();
    }
}