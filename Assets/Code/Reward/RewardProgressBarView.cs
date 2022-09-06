using TMPro;
using UnityEngine;
using UnityEngine.UI;


internal class RewardProgressBarView : MonoBehaviour
{
    [SerializeField] private Image _mask;
    [SerializeField] private TMP_Text _textTime;
    
    public Image Mask => _mask;

    public string TextTime
    {
        set => _textTime.text = value;
    }
}
