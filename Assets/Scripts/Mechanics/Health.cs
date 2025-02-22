using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 1;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP;

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        /*public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            if (currentHP == 0)
            {
                if(gameObject.CompareTag("Player")) {
                    Schedule<PlayerDeath>();
                }
                else if(gameObject.CompareTag("Enemy")) {
                    var ev = Schedule<EnemyDeath>();
                    ev.enemy = gameObject.GetComponent<EnemyController>();
                }
            }
        }*/

        public void Decrement(int damage = 1) {
            currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);
            if (currentHP == 0)
            {
                if(gameObject.CompareTag("Player")) {
                    Schedule<PlayerDeath>();
                }
                else if(gameObject.CompareTag("Enemy")) {
                    var ev = Schedule<EnemyDeath>();
                    ev.enemy = gameObject.GetComponent<EnemyController>();
                }
            }
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        public void Restore() {
            currentHP = maxHP;
        }

        void Awake()
        {
            currentHP = maxHP;
        }
    }
}
