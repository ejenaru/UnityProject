using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxValue;
    private int actualValue;

    // Start is called before the first frame update
    void Start()
    {
        actualValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualValue <= 0) GameManager.manager.KillPlayer();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Spikes"))
            GameManager.manager.KillPlayer();
    }

    public void ReturnToHalfLife()
    {
        actualValue = maxValue / 2;
    }
}
