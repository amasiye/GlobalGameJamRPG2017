using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Text HealthText;
    public Image BarBackground;
    public Image BarForeground;
    public HitText HitTextPrefab;
    public RectTransform HitTextParent;
    public int BarMax;
    
    private int m_nHP;

    public void SetHP(int a_nHP, bool a_bShowHitText)
    {
        if (HealthText != null)
        {
            HealthText.text = a_nHP.ToString();
        }
        if ((BarForeground != null) && (BarForeground != null))
        {
            int l_nWidth = (int)((float)BarBackground.rectTransform.rect.width * Mathf.Clamp01((float)a_nHP / (float)BarMax));
            BarForeground.rectTransform.sizeDelta = new Vector2(l_nWidth, 0);
        }
        if (a_bShowHitText && (HitTextParent != null) && (HitTextPrefab != null))
        {
            int l_nDiff = a_nHP - m_nHP;
            if (l_nDiff != 0)
            {
                HitText l_CInstance = Object.Instantiate(HitTextPrefab);
                l_CInstance.transform.parent = HitTextParent;
                l_CInstance.Value = l_nDiff;
            }
        }
        m_nHP = a_nHP;
    }
}
