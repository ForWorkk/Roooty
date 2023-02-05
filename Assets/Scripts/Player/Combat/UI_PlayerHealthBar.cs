using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerHealthBar : MonoBehaviour
{
    private RectTransform bar;

    [SerializeField] private PlayerCombatHandler combatHandler;

    private void Awake()
    {
        bar = transform.Find("Bar").GetComponent<RectTransform>();
    }

    private void Update()
    {
        bar.localScale = new Vector3(combatHandler.GetHealthPercentage(), bar.localScale.y, bar.localScale.z);
    }
}
