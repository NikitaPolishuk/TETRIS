using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDesign : MonoBehaviour
{
    [SerializeField]
    private BlockData _container;
    [SerializeField]
    private Image _backgroundImage;
    [SerializeField]
    private Image _ButtonRestart;
    [SerializeField]
    private Image _ButtonMenu;





    private void Start()
    {
        _backgroundImage.sprite = _container.backgroundImage;
        
        _ButtonMenu.sprite = _container.ButtonMenu;
       
        _ButtonRestart.sprite = _container.playButton;

    }
}
