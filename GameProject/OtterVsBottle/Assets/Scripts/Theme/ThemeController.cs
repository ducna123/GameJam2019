using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThemeController : SingletonBind<ThemeController>
{ 
    public List<ThemeTree> themeTree = new List<ThemeTree>();
    public List<GameObject> bigTree = new List<GameObject>();
    public ThemeTree curTheme;

    public void Start() {
        curTheme = getTheme();
    }

    public ThemeTree getTheme() {
     
        return themeTree[Random.Range(0, themeTree.Count)];
    }
    public GameObject getRandomTree() {
        return curTheme.trees[Random.Range(0, curTheme.trees.Count)];
    }

    public GameObject GetRandomBigTree() {
        return bigTree[Random.Range(0, bigTree.Count)];
    }
}

[Serializable]
public class ThemeTree
{
    public List<GameObject> trees;
 
}
