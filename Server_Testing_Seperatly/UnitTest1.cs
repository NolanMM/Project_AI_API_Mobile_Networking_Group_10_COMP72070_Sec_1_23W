using server;

namespace Server_Testing_Seperatly
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int index_Worksheet = 1;
            string key = "key_test";
            string encrypted_data = "_Write_To_Excel_By_Worksheets_Index_Server_Test";
            bool result = false;

            // Act
            result = ExcelApiTest.Write_To_Excel_By_Worksheets_Index_Server(index_Worksheet, key, encrypted_data);

            // Assert
            Assert.IsFalse(result);
        }
    }
}