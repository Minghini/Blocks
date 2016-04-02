using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO.Ports;
using System.Text;

public class DataTX : MonoBehaviour {


	// declare variables to be send to Serial
	public float ledColumn = 0;
	public float ledRow = 0;
	public int redValue = 0;
	public int greenValue = 0;
	public int blueValue = 0;
	string serialTX = "";
	//public GameObject boardTiles;
	public Transform tile;

	// Need Update boolean 
	bool txUpdate = false;

	// Gameobject Transform with cube children
	public Transform cubes;


	//int[,] ledMatrix = new int[100,4]; // 100 leds x Change flag, R , G , B values.
	private SerialPort sp;

	// Use this for initialization
	void Start () {
		sp = new SerialPort( "//dev//cu.usbmodemFD121", 9600, Parity.None, 8, StopBits.One);

		sp.Open();

		sp.ReadTimeout = 50;
	}

	// Update is called once per frame
	void Update () {

		foreach (Transform child in tile)
		{
			
			if (child.transform.position.y >= 0.1){
				//txUpdate = false;

				// Set variables from selected block
				ledColumn = (-1*(child.transform.position.x - 4.5F));
				ledRow = (9+(child.transform.position.z - 4.5F));
				redValue = (int)(child.GetComponent<Renderer>().material.color.r * 255);
				greenValue = (int)(child.GetComponent<Renderer>().material.color.b * 255);
				blueValue = (int)(child.GetComponent<Renderer>().material.color.g * 255);
				Debug.Log(child.transform.position.x);

				// send data to Serial
				serialTX = "d" + ((int)ledColumn).ToString() + "c" + ((int)ledRow).ToString() + "w" + redValue.ToString() + "r" + greenValue.ToString() + "g" + blueValue.ToString() + "bN";

				sp.Write(serialTX);
			}
			child.GetComponent<Transform>().position = new Vector3(child.transform.position.x,0,child.transform.position.z);
		}
	
	}

	public void UpdateLED (bool onOff){

		txUpdate = onOff;
	}
}
