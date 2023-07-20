using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LocationActionIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _actionIcon;
    [SerializeField] private GameObject _popUpName;
    [SerializeField] private TextMeshProUGUI _text;

    public void Setup(Sprite _actionSprite, string _actionText)
    {
        _actionIcon.sprite = _actionSprite;
        _text.text = _actionText;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _popUpName.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _popUpName.SetActive(false);
    }


}
