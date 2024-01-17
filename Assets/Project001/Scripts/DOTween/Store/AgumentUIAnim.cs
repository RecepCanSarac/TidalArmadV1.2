using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class AgumentUIAnim : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public RectTransform storeRectTransform;


    public RectTransform Arrows;

  
    public void NextButton()
    {
        panelRectTransform.DOAnchorPos(new Vector2(0, 0), 1f);
        storeRectTransform.DOAnchorPos(new Vector2(-2240, -60), 1f);
        OnNextButtonComplete();
    }

    public void PrevButton()
    {
        panelRectTransform.DOAnchorPos(new Vector2(2000, 0), 1f);
        storeRectTransform.DOAnchorPos(new Vector2(-240, -60), 1f);
        OnPrevButtonComplete();
    }

    private void OnNextButtonComplete()
    {
        Arrows.DORotate(new Vector3(0f, 0f, 180f), 1f)
           .SetEase(Ease.OutQuad)
           .OnComplete(() =>
           {
               Debug.Log("Rotasyon tamamlandý!");
           });
    }

    private void OnPrevButtonComplete()
    {
        Arrows.DORotate(new Vector3(0f, 0f, 0), 1f)
            .SetEase(Ease.OutQuad) 
            .OnComplete(() =>
            {
                Debug.Log("Rotasyon tamamlandý!");
            });
    }
}
