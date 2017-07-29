using UnityEngine;
using UnityEngine.UI;

public class ThrustManager : MonoBehaviour {

    public float TotalTime;
    public float TotalThrust;
    public float TimeLeft;
    public float ThrustLeft;

    public Slider TimeSlider;
    public Slider ThrustSlider;

    public Subsystem ThrustSystem;

    private int initialTotalPower;

	// Use this for initialization
	void Start () {
	    TimeSlider.maxValue = TotalTime;
	    ThrustSlider.maxValue = TotalThrust;

	    TimeLeft = TotalTime;
	    ThrustLeft = TotalThrust;

	    initialTotalPower = SubsystemManager.Instance.TotalPower;
	}
	
	// Update is called once per frame
	void Update () {
	    TimeLeft -= Time.deltaTime;
	    if (ThrustSystem.IsEnabled) {
	        ThrustLeft -= Time.deltaTime;
	    }

	    TimeSlider.value = TimeLeft;
	    ThrustSlider.maxValue = TimeLeft;
	    ThrustSlider.value = ThrustLeft;

	    SubsystemManager.Instance.TotalPower = Mathf.CeilToInt(initialTotalPower * (.5f + .5f * TimeLeft / TotalTime));
	}
}
