using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public Text speedValueText;

    public Slider speedSlider;
    public float speedSliderValue;

    public Toggle autopilot;
    public bool autopilotValue;

    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    void Start()
    {
        DontDestroyOnLoad(gameObject.transform);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resoultionIndex)
    {
        Resolution resolution = resolutions[resoultionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    void Update()
    {
        speedValueText.text = speedSliderValue.ToString();

        speedSliderValue = Mathf.Round(speedSlider.value * 10f) / 10f;
        autopilotValue = autopilot.isOn;
    }
}
