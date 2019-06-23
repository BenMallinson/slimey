using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharge : MonoBehaviour {
    public int currentCharge;
    public Slider chargeSlider;

    public void setCharge (int charge) {
        currentCharge = charge;
        chargeSlider.value = charge;
    }

    public void setMax (int max) {
        chargeSlider.maxValue = max;
    }
}
