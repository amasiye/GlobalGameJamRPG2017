using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleManager : MonoBehaviour
{
    public AudioClip mainTheme;
    public AudioClip sfxAccept;

    public AudioSource bgmChannel;
    public AudioSource sfxChannel;

    public float fadeTime = 0.1f;
    private float nextTime = 0f;
    public Image bgBlackImage;
    public Color startColor;
    public Color endColor;

    public float loadingTime = 2.0f;

    public enum SceneState { Init, Prompt, Loading }
    public SceneState titleSceneState = SceneState.Init;

    [SerializeField]
    private Blinker promptBlinker;

    void Start()
    {
        titleSceneState = SceneState.Init;
        nextTime = Time.time + fadeTime;
    }

    void Update()
    {
        switch(titleSceneState)
        {
            case SceneState.Init:
                bgBlackImage.color = Color.Lerp(startColor, endColor, Time.time);
                if(Time.time > nextTime)
                    titleSceneState = SceneState.Prompt;
                break;
            case SceneState.Prompt:
                WaitForInput();
                break;
            case SceneState.Loading:
                break;
        } 
    } // end Update()

    void Init()
    {

    }

    void WaitForInput()
    {
        if(!promptBlinker.blink)
        {
            promptBlinker.StartBlink();
        }

        if(Input.GetButtonDown(ButtonManager.xboxStart))
        {
            if(sfxAccept && sfxChannel)
            {
                sfxChannel.clip = sfxAccept;
                sfxChannel.Play();
            }
            if(promptBlinker.blink)
            {
                promptBlinker.Halt();
                LoadGame();
            }
        }
    } // end WaitForInput()

    void LoadGame()
    {
        titleSceneState = SceneState.Loading;
        StartCoroutine(StartGame());
    } // end LoadGame()

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene(1);
    } // end StartGame()
    
}
