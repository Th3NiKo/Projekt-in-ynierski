using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKnoocker : MonoBehaviour {

	bool clicked = false;
	Vector3 clickPosition = new Vector3(0,0,0);
	void Update(){
		
		

		//If clicked
		if(Input.GetMouseButton(0)){
			RaycastHit hit;
			Vector3 p1 = this.transform.position;
			Vector3 p2 = new Vector3(this.transform.position.x, this.transform.position.y, -10f);
			float distanceToObstacle = 0;
			if (Physics.CapsuleCast(p1, p2, 0.33f, transform.forward, out hit, 50))
				distanceToObstacle = hit.distance;
			Debug.Log(distanceToObstacle);


			clicked = true;
			//Get position of click in world coordinates
			distanceToObstacle = Mathf.Clamp(distanceToObstacle, 0.8f, 100);
			clickPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToObstacle));
		    //Debug.Log("X" + clickPosition.x.ToString());
			//Debug.Log("Y" + clickPosition.y.ToString());
			//clickPosition = new Vector3((clickPosition.x - 0.5f) * 2/3, (clickPosition.y -0.5f) * 2/3, clickPosition.z -0.5f);
			//Clamp X and Y to fit tunel size. Set z to constant.
			clickPosition = new Vector3(Mathf.Clamp(clickPosition.x,-0.33f, 0.33f), Mathf.Clamp(clickPosition.y, -0.33f, 0.33f), -4.853f);

		}
		if(clicked)
		{	
			//Reach new position in low time
			if(this.transform.position != clickPosition){
				this.transform.position = Vector3.Lerp(this.transform.position, clickPosition, 0.1f);
			}
		}
	}

}
