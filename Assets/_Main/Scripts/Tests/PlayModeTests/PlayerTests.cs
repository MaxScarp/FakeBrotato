using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerTests
{
    [UnityTest]
    public IEnumerator IsSpawned()
    {
        //Arrange
        SceneManager.LoadScene("PlayerAndOneEnemyTestScene");
        yield return new WaitWhile(() => SceneManager.GetActiveScene().buildIndex != 1);

        //Act
        yield return new WaitForSeconds(1f);

        //Assert
        Assert.IsTrue(GameManager.GetPlayer() != null);
    }

    [TestFixture]
    public class Movement
    {
        [TestFixture]
        public class PositiveAxys
        {
            [UnityTest]
            public IEnumerator MoveRight()
            {
                //Arrange
                Player player = new GameObject().AddComponent<Player>();
                player.PlayerInput = Substitute.For<IPlayerInput>();

                //Act
                player.PlayerInput.MovementDirection.Returns(new Vector2(1f, 0f));

                yield return null;

                //Assert
                Assert.IsTrue(player.transform.position.x > 0f);
                Assert.IsTrue(player.transform.position.y == 0f);
            }

            [UnityTest]
            public IEnumerator MoveUp()
            {
                //Arrange
                Player player = new GameObject().AddComponent<Player>();
                player.PlayerInput = Substitute.For<IPlayerInput>();

                //Act
                player.PlayerInput.MovementDirection.Returns(new Vector2(0f, 1f));

                yield return null;

                //Assert
                Assert.IsTrue(player.transform.position.x == 0f);
                Assert.IsTrue(player.transform.position.y > 0f);
            }
        }

        [TestFixture]
        public class NegativeAxys
        {
            [UnityTest]
            public IEnumerator MoveLeft()
            {
                //Arrange
                Player player = new GameObject().AddComponent<Player>();
                player.PlayerInput = Substitute.For<IPlayerInput>();

                //Act
                player.PlayerInput.MovementDirection.Returns(new Vector2(-1f, 0f));

                yield return null;

                //Assert
                Assert.IsTrue(player.transform.position.x < 0f);
                Assert.IsTrue(player.transform.position.y == 0f);
            }

            [UnityTest]
            public IEnumerator MoveDown()
            {
                //Arrange
                Player player = new GameObject().AddComponent<Player>();
                player.PlayerInput = Substitute.For<IPlayerInput>();

                //Act
                player.PlayerInput.MovementDirection.Returns(new Vector2(0f, -1f));

                yield return null;

                //Assert
                Assert.IsTrue(player.transform.position.x == 0f);
                Assert.IsTrue(player.transform.position.y < 0f);
            }
        }
    }
}
