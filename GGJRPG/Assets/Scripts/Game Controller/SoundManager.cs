using UnityEngine;
using System.Collections;

[AddComponentMenu("Game Controller/Sound Manager")]
public class SoundManager : MonoBehaviour
{
    public AudioClip bgmBattle;
    public AudioClip bgmVictory;
    public AudioClip fxSlash;
    public AudioClip fxSpell;

    [SerializeField]
    private AudioSource source;

    void Awake()
    {
        if(!source)
            source = GetComponent<AudioSource>();

        if(bgmBattle)
        {
            source.clip = bgmBattle;
            source.Play();
        }
    }
    
    void Update()
    {

    } // end Update()
}
