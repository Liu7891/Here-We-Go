using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet") || collision.CompareTag("Enemy"))
        {
            //游戏结束
            print("GAMEOVER");
            SceneManager.LoadScene(0);
        }
    }
}
