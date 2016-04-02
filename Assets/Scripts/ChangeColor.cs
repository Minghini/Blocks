using UnityEngine;
using System.Collections;


public class ChangeColor : MonoBehaviour {

	private Transform checkBlock;
	private Ray clickPos;
	private Camera myCam;
	private RaycastHit selectBlock;
	public Vector4 actPaint; 
	public GameObject getPallete;

	// Use this for initialization
	void Start () {
		myCam = Camera.main.GetComponent<Camera>();

	}
	// Update is called once per frame
	void Update () {

		// Get percentage values of RGB pallete
		actPaint =  (getPallete.GetComponent<colorSet>().setColor)/255; 

		// Get clicked object
		if(Input.GetMouseButtonDown(0)){
			clickPos = myCam.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(clickPos, out selectBlock);

			// get clicked box position
			checkBlock = selectBlock.collider.transform;


			// check if clicked object is a board tile and set color
			if(selectBlock.collider.tag == "Block"){
				selectBlock.collider.GetComponent<Renderer>().material.color = new Color (actPaint[0],actPaint[1],actPaint[2],actPaint[3]);
				selectBlock.collider.GetComponent<Transform>().position = new Vector3(checkBlock.position.x,0.1F,checkBlock.position.z);
			}
		}

	}
}
