using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HitText : MonoBehaviour
{
    public float Lifetime;
    public float Height;

    public Color IncreaseColor;
    public Color DecreaseColor;

    public int Value { get; set; }

    private float m_fRemaining;
    private Text m_CText;
    private RectTransform m_CTransform;

    private void Start()
    {
        m_fRemaining = Lifetime;
        m_CText = GetComponent<Text>();
        m_CTransform = GetComponent<RectTransform>();
        if (m_CText != null)
        {
            m_CText.color = (Value > 0) ? IncreaseColor : DecreaseColor;
            m_CText.text = ((Value > 0) ? "+" : "") + Value.ToString();
        }
    }

    private void Update()
    {
        m_fRemaining -= Time.deltaTime;
        if (m_fRemaining <= 0.0f)
        {
            Object.Destroy(gameObject);
        }
        else
        {
            if (m_CText != null)
            {
                m_CText.color = new Color(m_CText.color.r, m_CText.color.g, m_CText.color.b, m_fRemaining / Lifetime);
            }
            if (m_CTransform != null)
            {
                m_CTransform.anchoredPosition = new Vector2(m_CTransform.anchoredPosition.x, (1.0f - m_fRemaining) / Lifetime * Height);
            }
        }
    }
}
