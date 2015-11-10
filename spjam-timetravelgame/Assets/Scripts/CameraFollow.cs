using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	private Vector2 velocity;
	
	public GameObject cameraY;
	//teste
	public float smoothTimeX;
	public GameObject player;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate()
	{
		if (player != null) {
			float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
			//  float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
			posX = Mathf.Max (22, Mathf.Min (posX, 3000));
			transform.position = new Vector3 (posX, cameraY.transform.position.y, transform.position.z);       
		}
	}
}