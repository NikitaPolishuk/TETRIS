using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MainMenuDesign : MonoBehaviour
{
    
    [SerializeField]
    private BlockData _container;
    [SerializeField]
    private Image _backgroundImage;
    [SerializeField]
    private Image _playButton;

    private void Start()
    {
        _backgroundImage.sprite = _container.backgroundImage;
        _playButton.sprite = _container.playButton;
    }

}
