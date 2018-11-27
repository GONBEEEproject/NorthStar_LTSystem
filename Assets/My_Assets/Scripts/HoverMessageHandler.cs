using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GON.TelloControll;

public class HoverMessageHandler : MonoBehaviour {

    public Controller controller = new Controller();

    #region SlideControll

    public void LoadSlide()
    {

    }

    public void Activate()
    {

    }

    public void Inactivate()
    {

    }

    public void Next()
    {

    }

    public void Previous()
    {

    }

    #endregion

    #region DroneControll

    public void Initialize()
    {
        controller.Initialize();
    }

    public void Connect()
    {
        controller.Connect();
    }

    public void Takeoff()
    {
        controller.Takeoff();
    }

    public void Land()
    {
        controller.Land();
    }

    #endregion
}
