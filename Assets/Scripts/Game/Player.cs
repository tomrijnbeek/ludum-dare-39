using UnityEngine;

public class Player : MonoBehaviour {
    public Vector3 goalPoint;

	// Use this for initialization
	void Start () {
	    goalPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0)) {
            // Get mouse coordinates
	        var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	        if (Mathf.Abs(worldMousePos.x) < 10 && Mathf.Abs(worldMousePos.y) < 6) {
	            goalPoint = new Vector3(worldMousePos.x, worldMousePos.y);
	        }
	    }

	    var goalDiff = goalPoint - transform.position;
        if (goalDiff.sqrMagnitude > .1f) {
            transform.position = transform.position + goalDiff.normalized * Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("Stop!");
        goalPoint = transform.position;
    }
}
