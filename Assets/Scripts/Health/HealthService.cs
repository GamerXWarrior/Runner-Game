using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthService : MonoGenericSingleton<HealthService>
{
    private int minHealthCount = 1;
    private int healthCount = 3;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        EventService.Instance.TakeDamage += CheckHealth;
    }

    public int GetHealthCount()
    {
        return healthCount;
    }

    public void CheckHealth()
    {
               
        if(healthCount > minHealthCount)
        {
            healthCount--;
            UIService.Instance.UpdateHealthCount();
        }
        else
        {
            healthCount--;
            UIService.Instance.UpdateHealthCount();
            EventService.Instance.OnPlayerDead();
        }
    }
}
