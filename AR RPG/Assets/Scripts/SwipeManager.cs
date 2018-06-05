using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeManager : MonoBehaviour {
	public bool action;
	public ShapeDetector.ShapeType type;
	[SerializeField]
	private Text _typeMessage;
	private Shape _shape;
	public ShapeDetector _detector;
	private bool onTouchPanel;
	
	void Start() {
		_detector = new ShapeDetector();
		type = ShapeDetector.ShapeType.NONE;
	}

	public void TrackSwipe() {
		if (Input.touchCount > 0) {			
			
			if (CheckOnTouchPanel()) {
				var _position = Input.mousePosition;
				_position.z = 10f;						
				transform.position = Camera.main.ScreenToWorldPoint(_position);
				_shape = new Shape();			
				_shape.vectorPoints.Add(_position.y);
				action = true;
			} 

		} else {
			if (action) {
				Invoke("ShowMatch", 0.1f);
			}
		}
	}

	public bool CheckOnTouchPanel() {
		return onTouchPanel;
	}

	public void OnTouchPanel() {
		onTouchPanel = true;
	}

	public void OutTouchPanel() {
		onTouchPanel = false;
	}
	
	public void ShowMatch() {
		ShapeDetector.ShapeType t = _detector.FindMatch(_shape);
		_typeMessage.text = t.ToString();
		type = t;		
		Invoke("RemoveMessage", 1f);
	}

	public void RemoveMessage() {
		_typeMessage.text = "";
		type = ShapeDetector.ShapeType.NONE;
		action = false;				
	}

	void Update () {
		TrackSwipe();		
	}
}
