using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blinker : MonoBehaviour
{
    public float blinkRate = 1f;
    public float nextTime = 0f;

    public bool blink = false;

    [SerializeField]
    private Text text;

    void Start()
    {
        if(!text)
            text = GetComponent<Text>();

        nextTime = Time.time + blinkRate;
    }

    void Update()
    {
        if(blink)
        {
            Blink();
        }
    } // end Update()

    public void StartBlink()
    {
        blink = true;
    } // end StartBlink()

    void Blink()
    {
        if(Time.time > nextTime)
        {
            text.enabled = !text.enabled;
            nextTime = Time.time + blinkRate;
        }
    } // end Blink()

    public void Halt()
    {
        text.enabled = true;
        blink = false;
    } // end Halt()
}
