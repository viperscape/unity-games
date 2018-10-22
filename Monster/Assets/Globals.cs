using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals  {
    public static MonsterSelect.MonsterKind MonsterKind { get; set; }
    public static Camera Cam { get; set; }

    public static GameObject GetMonster()
    {
        GameObject monster;

        if (MonsterKind == MonsterSelect.MonsterKind.Bat)
        {
            monster = GameObject.Find("Bat");
        }
        else if (MonsterKind == MonsterSelect.MonsterKind.Slime)
        {
            monster = GameObject.Find("Slime");
        }
        else
        {
            monster = GameObject.Find("Rabbit");
        }

        return monster;
    }
}
