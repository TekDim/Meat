using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
	public GameObject Heroes;
	public GameObject Enemies;
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
				if(hit.collider.tag!="Attack") {
					foreach (Transform child in Enemies.transform) {
						GameObject tHero = child.gameObject;
						tHero.GetComponent<Hero>().SetActivateSpell(!tHero.GetComponent<Hero>().mActiveSpellVisible);
					}
					foreach (Transform child in Heroes.transform) {
						GameObject tHero = child.gameObject;
						tHero.GetComponent<Hero>().SetActivateSpell(!tHero.GetComponent<Hero>().mActiveSpellVisible);
					}
				}
			} 
		}
	}
}
