using UnityEngine;
using System.Collections;

[System.Serializable]
public struct BindPanelColumn
{
    public BindIcon[] Icons;
}

public class BindPanel : MonoBehaviour
{
    public BindPanelColumn[] Columns;
    public GameObject Root;

    private int m_nColumnIndex;
    private int m_nRowIndex;

    private float m_fLastXAxis;
    private float m_fLastYAxis;

    private bool m_bActive;

    private void Start()
    {
        m_bActive = true;
        for (int i = 0; i < Columns.Length; i++)
        {
            for (int j = 0; j < Columns[i].Icons.Length; j++)
            {
                Columns[i].Icons[j].SetSelected(false);
                Columns[i].Icons[j].SetHighlighted(false);
            }
            Columns[i].Icons[0].SetSelected(true);
        }
        Columns[0].Icons[0].SetHighlighted(true);
    }

    private void Update()
    {
        if (!m_bActive)
        {
            return;
        }
        float l_fXAxis = Input.GetAxis("Horizontal");
        float l_fYAxis = Input.GetAxis("Vertical");
        if ((l_fXAxis > 0.0f) && (m_fLastXAxis <= 0.0f) && (m_nColumnIndex < Columns.Length - 1))
        {
            Columns[m_nColumnIndex].Icons[m_nRowIndex].SetHighlighted(false);
            m_nColumnIndex++;
        }
        else if ((l_fXAxis < 0.0f) && (m_fLastXAxis >= 0.0f) && (m_nColumnIndex > 0))
        {
            Columns[m_nColumnIndex].Icons[m_nRowIndex].SetHighlighted(false);
            m_nColumnIndex--;
        }
        else if ((l_fYAxis > 0.0f) && (m_fLastYAxis <= 0.0f) && (m_nRowIndex > 0))
        {
            Columns[m_nColumnIndex].Icons[m_nRowIndex].SetHighlighted(false);
            m_nRowIndex--;
        }
        else if ((l_fYAxis < 0.0f) && (m_fLastYAxis >= 0.0f) && (m_nRowIndex < Columns[m_nColumnIndex].Icons.Length - 1))
        {
            Columns[m_nColumnIndex].Icons[m_nRowIndex].SetHighlighted(false);
            m_nRowIndex++;
        }
        else if (Input.GetButtonDown(ButtonManager.xboxA))
        {
            for (int i = 0; i < Columns[m_nColumnIndex].Icons.Length; i++)
            {
                Columns[m_nColumnIndex].Icons[i].SetSelected(false);
            }
            Columns[m_nColumnIndex].Icons[m_nRowIndex].SetSelected(true);
        }
        else if (Input.GetButtonDown(ButtonManager.xboxStart))
        {
            Confirm();
        }
        Columns[m_nColumnIndex].Icons[m_nRowIndex].SetHighlighted(true);
        m_fLastXAxis = l_fXAxis;
        m_fLastYAxis = l_fYAxis;
    }

    private Character.Element GetElement(int a_nColumnIndex)
    {
        for (int i = 0; i < Columns[a_nColumnIndex].Icons.Length; i++)
        {
            if (Columns[a_nColumnIndex].Icons[i].GetSelected())
            {
                return Columns[a_nColumnIndex].Icons[i].ElementType;
            }
        }
        Debug.LogWarning("No element selected in row " + a_nColumnIndex.ToString());
        return Character.Element.Earth;
    }

    private void Confirm()
    {
        Player l_CPlayer = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player>();
        if (l_CPlayer != null)
        {
            l_CPlayer.bindHP = GetElement(0);
            l_CPlayer.bindAtk = GetElement(1);
            l_CPlayer.bindDef = GetElement(2);
            l_CPlayer.bindMgk = GetElement(3);
        }
        m_bActive = false;
        if (Root != null)
        {
            Root.SetActive(false);
        }
    }
}
