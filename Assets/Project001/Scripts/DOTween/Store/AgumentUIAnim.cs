using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class AgumentUIAnim : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public RectTransform storeRectTransform;

    public Button nextButton;
    public Button prevButton;


  
    public void NextButton()
    {
        panelRectTransform.DOAnchorPos(new Vector2(0, 0), 1f).OnComplete(OnNextButtonComplete);
        storeRectTransform.DOAnchorPos(new Vector2(-2240, -60), 1f);
    }

    public void PrevButton()
    {
        panelRectTransform.DOAnchorPos(new Vector2(2000, 0), 1f).OnComplete(OnPrevButtonComplete);
        storeRectTransform.DOAnchorPos(new Vector2(-240, -60), 1f);
    }

    private void OnNextButtonComplete()
    {
        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
    }

    private void OnPrevButtonComplete()
    {
        nextButton.gameObject.SetActive(true);
        prevButton.gameObject.SetActive(false);
    }
}
