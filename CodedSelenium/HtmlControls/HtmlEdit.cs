﻿namespace CodedSelenium.HtmlControls
{
    public class HtmlEdit : HtmlTextControl
    {
        public HtmlEdit()
        {
        }

        public HtmlEdit(UITestControl parent)
            : base(parent)
        {
            SearchProperties.Add(HtmlButton.PropertyNames.TagName, "input");
        }

        public virtual bool IsPassword
        {
            get
            {
                return this.WebElement.GetAttribute(HtmlEdit.PropertyNames.Type).Equals("password");
            }
        }

        public virtual string DefaultText
        {
            get
            {
                return this.WebElement.GetAttribute(HtmlEdit.PropertyNames.DefaultText);
            }
        }

        public virtual string Password
        {
            set
            {
                this.Text = value;
            }
        }

        public virtual int MaxLength
        {
            get
            {
                string value = this.WebElement.GetAttribute(HtmlEdit.PropertyNames.MaxLength);
                return int.Parse(value);
            }
        }

        public abstract new class PropertyNames : HtmlControl.PropertyNames
        {
            public static readonly string Text = "text";
            public static readonly string IsPassword = "ispassword";
            public static readonly string Password = "password";
            public static readonly string DefaultText = "value";
            public static readonly string CopyPastedText = "copypastedtext";
            public static readonly string LabeledBy = "labeledby";
            public static readonly string ReadOnly = "readonly";
            public static readonly string MaxLength = "maxlength";
        }
    }
}
