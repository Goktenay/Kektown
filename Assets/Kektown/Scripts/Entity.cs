﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    public abstract void Move(Vector3 dir);
    public abstract void Interract();
    public abstract void Jump();
    public abstract void Attack();
    



}
