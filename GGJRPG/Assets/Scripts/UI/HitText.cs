using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HitText : MonoBehaviour
{
    public float Lifetime;
    public float Height;

    private float m_fRemaining;
    private Image m_CImage;
    private RectTransform m_CTransform;

    private void Start()
    {
        m_fRemaining = Lifetime;
        m_CImage = GetComponent<Image>();
        m_CTransform = GetComponent<RectTransform>();
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
            if (m_CImage != null)
            {
                m_CImage.color = new Color(m_CImage.color.r, m_CImage.color.g, m_CImage.color.b, m_fRemaining / Lifetime);
            }
            if (m_CTransform != null)
            {
                m_CTransform.anchoredPosition = new Vector2(m_CTransform.anchoredPosition.x, (1.0f - m_fRemaining) / Lifetime * Height);
            }
        }
    }
}
