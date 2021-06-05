using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDesign : MonoBehaviour
{
    [SerializeField]
    private BlockData _container;
    [SerializeField]
    private Image _backgroundImage;
    [SerializeField]
    private SpriteRenderer _playgroundImage;
    [SerializeField]
    private SpriteRenderer _frameImage;
    [SerializeField]
    private Image _ButtonResum;
    [SerializeField]
    private Image _ButtonPause;
    [SerializeField]
    private Image _ButtonRestart;
    [SerializeField]
    private Image _ButtonMenu;





    private void Start()
    {
        _backgroundImage.sprite = _container.backgroundImage;
        _playgroundImage.sprite = _container.playgroundImage;
        _frameImage.sprite = _container.frameImage;
        _ButtonMenu.sprite = _container.ButtonMenu;
        _ButtonResum.sprite = _container.ButtonResum;
        _ButtonPause.sprite = _container.ButtonPause;
        _ButtonRestart.sprite = _container.ButtonRestart;

    }

}
