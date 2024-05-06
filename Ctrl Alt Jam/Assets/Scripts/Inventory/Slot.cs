using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image _slotIcon;
    [SerializeField] private ItemData _currentItem;
    [SerializeField] private TextMeshProUGUI _quantity;

    private int _qtd;

    public void AddItem()
    {

    }

    public void IncreaseItemQtd()
    {
        _qtd++;
        _quantity.text = _qtd.ToString();
    }

    public void ReduceItemQtd()
    {
        _qtd--;

        if (_qtd < 0)
            _qtd = 0;

        _quantity.text = _qtd.ToString();
    }
}
