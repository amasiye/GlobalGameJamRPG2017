using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BindIcon : MonoBehaviour
{
    public Character.Element ElementType;
    public Text LabelText;
    public Image ElementIcon;

    public Color Default;
    public Color Selected;
    public Color Highlighted;
    public Color HighlightedSelected;

    private bool m_bHighlighted;
    private bool m_bSelected;

    public void SetHighlighted(bool a_bHighlighted)
    {
        m_bHighlighted = a_bHighlighted;
        UpdateStyle();                
    }

    public void SetSelected(bool a_bSelected)
    {
        m_bSelected = a_bSelected;
        UpdateStyle();
    }

    public bool GetSelected()
    {
        return m_bSelected;
    }

    private void UpdateStyle()
    {
        if (LabelText != null)
        {
            LabelText.fontStyle = (m_bHighlighted) ? FontStyle.Bold : FontStyle.Normal;
        }
        if (ElementIcon != null)
        {
            ElementIcon.color = (m_bHighlighted && m_bSelected) ? HighlightedSelected
                : (m_bHighlighted) ? Highlighted : (m_bSelected) ? Selected : Default;
        }
    }
}
