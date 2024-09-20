using DG.Tweening;
using GameScenes.UI.Windows;
using TMPro;
using UnityEngine;

namespace GameScenes.UI.LevelInfo
{
    public class LevelInfoView : WindowView
    {
        public TextMeshProUGUI CurrentMoneyText;
        public TextMeshProUGUI CurrentLevelText;
        public TextMeshProUGUI MoneyTooltipText;
        public Animation MoneyTooltipAnimation;
        
        public async void AnimateMoneyTooltip(int money)
        {
            MoneyTooltipText.text = money.ToString();
            MoneyTooltipText.color = money > 0 ? Color.green : Color.red;

            var initialPosition = MoneyTooltipText.rectTransform.anchoredPosition;
            var tooltipGo = MoneyTooltipText.gameObject;
            
            tooltipGo.SetActive(true);
            await MoneyTooltipText.rectTransform.DOAnchorPosY(100f, .4f).SetUpdate(true).SetEase(Ease.Linear).AsyncWaitForCompletion();
            tooltipGo.SetActive(false);
            
            MoneyTooltipText.rectTransform.anchoredPosition = initialPosition;
        }
    }
}