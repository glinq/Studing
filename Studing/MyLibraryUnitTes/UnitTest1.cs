using Microsoft.VisualStudio.TestTools.UnitTesting;
using myLibrary;

namespace MyLibraryUnitTes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStartsWithUpper()
        {
            string[] strArr = new string[] { "gulinqian", "hello" };
            foreach (var item in strArr)
            {
                bool result = item.StartsWithUpper();
                Assert.IsFalse(result, $"测试成功，预计结果false，实际结果{result}，测试对象是{item}");
            }
        }

        [TestMethod]
        public void TestStartsWithUpper2()
        {
            string[] strArr = new string[] { "Gulinqian", "Hello" };
            foreach (var item in strArr)
            {
                bool result = item.StartsWithUpper();
                Assert.IsTrue(result, $"测试失败，预计结果true，实际结果{result}，测试对象是{item}");
            }
        }
    }
}
