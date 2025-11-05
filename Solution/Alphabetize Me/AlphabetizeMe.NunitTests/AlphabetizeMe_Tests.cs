using AlphabetizeMe.ClassLibrary;

namespace AlphabetizeMe.NunitTests
{
    public class AlphabetizeMe_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertStreamToList_Test()
        {
            AlphabetizeMeApp app = new AlphabetizeMeApp();
            string testStream = "Test\r\nMe\r\nHere";
            app.ConvertStreamToList(testStream, "\r\n");
            if (app != null) { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void AlphabetizeMe_Test()
        {
            AlphabetizeMeApp app = new AlphabetizeMeApp();
            List<string> testList = new List<string>();
            testList.Add("Test"); 
            testList.Add("Me"); 
            testList.Add("Here");

            List<string> expectedResult = new List<string>();
            expectedResult.Add("Here");
            expectedResult.Add("Me");
            expectedResult.Add("Test");
            List<string> actualResult = app.AlphabetizeMe(testList);
            if (actualResult[0] == expectedResult[0]) { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void CheckUserInput_Good_Test()
        {
            AlphabetizeMeApp app = new AlphabetizeMeApp();
            string testStream = "Test\r\nMe\r\nHere";
            if (app.CheckUserInput(testStream)) { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void CheckUserInput_Bad_Test()
        {
            AlphabetizeMeApp app = new AlphabetizeMeApp();
            string testStream = "";
            if (!app.CheckUserInput(testStream)) { Assert.Pass(); } else { Assert.Fail(); }
        }
    }
}