using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    public static int StepIndex(bool isNext_ifNotPrevious, int current, int length)
    {// Ensure to give back a correct index when going step forward/Backward
        switch (isNext_ifNotPrevious)
        {
            case true:
                int nextIndex = (current % length) + 1;
                switch (nextIndex >= length || nextIndex < 0 )
                {
                    case true:
                        return length - 1;
                    case false:
                        return nextIndex;
                }

            case false:
                int previousIndex = (current % length) - 1;
                switch (previousIndex >= length || previousIndex < 0)
                {
                    case true:
                        return 0;
                    case false:
                        return previousIndex;
                }
        }
    }
}
