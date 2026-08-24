using UnityEngine;
using UnityEngine.Video;
using Vuforia;
using System.Collections;

public class videonaga : MonoBehaviour
{
    [Header("Vuforia")]
    public ObserverBehaviour observer;  

    [Header("Video Settings")]
    public VideoPlayer dragonVideo;     
    public GameObject videoCanvas;      
    public float videoDuration = 12f;

    [Header("Gameplay")]
    public GameObject gameplayUI;    

    private Coroutine entranceRoutine;
    private bool hasPlayedEntrance = false; 

    void Awake()
    {
        
        if (observer == null)
            observer = GetComponent<ObserverBehaviour>();

       
        if (observer != null)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;

       
        if (videoCanvas != null) videoCanvas.SetActive(false);
        if (gameplayUI != null) gameplayUI.SetActive(false);
        if (dragonVideo != null) dragonVideo.Stop();
    }

    void OnDestroy()
    {
        if (observer != null)
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
    }

    
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        var s = status.Status;

        
        if (s == Status.TRACKED || s == Status.EXTENDED_TRACKED || s == Status.LIMITED)
        {
            OnTargetFound();
        }
        else
        {
            OnTargetLost();
        }
    }

    private void OnTargetFound()
    {
        
        if (hasPlayedEntrance) return;

        hasPlayedEntrance = true;

        if (videoCanvas != null) videoCanvas.SetActive(true);
        if (dragonVideo != null)
        {
            dragonVideo.Play();
        }

        
        if (entranceRoutine != null) StopCoroutine(entranceRoutine);
        entranceRoutine = StartCoroutine(PlayEntranceThenStartGame());
    }

    private void OnTargetLost()
    {

    }

    private IEnumerator PlayEntranceThenStartGame()
    {
        
        yield return new WaitForSeconds(videoDuration);

        if (dragonVideo != null) dragonVideo.Stop();
        if (videoCanvas != null) videoCanvas.SetActive(false);

        if (gameplayUI != null) gameplayUI.SetActive(true);
    }
}
