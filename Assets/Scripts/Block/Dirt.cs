﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : Block 
{
    public override string Name
    {
        get
        {
            return "Dirt";
        }
    }

    public override int BlockID
    {
        get
        {
            return 1;
        }
    }

    public override bool IsStackable
    {
        get
        {
            return true;
        }
    }

    public override Face FrontFaceUV
    {
        get
        {
            return Face.GetFromIndex(2, 0);
        }
    }

    public override Face BackFaceUV
    {
        get
        {
            return Face.GetFromIndex(2, 0);
        }
    }

    public override Face TopFaceUV
    {
        get
        {
            return Face.GetFromIndex(2, 0);
        }
    }

    public override Face BottomFaceUV
    {
        get
        {
            return Face.GetFromIndex(2, 0);
        }
    }

    public override Face LeftFaceUV
    {
        get
        {
            return Face.GetFromIndex(2, 0);
        }
    }

    public override Face RightFaceUV
    {
        get
        {
            return Face.GetFromIndex(2, 0);
        }
    }
}
