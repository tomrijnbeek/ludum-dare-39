using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsystemManager : MonoBehaviour {

    public static SubsystemManager Instance;

    public List<Subsystem> Subsystems;

    public int AvailablePower;
    public int TotalPower;
    public Slider PowerSlider;

	// Use this for initialization
	void Awake () {
	    Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	    AvailablePower = TotalPower;
		foreach (var s in Subsystems)
		    if (s.IsEnabled)
		        AvailablePower -= s.PowerDrain;
        if (AvailablePower < 0)
            dealWithNegativePower();
	    PowerSlider.maxValue = TotalPower;
	    PowerSlider.value = AvailablePower;
	}

    private void dealWithNegativePower() {
        
    }

    public void RegisterSubsystem(Subsystem system) {
        Subsystems.Add(system);
    }
}
