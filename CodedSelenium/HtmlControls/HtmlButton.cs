﻿namespace CodedSelenium.HtmlControls
{
    public class HtmlButton : HtmlControl
    {
        public HtmlButton()
        {
        }

        public HtmlButton(UITestControl parent)
            : base(parent)
        {
            SearchProperties.Add(HtmlButton.PropertyNames.TagName, "button");
        }
    }
}
