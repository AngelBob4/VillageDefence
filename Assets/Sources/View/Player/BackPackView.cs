using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System.Collections;

public class BackPackView : MonoBehaviour
{
    private Stack<Bullet> _bullets = new Stack<Bullet>();
    private float _distanceBetweenBullets;
    private float _timeToStickBackpack = 0.5f;

    public void Init(float distanceBetweenBullets)
    {
        _distanceBetweenBullets = distanceBetweenBullets;
    }

    public void AddBullet(Bullet bullet)
    {
        _bullets.Push(bullet);
        SetPosition(bullet);
    }

    public void RemoveBullet()
    {
        Bullet oldBullet = _bullets.Pop();
        oldBullet.Destroy();
    }

    private void SetPosition(Bullet bullet)
    {
        bullet.transform.SetParent(transform);
        float verticalOffset = (_bullets.Count - 1) * _distanceBetweenBullets;
        float _fisrtTimeToStickBackpack = 0.2f;
        float _secondTimeToStickBackpack = _timeToStickBackpack - _fisrtTimeToStickBackpack;

        Vector3 rotationToHorizontal = new Vector3(0f, 90f, 0f);
        bullet.transform.DOLocalRotate(rotationToHorizontal, _timeToStickBackpack);

        Vector3 firstPosition = Vector3.up * 1.5f;
        Vector3 secondPosition = Vector3.zero + new Vector3(0, verticalOffset, 0);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(bullet.transform.DOLocalMove(firstPosition, _fisrtTimeToStickBackpack));
        mySequence.Append(bullet.transform.DOLocalMove(secondPosition, _secondTimeToStickBackpack));
    }
}