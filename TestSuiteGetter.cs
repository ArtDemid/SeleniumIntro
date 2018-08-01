using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SeleniumWebDriverIntro
{
    class TestSuiteGetter
    {
        XmlDocument testSuiteDoc = new XmlDocument();

        Test test;
        //List<int> tests = new List<int>();
        List<Test> testset = new List<Test>();

        private void GetTestsFromXml()
        {
            testSuiteDoc.Load("testsuite.xml");
            XmlElement root = testSuiteDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("test");
            foreach (XmlNode node in nodes)
            {
                string status = node["status"].InnerText;
                string name = node["name"].InnerText;
                string id = node["id"].InnerText;
                List<object> testDatas = new List<object>();
                XmlNode dataRoot = node.SelectSingleNode("datas");
                XmlNodeList dataNodes = dataRoot.SelectNodes("data");

                if (status == "Ready for test")
                {
                    foreach (XmlNode dataNode in dataNodes)
                    {
                        object data = dataNode.InnerText;
                        testDatas.Add(data);
                    }

                    int testId = Convert.ToInt32(id);
                    test = new Test(testId, name, testDatas);
                    //tests.Add(testId);
                    testset.Add(test);
                }                
            }
        }

        public List<Test> DefineTestSet()
        {
            GetTestsFromXml();
            return testset;
        }
    }
}
