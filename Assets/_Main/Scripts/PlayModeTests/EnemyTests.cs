using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

[TestFixture]
public class EnemyTests
{
    [TestFixture]
    public class Spawn
    {
        //TODO test once the SpawnManager is on
        //[UnityTest]
        //public IEnumerator IsSpawned()
        //{
        //    //Arrange
        //    SceneManager.LoadScene("PlayerAndOneEnemySpawnerTestScene");
        //    yield return new WaitWhile(() => SceneManager.GetActiveScene().buildIndex != 2);
        //    EnemySpawner enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        //    //Act
        //    yield return new WaitForSeconds(2f);


        //    //Assert
        //    Assert.AreEqual(1, GameManager.EnemyTotalAmount);
        //}
    }

    [TestFixture]
    public class Movement
    {
        [UnityTest]
        public IEnumerator IsMoving()
        {
            //Arrange
            SceneManager.LoadScene("PlayerAndOneEnemyTestScene");
            yield return new WaitWhile(() => SceneManager.GetActiveScene().buildIndex != 1);
            Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
            Vector3 enemyStartingPos = enemy.transform.position;

            //Act
            yield return new WaitForSeconds(1f);

            //Assert
            Assert.IsFalse(enemy.transform.position == enemyStartingPos);
        }
    }

    [TestFixture]
    public class Collision
    {
        [UnityTest]
        public IEnumerator WithPlayer()
        {
            //Arrange
            SceneManager.LoadScene("PlayerAndOneEnemyTestScene");
            yield return new WaitWhile(() => SceneManager.GetActiveScene().buildIndex != 1);
            Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

            //Act
            yield return new WaitForSeconds(5f);

            //Assert
            if (enemy != null)
            {
                Assert.Fail("Enemy is still alive!");
            }
        }
    }
}
