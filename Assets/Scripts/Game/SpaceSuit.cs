using UnityEngine;
using UnityEngine.UI;

public class SpaceSuit : MonoBehaviour {

    public Slider LifeSupportSlider;
    public Subsystem LifeSupportSystem;

    public float Capacity;
    public float TimeLeft;

    public float BaseFillRate;
    public float RechargeRate;

	// Use this for initialization
	void Start () {
	    LifeSupportSlider.maxValue = Capacity;
	    TimeLeft = Capacity;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!LifeSupportSystem.IsEnabled) {
	        TimeLeft -= Time.deltaTime;
	    }
	    else {
	        TimeLeft = Mathf.Clamp(TimeLeft + BaseFillRate * Time.deltaTime, 0, Capacity);
	    }

	    if (TimeLeft <= 0) {
	        Debug.LogWarning("Game over");
	    }

	    LifeSupportSlider.value = TimeLeft;
	}
}
