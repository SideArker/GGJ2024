using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField] UpgradeBtnUpdater[] updater;
    public Camera currentCam;

    public void ChangeCam(Camera cam)
    {
        currentCam = cam;
    }
    public void UpdateEntries()
    {
        foreach(UpgradeBtnUpdater updater in updater)
        {
            updater.UpdateData(updater.defaultObject);
        }
    }

    private void Awake()
    {
        Instance = this;
    }
}
