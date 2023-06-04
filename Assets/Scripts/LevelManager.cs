using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    [Header("���ŻP�g��Ȥ���")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;
    [Header("���ŤW��"), Range(0, 500)]
    public int lvMax = 100;

    private int lv = 1;
    private float exp;
    public float[] expNeeds;

    [ContextMenu("��s�g��ȻݨD��")]
    private void UpdateExpNeeds()
    {
        expNeeds = new float [lvMax];
        for (int i = 0; i < lvMax; i++)
        {
            expNeeds[i] = (i + 1) * 100;     
        }
    }
    
    /// <summary>
    /// ��o�g���
    /// </summary>
    /// <param name="getExp">���o�g��ȯB�I��</param>
    public void GetExp(float getExp)
    {
        exp += getExp;
        print($"<color=yellow>��e�g���:{exp}</color>");

        if (exp >= expNeeds[lv - 1] && lv < lvMax)
        {
            exp -= expNeeds[lv - 1];
            textLv.text = $"Lv {++lv}";
        }

        textExp.text = $"{exp} / {expNeeds[lv - 1]}";
        imgExp.fillAmount = exp / expNeeds[lv - 1];

        
    }

}
