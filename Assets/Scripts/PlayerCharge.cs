using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharge : MonoBehaviour {
    public int currentCharge;
    public Slider chargeSlider;

    void Awake () {
        chargeSlider.gameObject.SetActive (false);
    }

    public void setCharge (int charge) {
        if (currentCharge == 0 && charge > 0) chargeSlider.gameObject.SetActive (true);
        if (currentCharge > 0 && charge == 0) chargeSlider.gameObject.SetActive (false);
        currentCharge = charge;
        chargeSlider.value = charge;
    }

    public void setMax (int max) {
        chargeSlider.maxValue = max;
    }
}