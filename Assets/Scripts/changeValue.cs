using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeValue : MonoBehaviour {

	//select slider from Unity evironment
	public Slider mySlider;

	//select main pallete from Unity environment
	public GameObject setPallete;

	//select color channel according to each UI element (InputField)
	public int colorChannel;

	//Get Value from Slider and set to Pallete (From pallete to InputField)
	public void GetValueFromSlider () {
		setPallete.GetComponent<colorSet>().setColor[colorChannel] = mySlider.value;
		this.GetComponent<InputField>().text = mySlider.value.ToString();
	}
	
	// Set InputField Value to Slider and Pallete
	public void SetValueToSlider () {
		float sliderValue;
		float.TryParse(this.GetComponent<InputField>().text, out sliderValue);
		mySlider.value = sliderValue;
		setPallete.GetComponent<colorSet>().setColor[colorChannel] = sliderValue;
	}
		
}
