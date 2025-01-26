using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Math_Function_Script : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI validText;

    public TMP_InputField aInput;
    public TMP_InputField bInput;
    public TMP_InputField cInput;
    public TMP_InputField lInput;
    public TMP_InputField rInput;
    public GameObject curve;

    

    public void SubmitCurve() {
        errorText.gameObject.SetActive(false);
        validText.gameObject.SetActive(false);

        
        float a, b, c, l, r;

        
        if (!float.TryParse(aInput.text, out a) ||
            !float.TryParse(bInput.text, out b) ||
            !float.TryParse(cInput.text, out c) ||
            !float.TryParse(lInput.text, out l) ||
            !float.TryParse(rInput.text, out r))
        {
            errorText.gameObject.SetActive(true);
            return;
        }

        curve.GetComponent<Generate_Curve>().RegenerateCurve(a, b, c, l, r);
        validText.gameObject.SetActive(true);
           
    }

    void OnEnable() {
        aInput.text = curve.GetComponent<Generate_Curve>().a.ToString();
        bInput.text = curve.GetComponent<Generate_Curve>().b.ToString();
        cInput.text = curve.GetComponent<Generate_Curve>().c.ToString();

        lInput.text = curve.GetComponent<Generate_Curve>().leftBound.ToString();
        rInput.text = curve.GetComponent<Generate_Curve>().rightBound.ToString();
    
        errorText.gameObject.SetActive(false);
        validText.gameObject.SetActive(false);
    }
    
}
