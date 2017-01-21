using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public Text fireAmount;
    public Text iceAmount;
    public Text lightningAmount;
    public Text earthAmount;
    
    [SerializeField]
    private GameManager gm;

    void Awake()
    {
        if(!gm)
            gm = gameObject.GetComponent<GameManager>();

    }

    void OnGUI()
    {

    }
}
