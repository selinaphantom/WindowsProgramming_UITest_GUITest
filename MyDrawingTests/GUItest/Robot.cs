using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;

namespace MyDrawingTests.GUItest.Tests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {
                        // 忽略未找到的窗口，繼續嘗試
                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }
        public void MouseAction(string name, int X, int Y, int H, int W)
        {
            WindowsElement canvas = _driver.FindElementByAccessibilityId(name);
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.MoveToElement(canvas, 0, 0)    
                  .MoveByOffset((int)((X * 1.25)), (int)((Y * 1.25)))
                  .ClickAndHold()                          
                  .MoveByOffset((int)((W* 1.25)), (int)((H * 1.25)))  
                  .Release()                               
                  .Perform();
        }

        // test
        public void AssertChecked(string name, bool expected)
        {
            WindowsElement element = _driver.FindElementByName(name);
            string stateValue = element.GetAttribute("LegacyState");
            int state = int.Parse(stateValue);
            const int STATE_CHECKED = 0x4;
            Assert.AreEqual(expected, (state & STATE_CHECKED) == STATE_CHECKED);
        }
        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertDataGridViewRowDataBy(string name, int rowIndex,int Index, string data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node

            Assert.AreEqual(data, rowDatas[Index].Text.Replace("(null)", ""));

        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }
        public void SetText(string elementId, string text)
        {
            // 找到輸入框元素
            if (elementId == "") {
                Clipboard.SetText(text);
                SendKeys.SendWait("^v");
                return;
            }
            WindowsElement inputElement = _driver.FindElementByAccessibilityId(elementId);

            // 清空輸入框並輸入資料
            inputElement.Clear();
            Clipboard.SetText(text);
            SendKeys.SendWait("^v");
        }
        public void SelectDropdownOption(string comboBoxName, string optionText)
        {
            // 定位 ComboBox 元素
            WindowsElement comboBox = _driver.FindElementByName(comboBoxName);

            // 打開下拉選單
            comboBox.Click();

            // 定位選項並點擊
            var option = _driver.FindElementByName(optionText);
            option.Click();
        }
        public void ClickDataGridViewButton(string gridId, int rowIndex, string columnName)
        {
            // 初始化 WinAppDriver

            try
            {
                // 定位到 DataGridView
                WindowsElement dataGridView = _driver.FindElementByAccessibilityId(gridId);

                // 定位到目標按鈕
                string buttonXPath = $"//Custom[@Name='{gridId}']//DataItem[{rowIndex + 1}]//Button[@Name='{columnName}']";
                WindowsElement button = _driver.FindElementByXPath(buttonXPath);

                // 點擊按鈕
                button.Click();
            }
            catch (Exception ex)
            {

            }
        }
    }

}