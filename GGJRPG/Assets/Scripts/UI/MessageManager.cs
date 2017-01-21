using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageManager : MonoBehaviour
{
    public float Lifetime;
    public float FadeTime;

    public Text MessageText;
    public Image BackgroundImage;

    private float m_fRemaining;

    protected static MessageManager m_sInstance = null;

    public static MessageManager Instance
    {
        get
        {
            return m_sInstance;
        }
    }

    private void Awake()
    {
        if (m_sInstance == null)
        {
            m_sInstance = this;
        }
        else
        {
            Debug.LogWarning("An instance of MessageManager already exists");
        }
    }

    public void SetMessage(string a_strMessage)
    {
        if (MessageText != null)
        {
            MessageText.text = a_strMessage;
            MessageText.color = new Color(MessageText.color.r, MessageText.color.g, MessageText.color.b, 1.0f);
        }
        if (BackgroundImage != null)
        {
            BackgroundImage.color = new Color(BackgroundImage.color.r, BackgroundImage.color.g, BackgroundImage.color.b, 1.0f);
        }
        m_fRemaining = Lifetime + FadeTime;
    }

    private void Update()
    {
        m_fRemaining -= Time.deltaTime;
        float l_fAlpha = (m_fRemaining <= 0.0f) ? 0.0f : (m_fRemaining >= FadeTime) ? 1.0f : m_fRemaining / FadeTime;
        if (MessageText != null)
        {
            MessageText.color = new Color(MessageText.color.r, MessageText.color.g, MessageText.color.b, l_fAlpha);
        }
        if (BackgroundImage != null)
        {
            BackgroundImage.color = new Color(BackgroundImage.color.r, BackgroundImage.color.g, BackgroundImage.color.b, l_fAlpha);
        }
    }
}
