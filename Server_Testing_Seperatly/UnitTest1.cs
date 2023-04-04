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

        /*LIAM'S USABILITY TESTS: DONT TOUCH UNTIL I MOVES IT TO DOC
         *MANUAL TESTED
        TESTING_SCREEN_RESOLUTION = PASSED
        TESTING_CLIENT_TO_SERVER_RESPONSE_TIME = time elapsed to transfer propmts averages 0.00001 ms when rounded  (ran the test 30 times) = PASSED
        TESTING_THE_TRANSITIONS_SMOOTH_PAGES = pages all work interactively with litlle delay, no noticable bugs with transitions and responsiveness = PASSED
        TESTING_TRANSITIONS_BETWEEN_PAGES_CLIENT =  the pages all work as intended includeing the slide out menu = PASSED
        TESTING_DATE_TIME_CORRECTION = the server is running in real time  = PASSED
        TESTING_THE_COMPATABILITY_ANDROID = 
        TESTING_THE_SCREEN_RESOLUTION_ANDROID = 

         **LIAM'S INTEGRATION TESTS: DONT TOUCH UNTIL I MOVE IT TO DOC
         *MANUAL TESTED
        TESTING_PAGES_ROUTING_MAINMENU_LOGIN = the pages were able to switch to the mainmenu from the login after the correct info was parsed = PASSED

         **LIAM'S SYSTEM TESTS: DONT TOUCH UNTIL I MOVE IT TO DOC
         *MANUAL TESTED
        TESTING_ENCRYPTED_REQUEST = the server is able to decrypt the prompts correctly = PASSED
        TESTING_BLACKLIST_CLIENT_ADD_FUNCTION = the client does get blacklisted from the server connection correctly (multiple clients can also be blacklisted correctly) = PASSED

        */

        [TestMethod]
        public void TEST_SERVER_API_OPENAI()
        {
            // Arrange
            string expected = "Paris";
            string prompt = "Whats the capital of France?";


            // Act
            string result = AI_API.callOpenAIText(prompt);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TEST_GENERATE_SOCKET()
        {
            // Arrange
           
            //ACT

            // Assert

        }
    }
}