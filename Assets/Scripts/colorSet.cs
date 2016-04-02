using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class colorSet : MonoBehaviour {

	public Vector4 setColor;
	int setRed;
	int setGreen;
	int setBlue;
	int setAlpha;
	public GameObject rChannelText;
	public GameObject gChannelText;
	public GameObject bChannelText;

	// Set Red Channel Value 
	public void SetRedColor (int redValue) {
		setRed = redValue;
		rChannelText.GetComponent<InputField>().text = redValue.ToString();
	}
	
	// Set Green Channel Value
	public void SetGreenColor (int greenValue) {
		setGreen = greenValue;
		gChannelText.GetComponent<InputField>().text = greenValue.ToString();
	}

	// Set Blue Channel Value
	public void SetBlueColor (int blueValue) {
		setBlue = blueValue;
		bChannelText.GetComponent<InputField>().text = blueValue.ToString();
	}

	// Set Alpha Channel Value
	public void SetAlphaColor (int alphaValue) {
		setAlpha = alphaValue;
	}

	public void SetRGBColor (){
		setColor = new Vector4(setRed, setGreen, setBlue, setAlpha);
	}

	public Vector4 SetColor
	{
		get {
			return setColor;
		}
	}
}
