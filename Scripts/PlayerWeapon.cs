using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public bool tapToKill;
    public bool swipeToKill;

    public bool IsSwipeToKill() {
        return swipeToKill;
    }

    public bool IsTapToKill() {
        return tapToKill;
    }
}
