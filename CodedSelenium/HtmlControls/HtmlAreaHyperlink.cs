﻿namespace CodedSelenium.HtmlControls
{
    public class HtmlAreaHyperlink : HtmlControl
    {
        public HtmlAreaHyperlink()
        {
        }

        public HtmlAreaHyperlink(UITestControl parent)
          : base(parent)
        {
            SearchProperties.Add(HtmlControl.PropertyNames.TagName, "area");
        }

        public virtual string AbsolutePath
        {
            get
            {
                return WebElement.GetAttribute(HtmlHyperlink.PropertyNames.AbsolutePath);
            }
        }

        public virtual string Alt
        {
            get
            {
                return WebElement.GetAttribute(HtmlHyperlink.PropertyNames.Alt);
            }
        }

        public virtual string Href
        {
            get
            {
                return WebElement.GetAttribute(HtmlHyperlink.PropertyNames.Href);
            }
        }

        public virtual string Target
        {
            get
            {
                return WebElement.GetAttribute(HtmlHyperlink.PropertyNames.Target);
            }
        }

        public abstract new class PropertyNames : HtmlControl.PropertyNames
        {
            public static readonly string AbsolutePath = "absolutepath";
            public static readonly string Alt = "alt";
            public static readonly string Href = "href";
            public static readonly string Target = "target";
        }
    }
}
