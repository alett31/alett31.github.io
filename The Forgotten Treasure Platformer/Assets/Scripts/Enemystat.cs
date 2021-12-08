using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystat : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
	{
		public int maxHealth;

		private int _curHealth;
		public int curHealth;
    
        
    }

	public EnemyStats stats = new EnemyStats();

    public void DamageEnemy (int damage)
    {
		stats.curHealth -= damage;
		if (stats.Health <= 0);
		
    }
}
