using UnityEngine;
using System.Collections;

public class ActiveButton : MonoBehaviour {
	public SpriteRenderer image;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown () {
	}

	public void SetVisible(bool pVisible)
	{
		image.enabled = pVisible;
		if(pVisible)
			transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,0);
		else
			transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,400);
	}
}
