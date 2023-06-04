using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    [Header("等級與經驗值介面")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;
    [Header("等級上限"), Range(0, 500)]
    public int lvMax = 100;

    private int lv = 1;
    private float exp;
    public float[] expNeeds;

    [ContextMenu("更新經驗值需求表")]
    private void UpdateExpNeeds()
    {
        expNeeds = new float [lvMax];
        for (int i = 0; i < lvMax; i++)
        {
            expNeeds[i] = (i + 1) * 100;     
        }
    }
    
    /// <summary>
    /// 獲得經驗值
    /// </summary>
    /// <param name="getExp">取得經驗值浮點數</param>
    public void GetExp(float getExp)
    {
        exp += getExp;
        print($"<color=yellow>當前經驗值:{exp}</color>");

        if (exp >= expNeeds[lv - 1] && lv < lvMax)
        {
            exp -= expNeeds[lv - 1];
            textLv.text = $"Lv {++lv}";
        }

        textExp.text = $"{exp} / {expNeeds[lv - 1]}";
        imgExp.fillAmount = exp / expNeeds[lv - 1];

        
    }

}
