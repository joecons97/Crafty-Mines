﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Block 
{
    public override string Name
    {
        get
        {
            return "Stone";
        }
    }

    public override int BlockID
    {
        get
        {
            return 3;
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
            return Face.GetFromIndex(1, 0);
        }
    }

    public override Face BackFaceUV
    {
        get
        {
            return Face.GetFromIndex(1, 0);
        }
    }

    public override Face TopFaceUV
    {
        get
        {
            return Face.GetFromIndex(1, 0);
        }
    }

    public override Face BottomFaceUV
    {
        get
        {
            return Face.GetFromIndex(1, 0);
        }
    }

    public override Face LeftFaceUV
    {
        get
        {
            return Face.GetFromIndex(1, 0);
        }
    }

    public override Face RightFaceUV
    {
        get
        {
            return Face.GetFromIndex(1, 0);
        }
    }
}
