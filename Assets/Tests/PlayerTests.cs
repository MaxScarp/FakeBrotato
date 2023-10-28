using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerTests
{
    [TestFixture]
    public class Movement
    {
        [TestFixture]
        public class PositiveAxys
        {
            [UnityTest]
            public IEnumerator GivenPositiveHorizontalAxys_ShouldMoveRight()
            {
                //Arrange
                Player player = new GameObject().AddComponent<Player>();
                player.PlayerInput = Substitute.For<IPlayerInput>();
                player.MoveSpeed = 1f;

                //Act
                player.PlayerInput.MovementDirection.Returns(new Vector2(1f, 0f));

                yield return null;

                //Assert
                Assert.IsTrue(player.transform.position.x > 0f);
                Assert.IsTrue(player.transform.position.y == 0f);
            }

            [UnityTest]
            public IEnumerator GivenPositiveVerticalAxys_ShouldMoveUp()
            {
                //Arrange
                Player player = new GameObject().AddComponent<Player>();
                player.PlayerInput = Substitute.For<IPlayerInput>();
                player.MoveSpeed = 1f;

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
            public IEnumerator GivenNegativeHorizontalAxys_ShouldMoveLeft()
            {
                //Arrange
                Player player = new GameObject().AddComponent<Player>();
                player.PlayerInput = Substitute.For<IPlayerInput>();
                player.MoveSpeed = 1f;

                //Act
                player.PlayerInput.MovementDirection.Returns(new Vector2(-1f, 0f));

                yield return null;

                //Assert
                Assert.IsTrue(player.transform.position.x < 0f);
                Assert.IsTrue(player.transform.position.y == 0f);
            }

            [UnityTest]
            public IEnumerator GivenNegativeVerticalAxys_ShouldMoveDown()
            {
                //Arrange
                Player player = new GameObject().AddComponent<Player>();
                player.PlayerInput = Substitute.For<IPlayerInput>();
                player.MoveSpeed = 1f;

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
