using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attacks
{
    public class Attack : MonoBehaviour
    {
        #region Variables

        //Attack States
        public enum AttackState
        { stateRed, stateBlue, stateBoth }

        [SerializeField]
        public AttackState attackState;

        public bool isFromPlayer = false;

        public bool doesSwitchColor;

        public int meleeDamage = 3;

        public int bulletDamage = 2;

        public int shockwaveDamage = 2;

        #endregion Variables
    }
}