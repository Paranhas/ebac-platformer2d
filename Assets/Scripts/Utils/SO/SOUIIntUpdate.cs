using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;
    public TextMeshProUGUI uiTextValuePower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = soInt.value.ToString();
        uiTextValuePower.text = soInt.valuePower.ToString();
    }
}
