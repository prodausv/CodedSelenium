using CodedSelenium.HtmlControls;
using FluentAssertions;
using NUnit.Framework;

namespace CodedSelenium.Test
{
    [TestFixture]
    public class HtmlTableTest : BasicTest
    {
        [Test]
        public void HtmlTableTest_NoSearchProperties()
        {
            HtmlTable table = new HtmlTable(BrowserWindow);

            table.Id.Should().Be("firstTable");
        }

        [Test]
        public void HtmlTableTest_ById()
        {
            HtmlTable table = new HtmlTable(BrowserWindow);
            table.SearchProperties.Add(HtmlTable.PropertyNames.Id, "secondTable");

            table.Class.Should().Be("secondTableClass");
        }

        [Test]
        public void HtmlTableTest_ByClass()
        {
            HtmlTable table = new HtmlTable(BrowserWindow);
            table.SearchProperties.Add(HtmlTable.PropertyNames.Class, "secondTableClass");

            table.Id.Should().Be("secondTable");
        }

        [Test]
        public void HtmlTableTest_ByInnerText()
        {
            HtmlTable table = new HtmlTable(BrowserWindow);
            table.SearchProperties.Add(HtmlTable.PropertyNames.InnerText, "113", PropertyExpressionOperator.Contains);

            table.Id.Should().Be("secondTable");
        }

        [Test]
        public void HtmlTableTest_ByInstance()
        {
            HtmlTable table = new HtmlTable(BrowserWindow);
            table.SearchProperties.Add(HtmlTable.PropertyNames.Instance, "3");

            table.Id.Should().Be("microTable");
        }

        [Test]
        [ExpectedException("CodedSelenium.UITestControlNotFoundException")]
        public void HtmlTableTest_Negative_ByInstance()
        {
            HtmlRow row = new HtmlRow(BrowserWindow); 
            HtmlTable table = new HtmlTable(row);
            table.SearchProperties.Add(HtmlTable.PropertyNames.Instance, "10");

            table.InnerText.Should().Be("Exception");
        }

        [Test]
        public void HtmlTableTest_ByTagInstance()
        {
            HtmlRow row = new HtmlRow(BrowserWindow);
            HtmlTable table = new HtmlTable(row); // TagInstance ignores parent
            table.SearchProperties.Add(HtmlTable.PropertyNames.TagInstance, "3");

            table.Id.Should().Be("microTable");
        }

        //TODO: Add method tests
    }
}
