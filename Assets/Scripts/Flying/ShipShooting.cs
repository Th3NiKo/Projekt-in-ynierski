using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipShooting : MonoBehaviour {

	//Structures / Objects
	private enum GunType { Bullet };
	public GameObject bulletObject;
    GameObject crosshair;
	Vector3 constCrossPos;
	Kursor3D kursor; 
	Collider col;

	//Timers
	public float cooldown;
	private float cooldownTimer;
	
	//Gun
	GunType actualGun;
	GameObject leftGun;
	GameObject rightGun;
	public ParticleSystem MuzzleLeft;
	public ParticleSystem MuzzleRight;
	bool m_HitDetect;


	//Aimbot aim
	bool autoaim;
	RaycastHit crossTrigger;

	
	void Start () {
		kursor = GameObject.FindGameObjectWithTag("Kursor").GetComponent<Kursor3D>();
		col = GetComponent<Collider>();
		actualGun = GunType.Bullet;
		leftGun = GameObject.Find("LeftMuzzle");
		rightGun = GameObject.Find("RightMuzzle");
		crosshair = GameObject.Find("Crosshair");
		constCrossPos = crosshair.transform.localPosition;
		col = GetComponent<Collider>();
		cooldownTimer = 0.0f;
		cooldown = 0.3f;
		//damage = 10.0f;
		autoaim = false;
	}
	
	
	void Update () {
		
		if(cooldown < cooldownTimer){
			if(kursor.IsPressed()){
				if(ShipMovement.canMove){
					Shoot();
					cooldownTimer = 0.0f;
				}
			}
		}
		cooldownTimer += Time.deltaTime;
	}

	void FixedUpdate() {
		Crosshair();
	}

	void Shoot(){
		
		MuzzleLeft.Play();
		MuzzleRight.Play();
		GameObject actualBullet = bulletObject;
		switch(actualGun){
			case GunType.Bullet:
			actualBullet = bulletObject;
			break;
		}
		
		GameObject bullet1 = Instantiate(actualBullet.gameObject, leftGun.transform.position, Quaternion.identity);
		GameObject bullet2 = Instantiate(actualBullet.gameObject, rightGun.transform.position, Quaternion.identity);
		if(autoaim){
			bullet1.GetComponent<Bullet>().SetDirection(crossTrigger.transform.position);
			bullet2.GetComponent<Bullet>().SetDirection(crossTrigger.transform.position);
			bullet1.GetComponent<Bullet>().ShootForward(false);
			bullet2.GetComponent<Bullet>().ShootForward(false);
		} else {
			bullet1.GetComponent<Bullet>().ShootForward(true);
			bullet2.GetComponent<Bullet>().ShootForward(true);
		}
		Destroy(bullet1,2f);
		Destroy(bullet2,2f);

		//Shooting with first gun
		/* RAYCASTS
		RaycastHit hit;
		if(Physics.Raycast(leftGun.transform.position, this.transform.forward * -1, out hit)){ //We hit something with left
			Target target = hit.transform.GetComponent<Target>();
			if(target != null){
				target.TakeDamage(damage);
			}
		}

		if(Physics.Raycast(rightGun.transform.position, this.transform.forward * -1, out hit)){ //We hit something with right
			
		}*/
	}

	void Crosshair(){
		Vector3 center = col.bounds.center;
		center.y += 1.0f;
		center.z += 4.0f;
		ExtDebug.DrawBoxCastBox(center,transform.localScale * 3f,transform.rotation, transform.forward * -1, 100f, Color.red);
		/* 
		if(m_HitDetect = Physics.BoxCast(col.bounds.center,transform.localScale * 3f, transform.forward * -1, out crossTrigger)){
			if(crossTrigger.collider.tag == "Meteor"){
				Vector3 crosshairScreen = Camera.main.WorldToScreenPoint(crosshair.transform.position);
				Vector3 meteorScreen = Camera.main.WorldToScreenPoint(crossTrigger.collider.transform.position);
				crosshairScreen.x = meteorScreen.x;
				crosshairScreen.y = meteorScreen.y;
				crosshair.transform.position = Vector3.Lerp(crosshair.transform.position, Camera.main.ScreenToWorldPoint(crosshairScreen),1.0f);
				autoaim = true;
				
			}
		} else {
			crosshair.transform.localPosition = Vector3.Lerp(crosshair.transform.localPosition,constCrossPos,1.0f);
			autoaim = false;
		} */
	}

	void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * -100);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * -100, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * -100);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * -100, transform.localScale);
        }
    }



}
