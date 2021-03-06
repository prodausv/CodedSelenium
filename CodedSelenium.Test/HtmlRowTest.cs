﻿using CodedSelenium.HtmlControls;
using FluentAssertions;
using NUnit.Framework;

namespace CodedSelenium.Test
{
    [TestFixture]
    public class HtmlRowTest : BasicTest
    {
        [Test]
        public void HtmlRowTest_ById()
        {
            HtmlRow row = new HtmlRow(BrowserWindow);
            row.SearchProperties.Add(HtmlRow.PropertyNames.Id, "rowWithId");

            row.InnerText.Should().Be("Item 102 Item 112");
        }

        [Test]
        public void HtmlRowTest_ByInnerText()
        {
            HtmlRow row = new HtmlRow(BrowserWindow);
            row.SearchProperties.Add(HtmlRow.PropertyNames.InnerText, "Item 112", PropertyExpressionOperator.Contains);

            row.InnerText.Should().Be("Item 102 Item 112");
        }

        [Test]
        public void HtmlRowTest_ByRowIndex()
        {
            HtmlRow row = new HtmlRow(BrowserWindow);
            row.SearchProperties.Add(HtmlRow.PropertyNames.RowIndex, "2");

            row.InnerText.Should().Be("Item 001 Item 011");
        }

        [Test]
        public void HtmlRowTest_ByRowIndex_FindMatchingControls()
        {
            HtmlRow row = new HtmlRow(BrowserWindow);
            row.SearchProperties.Add(HtmlRow.PropertyNames.RowIndex, "2");

            row.FindMatchingControls()[1].InnerText.Should().Be("Item 102 Item 112");
        }

        [Test]
        public void HtmlRowTest_GetContent()
        {
            HtmlRow row = new HtmlRow(BrowserWindow);
            row.SearchProperties.Add(HtmlRow.PropertyNames.Id, "rowWithId");

            row.GetContent().Should().Equal("Item 102", "Item 112");
        }

        [Test]
        public void HtmlRowTest_Cells()
        {
            HtmlRow row = new HtmlRow(BrowserWindow);
            row.SearchProperties.Add(HtmlRow.PropertyNames.Id, "rowWithId");

            row.Cells.Should().HaveCount(2);
            row.Cells.GetValuesOfControls().Should().Equal("Item 102", "Item 112");
        }

        [Test]
        public void HtmlRowTest_GetCells()
        {
            HtmlRow row = new HtmlRow(BrowserWindow);
            row.SearchProperties.Add(HtmlRow.PropertyNames.Id, "rowWithId");

            row.GetCell(1).InnerText.Should().Be("Item 102");
            row.GetCell(2).InnerText.Should().Be("Item 112");
        }
    }
}
