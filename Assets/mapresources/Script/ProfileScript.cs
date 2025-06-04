using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProfileScript : MonoBehaviour
{
    public Text droneSpeedText;  // 드론 속도를 표시할 Text UI
    public Image droneImage; 

    public Text drone;
    void Start()
    {
        DisplayEquippedDroneInfo();
    }

 
    void DisplayEquippedDroneInfo(){
        DroneClass equippedDrone = EquippedDroneManager.Instance.GetEquippedDrone();

        if (equippedDrone != null){
            drone.text = equippedDrone.name;
            droneSpeedText.text = "Speed: " + equippedDrone.speed;
            droneImage.sprite = equippedDrone.image;
        }
        else
        {
            droneSpeedText.text = "";
            droneImage.sprite = null;
        }
    }
}
