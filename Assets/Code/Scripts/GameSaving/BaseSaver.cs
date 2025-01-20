using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSaver : ButMonobehavior
{
    public abstract void LoadData();
    public abstract void SaveData();
}