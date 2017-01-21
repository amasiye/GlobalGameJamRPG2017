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
        if(fireAmount)
            fireAmount.text = gm.Fire.ToString();

        if(iceAmount)
            iceAmount.text = gm.Ice.ToString();

        if(lightningAmount)
            lightningAmount.text = gm.Lightning.ToString();

        if(earthAmount)
            earthAmount.text = gm.Earth.ToString();
    }
}
