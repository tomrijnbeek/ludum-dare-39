using UnityEngine;

public class Player : MonoBehaviour {
    public static Player Instance;

    public Vector3 goalPoint;
    public float speed;

    void Awake() {
        Instance = this;
    }

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
            transform.SetPositionAndRotation(
                transform.position + goalDiff.normalized * Time.deltaTime * speed,
                Quaternion.AngleAxis(Mathf.Atan2(goalDiff.y, goalDiff.x) * Mathf.Rad2Deg, Vector3.forward));
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        goalPoint = transform.position;
    }
}
