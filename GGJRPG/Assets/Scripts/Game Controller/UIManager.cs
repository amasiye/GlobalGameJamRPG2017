using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Game Controller/UI Manager")]

[System.Serializable]
public struct ElementUI
{
    public Text ValueText;
    public Image BackgroundImage;
    public Image ForegroundImage;
    public int BarMax;

    public void UpdateUI(int a_nValue)
    {
        if (ValueText != null)
        {
            ValueText.text = a_nValue.ToString();
        }
        if ((BackgroundImage != null) && (ForegroundImage != null))
        {
            int l_nHeight = (int)((float)BackgroundImage.rectTransform.rect.height * Mathf.Clamp01((float)a_nValue / (float)BarMax));
            ForegroundImage.rectTransform.sizeDelta = new Vector2(0, l_nHeight);
        }
    }
}

public class UIManager : MonoBehaviour
{
    public ElementUI FireUI;
    public ElementUI IceUI;
    public ElementUI LightningUI;
    public ElementUI EarthUI;

    public Canvas results;
    public Text winText;
    public Text loseText;

    [SerializeField]
    private GameManager gm;

    void Awake()
    {
        if(!gm)
            gm = gameObject.GetComponent<GameManager>();

        if(winText)
            winText.enabled = false;

        if(loseText)
            loseText.enabled = false;

        if(results)
            results.enabled = false;
    }

    void OnGUI()
    {
        FireUI.UpdateUI(gm.Fire);
        IceUI.UpdateUI(gm.Ice);
        LightningUI.UpdateUI(gm.Lightning);
        EarthUI.UpdateUI(gm.Earth);
    }

    public void ShowResults(bool win = false)
    {
        if(results)
            results.enabled = true;

        if(win)
            winText.enabled = true;
        else
            loseText.enabled = true;
    } // end ShowResults()
}
