using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public int healthValue;
    private bool isPoisoned = false;
    private Coroutine poisonCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = healthValue.ToString();
    }
    public void PlayerDamage()
    {
        healthValue -= 5;
    }
    public void PoisonDamage()
    { 
        if(!isPoisoned) 
        {
            isPoisoned = true;
            poisonCoroutine = StartCoroutine(ApplyPoison() );
        }
    }

    private IEnumerator ApplyPoison() 
    {
        while(isPoisoned)
        {
            yield return new WaitForSeconds(1);
            healthValue -= 1;

            if(healthValue <= 0)
            {
                healthValue = 0;
                StopPoison();
            }
        }
    }

    public void StopPoison()
    {
        if(isPoisoned)
        {
            isPoisoned = false;
            if (poisonCoroutine != null)
            {
                StopCoroutine(poisonCoroutine);
                poisonCoroutine = null;
            }
        }
    }
}
