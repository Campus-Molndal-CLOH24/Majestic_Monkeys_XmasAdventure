using Xmasgame.Data;

namespace Xmasgame.Tests
{
    [TestClass]
    public class Playertests
    {
        private Player _player;
        private Items _magicItem;

        [TestInitialize]
        public void Setup() 
        {
            _player = new Player("TestLisa");
            _magicItem = new Items(1,"Magisk Klocka", true,"Ringer själv vid midnatt");
           

        }
        //seanario : Initial Inventory is empty and player's name is set (edge case)
        [TestMethod]
        [DataRow("Lisa")]
        [DataRow("John")]
        [DataRow("Jane")]
        [DataRow("")]
        [DataRow(null)]
        public void Player_ShouldInitializeWithGivenNameAndEmptyInventory(string expectedName)
        {
            ;
            //act
            var player = new Player(expectedName);

            //assert
            Assert.AreEqual(expectedName, player.name, "Player name was not set correctly");
            Assert.AreEqual(0, player.Inventory.Count, "Inventory should start with emptry");
        }
        [TestMethod]
        public void AddItem_whenInventoryNotFull_ReturnsTrue()
        {
            //act
            var result = _player.AddItem(_magicItem);

            //assert
            Assert.IsTrue(result, "Tomten måste kunna bära några presenter!");
            Assert.AreEqual(1, _player.Inventory.Count, "Inventory count should be 1 after adding an item.");
            
            
            CollectionAssert.Contains(_player.Inventory, _magicItem);
        }
        //seanario : player's inventory is full
        [TestMethod]
        public void AddItem_whenInventoryIsFull_ReturnsFalse()
        {
            //arrange
            for (int i = 0; i <= 8; i++)
            {
                _player.AddItem(new Items(i, $"Item {i}", false, "Description"));
            }
            //act
            var result = _player.AddItem(_magicItem);

            //assert
            Assert.IsFalse(result, "Ho ho NO! Tomten kan inte bära oändligt många saker!");
            Assert.AreEqual(8, _player.Inventory.Count, "Inventory count should be 8 when inventory is full!.");
            
        }
        //seanario : Add Multiple Items to Inventory
        [TestMethod]
        public void AddItem_addMultiple_MacthwithInventoryCount()
        {
            //arrange
            var item1 = new Items(1, "Item 1", false, "Description 1");
            var item2 = new Items(2, "Item 2", false, "Description 2");
            var item3 = new Items(3, "Item 3", false, "Description 3");

            //act
            _player.AddItem(item1);
            _player.AddItem(item2);
            _player.AddItem(item3);

            //assert
            Assert.AreEqual(3, _player.Inventory.Count, "Inventory count should be 3 after adding 3 items.");
            CollectionAssert.Contains(_player.Inventory, item1);
            CollectionAssert.Contains(_player.Inventory, item2);
            CollectionAssert.Contains(_player.Inventory, item3);
        }

        //seanario : Null item handling
        [TestMethod]
        public void AddItem_shouldHandleNullWithGracefully()
        {
            //act
            var result = _player.AddItem(null);

            //assert
            Assert.IsFalse(result, "can not adding null ");
            Assert.AreEqual(0, _player.Inventory.Count, "Inventory count should remain 0 when null is added.");

        }

    }
}