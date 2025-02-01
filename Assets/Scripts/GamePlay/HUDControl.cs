using UnityEngine;

[System.Serializable]
public struct HUDControl
{
    public GameObject HUD;
    public string Name;

    public void Enable()
    {
        HUD.SetActive(true);
    }

    public void Disable() 
    {
        HUD.SetActive(false);
    }
}