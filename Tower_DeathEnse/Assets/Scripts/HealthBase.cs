using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : MonoBehaviour
{
    public GameManager gameManager;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text money;
    int argent;
    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        money = GetComponent<Text>();
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void DisplayMoney()
    {
         argent = gameManager.GetMoney();
        Debug.Log(argent);
         //money.text = argent.ToString();
    }
    private void Update()
    {
        DisplayMoney();
    }
}
