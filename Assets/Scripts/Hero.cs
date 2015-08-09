using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	public SpriteRenderer LiveImg,ManaImg;
	public int mMana,mManaMax,mLive,mLiveMax;
	public SpriteRenderer HeroImg;
	bool mLiveUp;
	int mMyPhysicalArmor=0,mTempPhysicalArmor=0;
	float mHeroMagicArmor=0.0f,mPredmetMagicArmor=0.0f,mAOEmagicArmor=0.0f,mUpMagicDamage=0.0f;
	bool mMouseDown;

	public SpriteRenderer[] mActive;
	bool mActiveSpellVisible;
	int mCountActiveSpell;
	// Use this for initialization
	void Start () {
		mManaMax = 100;
		mLiveMax = 100;
		mMana = 100;
		mLive = 100;
		mLiveUp = false;

		mCountActiveSpell = 4;
		mActiveSpellVisible = false;
		mMouseDown=false;
		SetActivateSpell (mActiveSpellVisible);
	}

	void OnMouseDown () {
		mMouseDown = true;
	}

	void OnMouseUp () {
		mMouseDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (mLiveUp) {
			mLive+=1;
			if(mLive>=mLiveMax){
				mLive=mLiveMax;
				mLiveUp=false;
			}
		} else {
			mLive-=1;
			if(mLive<=0){
				mLive=0;
				mLiveUp=true;
			}
		}
		LiveImg.transform.localScale = new Vector3 ((float)mLive/(float)mLiveMax,1,1);
		ManaImg.transform.localScale = new Vector3 ((float)mMana/(float)mManaMax,1,1);

		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (HeroImg == Physics2D.OverlapPoint(touchPos))
			{
				SetActivateSpell(!mActiveSpellVisible);		
			}
		}
		else if (Input.GetMouseButtonDown (0)) {	
			//print ("ButtonDown");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray,out hit) ){
				if(hit.collider!=null)
				//print ("ButtonDown");
				SetActivateSpell(!mActiveSpellVisible);
			} 
		}
	}

	void SetActivateSpell(bool pActive)	{
		if (!mMouseDown) {
			mActiveSpellVisible = false;
			for (int i=0; i<4; i++) {
				mActive[i].enabled = false;
				mActive[i].transform.localPosition = new Vector3(mActive[i].transform.localPosition.x,mActive[i].transform.localPosition.y,400);
			}
			return;
		}
		mActiveSpellVisible = pActive;
		if (mActiveSpellVisible) {
			for(int i=0;i<mCountActiveSpell;i++)
			{
				mActive[i].enabled=true;
				mActive[i].transform.localPosition = new Vector3(mActive[i].transform.localPosition.x,mActive[i].transform.localPosition.y,0);
			}
		} else {
			for(int i=0;i<4;i++)
			{
				mActive[i].enabled=false;
				mActive[i].transform.localPosition = new Vector3(mActive[i].transform.localPosition.x,mActive[i].transform.localPosition.y,400);
			}
		}
	}

	bool ManaCanDoIt(int pMana)
	{
		if (pMana > mMana)
			return false;
		return true;
	}

	void AddPhysicalArmor(int pPhysicalArmor,bool pItsMy)
	{
		if (pItsMy) {
			mMyPhysicalArmor += pPhysicalArmor;
			if (mMyPhysicalArmor < 0)
				mMyPhysicalArmor = 0;
		} else {
			mTempPhysicalArmor +=pPhysicalArmor;
			if(mTempPhysicalArmor<0)
				mTempPhysicalArmor=0;
		}
	}

	void PhysicalDamage (int pDamage)
	{
		float pAllArmor = (float)mMyPhysicalArmor + (float)mTempPhysicalArmor;
		float pRealDamage=(float)pDamage*(0.06f*pAllArmor)/(1.0f+0.06f*pAllArmor);
		mLive -= (int)pRealDamage;
		if (mLive < 0) {
			mLive = 0;
			//you die
		}
	}

	void SetHeroMagicArmor(float pHeroMagicArmor)
	{
		mHeroMagicArmor = pHeroMagicArmor;
	}

	void AddPredmetMagicArmor(float pPredmetMagicArmor)
	{
		mPredmetMagicArmor += pPredmetMagicArmor;
	}

	void AddAOEmagicArmor(float pAOEmagicArmor)
	{
		mAOEmagicArmor = pAOEmagicArmor;
	}

	void MagicDamage(int pDamage,float pUpDamage)
	{
		float pRealDamage = (float)pDamage * (1.0f - mHeroMagicArmor / 1.0f) * (1.0f - mPredmetMagicArmor / 1.0f) * (1.0f - mAOEmagicArmor / 1.0f) * (1.0f + pUpDamage / 1.0f);
		mLive -= (int)pRealDamage;
		if (mLive < 0) {
			mLive = 0;
			//you die
		}
	}

	void AddUpMagicDamage(float pUpMagicDamage)
	{
		mUpMagicDamage += pUpMagicDamage;
	}
}
