using DG.Tweening;
using Salsa;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour {

    [Tooltip("The amount of time it takes to transition from one state to another.")]
    public float duration = 0.5f;

    [Tooltip("The position that the dialog starts in when first loaded (in `Start()`)")]
    public StartPosition startPosition = StartPosition.Hidden;

    [Tooltip("The optional `Selectable` to highlight when dialog is shown.")]
    public Selectable selectedOnShow;

    [Tooltip("An optional image which is enabled and siabled with the dialog.  Can obscure background controls, add watermarks, etc.")]
    public Image background;

    private StartPosition position;

    [Header("Show Transform (use menu)")]
    public Vector3 showPosition;
    public Vector3 showRotation;
    public Vector3 showScale;

    [Header("Hide Transform (use menu)")]
    public Vector3 hidePosition;
    public Vector3 hideRotation;
    public Vector3 hideScale;

    [ContextMenu("Set Show Transform")]
    public void SetShowTransform() {
        showPosition = transform.position;
        showRotation = transform.rotation.eulerAngles;
        showScale = transform.localScale;
    }

    [ContextMenu("Move to Show Transform")]
    public void MoveToShowTransform() {
        transform.position = showPosition;
        transform.rotation = Quaternion.Euler(showRotation);
        transform.localScale = showScale;
        position = StartPosition.Shown;
    }

    [ContextMenu("Set Hide Transform")]
    public void SetHideTransform() {
        hidePosition = transform.position;
        hideRotation = transform.rotation.eulerAngles;
        hideScale = transform.localScale;
    }

    [ContextMenu("Move to Hide Transform")]
    public void MoveToHideTransform() {
        transform.position = hidePosition;
        transform.rotation = Quaternion.Euler(hideRotation);
        transform.localScale = hideScale;
        position = StartPosition.Hidden;
    }

    private void Start() {
        if(startPosition == StartPosition.Hidden) {
            MoveToHideTransform();
        }
        else {
            MoveToShowTransform();
        }
        ShowHideChildren(startPosition == StartPosition.Shown);
        position = startPosition;
    }

    public void Show() {
        if(position == StartPosition.Hidden) {
            StartCoroutine(ShowCo());
        }
    }

    private IEnumerator ShowCo() {
        position = StartPosition.Moving;
        ShowHideChildren(true);
        transform.DOMove(showPosition, duration, true);
        transform.DORotate(showRotation, duration);
        transform.DOScale(showScale, duration);
        if(background != null) {
            background.DOColor(background.color.Opaque(), duration);
        }
        yield return WaitFor.Seconds(duration);
        position = StartPosition.Shown;
        selectedOnShow?.Select();
    }

    public void Hide() {
        if(position == StartPosition.Shown) {
            StartCoroutine(HideCo());
        }
    }

    private IEnumerator HideCo() {
        position = StartPosition.Moving;
        transform.DOMove(hidePosition, duration, true);
        transform.DORotate(hideRotation, duration);
        transform.DOScale(hideScale, duration);
        if(background != null) {
            background.DOColor(background.color.Transparent(), duration);
        }
        yield return WaitFor.Seconds(duration);
        ShowHideChildren(false);
        position = StartPosition.Hidden;
    }

    public void Toggle() {
        if(position == StartPosition.Shown) {
            Hide();
        }
        else if(position == StartPosition.Hidden) {
            Show();
        }
    }

    public void Peek(float seconds) {
        hideTime = Time.time + seconds;
        StartCoroutine(PeekRoutine(seconds));
    }

    private IEnumerator PeekRoutine(float seconds) {
        Show();
        while(Time.time < hideTime) {
            yield return WaitFor.EndOfFrame;
        }
        Hide();
    }
    private float hideTime = float.MaxValue;

    private void ShowHideChildren(bool active) {
        for(int i = 0; i < transform.childCount; ++i) {
            transform.GetChild(i).gameObject.SetActive(active);
        }
        background?.gameObject?.SetActive(active);
    }

}

public enum StartPosition {
    Shown,
    Moving,
    Hidden,
}
