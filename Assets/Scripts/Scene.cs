using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
	public Hero[] Heroes,Vrags;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			/*if (HeroImg == Physics2D.OverlapPoint(touchPos))
			{
				SetActivateSpell(!mActiveSpellVisible);		
			}*/
		}
		else if (Input.GetMouseButtonDown (0)) {	
			//print ("ButtonDown");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray,out hit) ){
				if(hit.collider!=null)
					for(int i=0;i<Heroes.Length;i++)
				{
					Heroes[i].SetActivateSpell(!Heroes[i].mActiveSpellVisible);
					Vrags[i].SetActivateSpell(!Vrags[i].mActiveSpellVisible);
				}
			} 
		}
	}
}
