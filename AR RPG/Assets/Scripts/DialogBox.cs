using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {
	public List<string> dialog;
	public string currentDialog;
	public Text dialogMessage;
	private int _index;

	void Start () {
		_index = 0;
		InvokeRepeating("CharByChar", 0f, 0.15f);
		dialogMessage = GetComponentInChildren<Text>();
		currentDialog = dialog[(int)Random.Range(0, dialog.Count)];		
	}

	void Update () {
		Invoke("CloseDialogBox", 10f);
	}

	public void CharByChar() {
		if (_index < currentDialog.Length - 1) {
			dialogMessage.text += currentDialog[_index];
			_index++;			
		}	
	}

	public void CloseDialogBox() {
		var scale = transform.localScale;
		scale.x = Mathf.Lerp(transform.localScale.x, 0f, Time.deltaTime * 10f);
		transform.localScale = scale;
	}
}
