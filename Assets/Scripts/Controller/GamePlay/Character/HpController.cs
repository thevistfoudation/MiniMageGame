using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    [SerializeField]private Image _hpImg;

    public void ShowHp(float hp, float hpMax)
    {
        _hpImg.fillAmount = hp/hpMax;
    }
}
