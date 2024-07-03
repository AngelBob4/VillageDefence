using UnityEngine;

public class Inventory 
{
    public bool HasBullets => _bullets > 0;
    
    private int _bullets = 0;
}