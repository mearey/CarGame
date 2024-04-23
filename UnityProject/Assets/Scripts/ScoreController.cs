using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public CarController carCon;
    public int score = 0;
    public UIManager uim;
    public int combo = 0;
    public int driftTimer = 100;
    public int comboTimer = 250;
    public int airbornTimer = 100;
    public Slider comboBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //increase score based on drifting and airborn and boosting
        if (carCon.boosting)
        {
            comboTimer = 250;
            score += 1;
        }
        if (carCon.driftingBool)
        {
            comboTimer = 250;
            score += 5;
            if (driftTimer > 0) 
            {
                driftTimer -= 1;
            }
        } else
        {
            if (driftTimer == 0)
            {
                driftTimer = 100;
                combo += 1;
            }
        }

        if (carCon.airborn)
        {
            comboTimer = 250;
            score += 10;
            if (airbornTimer > 0)
            {
                airbornTimer -= 1;
            }
        } else
        {
            if (airbornTimer == 0)
            {
                airbornTimer = 100;
                combo += 1;
            }
        }

        if (!carCon.driftingBool && !carCon.airborn)
        {
            if (comboTimer > 0)
            {
                comboTimer -= 1;
            }
            if (comboTimer == 0)
            {
                if (combo > 0)
                {
                    combo -= 1;
                }
                comboTimer = 100;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update text for score
        uim.changeText
        (
        "Score: " + score + "\n" +
        "Combo: " + combo
        );

        //set combo bar value
        comboBar.value = comboTimer/250f;
    }
}
