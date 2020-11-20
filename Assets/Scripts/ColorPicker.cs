using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public InputField hexColorField;

    [SerializeField] private float red = 1f;
    [SerializeField] private float green = 1f;
    [SerializeField] private float blue = 1f;
    [SerializeField] private float alpha = 1f;
    [SerializeField] private string hexCode;

    [SerializeField] private Color color;
    [SerializeField] private Image image;

    private void Start()
    {
        SetColor();
    }
    private void Update()
    {
        ConvertToColor();
    }
    public void ConvertToColor()
    {
        Color _color;
        hexCode = hexColorField.GetComponent<InputField>().text;
        //Debug.Log("sss");
        ColorUtility.TryParseHtmlString(hexCode, out _color);
        image.color = _color;
    }

    public void Red(float _red)
    {
        red = _red;
        SetColor();
    }

    public void Green(float _green)
    {
        green = _green;
        SetColor();
    }

    public void Blue(float _blue)
    {
        blue = _blue;
        SetColor();
    }

    public void Alpha(float _alpha)
    {
        alpha = _alpha;
        SetColor();
    }

    public void SetColor()
    {
        color = new Color(red, green, blue, alpha);
        image.color = color;
    }

    public Color GetColorValue()
    {
        return color;
    }
}
