using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hitpoints : MonoBehaviour
{
    private int _hitpoints = 3;
    private float _hittimer;
    private float _scalar;
    private Renderer renderer;
    public Color ogcolor;
    public Gradient hitcolor;
    public UnityEvent onDeath;
    public int score = 300;
    public float hittimer
    {
        get
        {
            return _hittimer;
        }
        set
        {
            _hittimer = value;
            _scalar = 1 / value;
        }
    }
    public int hitpoints
    {
        get => _hitpoints;
        set
        {
            _hitpoints = value;
            if(_hitpoints <= 0)
            {
                onDeath.Invoke();
                ImportantVars.Instance.score += score;
            }
        }
        
    }
    public void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        ogcolor = renderer.material.color;
    }
    public void Update()
    {
        if(_hittimer <= 0)
        {
            return;
        }
        else
        {
            _hittimer -= Time.deltaTime;
            //if(renderer.material.color == ogcolor)
            //{
            //    renderer.material.color = Color.red;
            //}
            //else
            //{
            //    renderer.material.color = ogcolor;
            //}
            renderer.material.color = hitcolor.Evaluate(_hittimer * _scalar);
        }
    }
}
