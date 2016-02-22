﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CodedSelenium
{
    public class UITestControl
    {
        private readonly string ContainsCharacter = "*";
        private PropertyExpressionCollection searchProperties;

        public UITestControl()
        {
        }

        public UITestControl(UITestControl parent)
        {
            if (parent.WebElement == null)
            {
                this.Parent = parent.Parent;
            }
            else
            {
                this.Parent = parent.WebElement;
            }
        }

        public virtual bool Exists
        {
            get
            {
                return this.WebElement.Displayed;
            }
        }

        public PropertyExpressionCollection SearchProperties
        {
            get
            {
                if (this.searchProperties == null)
                {
                    this.searchProperties = new PropertyExpressionCollection();
                }

                return this.searchProperties;
            }
        }

        protected ISearchContext Parent { get; set; }

        protected virtual IWebElement WebElement
        {
            get
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                foreach (PropertyExpression searchProperty in this.SearchProperties)
                {
                    string key = searchProperty.PropertyName.ToLowerInvariant();

                    if (searchProperty.PropertyOperator == PropertyExpressionOperator.Contains)
                    {
                        key += this.ContainsCharacter;
                    }

                    dictionary.Add(key, searchProperty.PropertyValue);
                }

                string attributeTemplate = "[{0}=\"{1}\"]";
                IEnumerable<string> attributes = dictionary
                    .Where(item => item.Key != PropertyNames.TagName)
                    .Where(item => item.Key != PropertyNames.InnerText)
                    .Select(item => string.Format(attributeTemplate, item.Key, item.Value));

                IWebElement webElement = null;

                if (dictionary.ContainsKey(PropertyNames.InnerText))
                {
                    ReadOnlyCollection<IWebElement> matchingElements = this.Parent.FindElements(
                        By.CssSelector(dictionary[PropertyNames.TagName] + string.Join(string.Empty, attributes)));

                    if (dictionary[PropertyNames.InnerText].Contains(ContainsCharacter))
                        webElement = matchingElements.FirstOrDefault(item => item.Text.Contains(dictionary[PropertyNames.InnerText]));
                    else
                        webElement = matchingElements.FirstOrDefault(item => item.Text.Equals(dictionary[PropertyNames.InnerText]));
                }
                else
                {
                    webElement = this.Parent.FindElement(
                        By.CssSelector(dictionary[PropertyNames.TagName] + string.Join(string.Empty, attributes)));
                }

                return webElement;
            }
        }

        public virtual void Click()
        {
            this.WebElement.Click();
        }

        public abstract class PropertyNames
        {
            public static readonly string AccessKey = "accesskey";
            public static readonly string Class = "class";
            public static readonly string ControlDefinition = "controldefinition";
            public static readonly string HelpText = "helptext";
            public static readonly string Id = "id";
            public static readonly string InnerText = "innertext";
            public static readonly string TagInstance = "taginstance";
            public static readonly string Title = "title";
            public static readonly string Type = "type";
            public static readonly string ValueAttribute = "value";
            public static readonly string TagName = "tagname";

            [EditorBrowsable(EditorBrowsableState.Never)]
            public static new bool ReferenceEquals(object objA, object objB)
            {
                return true;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public static new bool Equals(object objA, object objB)
            {
                return true;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract override bool Equals(object obj);

            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract override int GetHashCode();

            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract new Type GetType();

            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract override string ToString();
        }
    }
}