using UnityEngine;
using System.Collections;

public class ActiveButton : MonoBehaviour {
	public SpriteRenderer image;
	public int UID;
	public Hero mHero;
	float mMouseDownTime;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown () {
		transform.localScale = new Vector3 (1.2F,1.2F);
	}

	void OnMouseUp(){
		transform.localScale = new Vector3 (1.0F,1.0F);
		mHero.SetActivateSpell (false);
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
