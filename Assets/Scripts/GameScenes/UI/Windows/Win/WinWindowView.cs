﻿using System;
using System.Collections.Generic;
using Awaiter;
using DG.Tweening;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

namespace GameScenes.UI.Windows.Win
{
    public class WinWindowView : WindowView
    {
        public Button GetButton;
        public TextMeshProUGUI TotalMoneyEarnText;
        public Transform DollarsRoot;

        [NonSerialized] public readonly List<Vector3> DollarsInitialPositions = new();
        [NonSerialized] public readonly List<Quaternion> DollarsInitialRotations = new();
        [NonSerialized] public readonly CustomAwaiter AnimationAwaiter = new();
        
        public void SetupDollarsForAnimation()
        {
            for (var i = 0; i < DollarsRoot.childCount; i++)
            {
                var child = DollarsRoot.GetChild(i);
                
                DollarsInitialPositions.Add(child.position);
                DollarsInitialRotations.Add(child.rotation);
            }
        }

        public void Reset()
        {
            for (var i = 0; i < DollarsRoot.childCount; i++)
            {
                var child = DollarsRoot.GetChild(i);
                
                child.position = DollarsInitialPositions[i];
                child.rotation = DollarsInitialRotations[i];
            }
        }

        public async void PlayDollarsAnimation()
        {
            var delay = 0f;

            Reset();
            
            DollarsRoot.gameObject.SetActive(true);

            for (var i = 0; i < DollarsRoot.childCount; i++)
            {
                var child = DollarsRoot.GetChild(i);

                child.DOScale(1f, .3f).SetDelay(delay).SetEase(Ease.OutBack);
                child.GetComponent<RectTransform>().DOAnchorPos(new Vector2(460f, 840f), .7f).SetDelay(delay + .1f).SetEase(Ease.InBack);

                child.DORotate(Vector3.zero, .5f).SetDelay(delay + .5f).SetEase(Ease.Flash);
                child.DOScale(0f, .3f).SetDelay(delay + 1f).SetEase(Ease.OutBack);
                
                delay += .1f;
            }

            await Task.Delay(3000);
            AnimationAwaiter.Complete();
        }
    }
}