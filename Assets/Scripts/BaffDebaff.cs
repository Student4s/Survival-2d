using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaffDebaff : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    void Start()
    {
        //StartCoroutine(PekelniBoroshna(1, 3f));
        //StartCoroutine(AdrenalineRush(3f));
    }

    public IEnumerator PekelniBoroshna(int hardLevel, float duration)
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<StatsComponent>().Energy /= (1 + hardLevel);
        gameObject.GetComponent<StatsComponent>().maxEnergy /= (1 + hardLevel);
        gameObject.GetComponent<StatsComponent>().Stamina /= (1 + hardLevel);
        gameObject.GetComponent<StatsComponent>().maxStamina /= (1 + hardLevel);
        gameObject.GetComponent<MoveComponent>().Speed /= (1 + hardLevel);
        Debug.Log("Nemae sechi terpitu!");

        yield return new WaitForSeconds(duration);

        gameObject.GetComponent<StatsComponent>().Energy *= (1 + hardLevel);
        gameObject.GetComponent<StatsComponent>().maxEnergy *= (1 + hardLevel);
        gameObject.GetComponent<StatsComponent>().Stamina *= (1 + hardLevel);
        gameObject.GetComponent<StatsComponent>().maxStamina *= (1 + hardLevel);
        gameObject.GetComponent<MoveComponent>().Speed *= (1 + hardLevel);
        Debug.Log("Electroharchuvannya!");
    }

    public IEnumerator AdrenalineRush(float duration)
    {
        Debug.Log("mmmm, adrenalinus");
        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponent<MoveComponent>().Speed *= 1.3f;
        gameObject.GetComponent<MoveComponent>().baseSpeed *= 1.3f;
        gameObject.GetComponent<StatsComponent>().maxHP += 15f;
        gameObject.GetComponent<StatsComponent>().HP += 15f;

        yield return new WaitForSeconds(duration);

        gameObject.GetComponent<MoveComponent>().Speed /= 1.3f;
        gameObject.GetComponent<MoveComponent>().baseSpeed /= 1.3f;
        gameObject.GetComponent<StatsComponent>().maxHP -= 15f;
        if (gameObject.GetComponent<StatsComponent>().HP > 15f)
        {
            gameObject.GetComponent<StatsComponent>().HP -= 15f;
        }
        else
        {
            gameObject.GetComponent<StatsComponent>().HP = 1f;
        }
    }
}