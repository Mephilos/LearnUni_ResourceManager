using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;

    private float _ProductionSpeed = 0.5f;
    public float ProductionSpeed
    {
        get { return _ProductionSpeed; } // getter가 백킹 필드 반환 
        set 
        { 
            if (value < 0.0f) 
            { 
                Debug.LogError("음수 생산 속도는 설정할 수 없습니다!"); 
            } 
            else 
            { 
                _ProductionSpeed = value; 
            } 
        }
    }

    private float m_CurrentProduction = 0.0f;

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += _ProductionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing at the speed of {_ProductionSpeed}/s";
        
    }
    
    
}
