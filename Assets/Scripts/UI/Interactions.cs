using UnityEngine;
using System.Collections;

public class Interactions : MonoBehaviour {

    public GameObject muteButtonImg;

    public Sprite muteSprite, nonMuteSprite;

    public bool IsMuted = false;

	public void Play()
    {

    }

    public void Mute()
    {
        IsMuted = !IsMuted;

        if (IsMuted)
            muteButtonImg.GetComponent<UnityEngine.UI.Image>().sprite = muteSprite;
        else
            muteButtonImg.GetComponent<UnityEngine.UI.Image>().sprite = nonMuteSprite;
    }
}
