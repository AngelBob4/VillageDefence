using UnityEngine;
using System.Collections.Generic;

public class BackPackView : MonoBehaviour
{
    private Stack<Bullet> _bullets = new Stack<Bullet>();
    private float _distanceBetweenBullets;

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
        bullet.transform.localPosition = Vector3.zero;

        float verticalOffset = (_bullets.Count - 1) * _distanceBetweenBullets;
        bullet.transform.localPosition += new Vector3(0, verticalOffset, 0);

        Vector3 rotationToHorizontal = new Vector3(0f, 90f, 0f);
        bullet.transform.localEulerAngles = rotationToHorizontal;
    }
}