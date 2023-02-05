using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BossHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyCombatHandler combatHandler;

    private RectTransform bar;

    private void Awake()
    {
        bar = transform.Find("Bar").GetComponent<RectTransform>();
    }

    private void Update()
    {
        bar.localScale = new Vector3(0.2f, bar.localScale.y, bar.localScale.z);
        bar.localScale = new Vector3(combatHandler.GetHealthPercentage(), bar.localScale.y, bar.localScale.z);
    }
}
