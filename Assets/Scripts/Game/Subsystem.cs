using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subsystem : MonoBehaviour {
    private static SubsystemManager mngr { get { return SubsystemManager.Instance; } }

    public enum SubsystemType {
        Unknown = 0,
        Thrust,
        LifeSupport,
        Lights
    }

    public SubsystemType Type;
    public bool IsEnabled;
    public int PowerDrain;
    public GameObject KeyPopup;
    public float PlayerRange;
    public bool PlayerInRange;

	// Use this for initialization
	void Start () {
		mngr.RegisterSubsystem(this);
	}
	
	// Update is called once per frame
	void Update () {
	    PlayerInRange = (Player.Instance.transform.position - transform.position).sqrMagnitude <=
	            PlayerRange * PlayerRange;

        KeyPopup.SetActive(PlayerInRange);

	    if (PlayerInRange && Input.GetKeyDown(KeyCode.Space)) {
	        IsEnabled = !IsEnabled;
	    }
	}
}
