using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public int BonesCount;
    UIManager uimanager;

    public void Awake()
    {
        uimanager = GetComponent<UIManager>();
    }
    private void Start()
    {
        BonesCount = 0;
        CoinText.text = BonesCount.ToString();
    }

    public void UpdateBonesScore()
    {
        BonesCount++;
       CoinText.text = BonesCount.ToString();
    }
}
