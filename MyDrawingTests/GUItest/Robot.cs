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
        public void ComboBoxSelect(string name, string itemName)
        {
            WindowsElement comboBox = _driver.FindElementByAccessibilityId(name);
            comboBox.Click();
            WindowsElement item = _driver.FindElementByName(itemName);
            item.Click();
        }
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }
        public void MouseDoubleClick(string name, int x, int y)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.MoveToElement(element, x, y).DoubleClick().Perform();
        }
        public void WaitAutoSaving()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.WindowHandles.Count > 0);

            if (_driver.WindowHandles.Count > 0)
            {
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            }
            else
            {
                throw new InvalidOperationException("視窗未重新出現");
            }
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            try
            {
                Console.WriteLine("清理過程開始");
                Console.WriteLine($"當前視窗數量：{_driver.WindowHandles.Count}");

                if (_driver.WindowHandles.Count > 0)
                {
                    foreach (string handle in _driver.WindowHandles)
                    {
                        _driver.SwitchTo().Window(handle);
                        Console.WriteLine($"當前視窗標題：{_driver.Title}");
                    }

                    _driver.SwitchTo().Window(_driver.WindowHandles[0]); // 切換到第一個視窗
                    _driver.Close(); // 關閉視窗
                }
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine($"清理失敗：{ex.Message}");
            }
            finally
            {
                _driver.Quit(); // 確保釋放資源
                Console.WriteLine("測試結束並清理完成");
            }
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
                    }
                }
            }
        }

        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }
        public void SetBoxValue(string name, string input)
        {
            var textBox = _driver.FindElementByAccessibilityId(name);
            textBox.Clear(); // 清除現有文本
            textBox.SendKeys(input); // 輸入新值
        }
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        public void MouseAction(string name, int X, int Y, int H, int W)
        {
            WindowsElement canvas = _driver.FindElementByAccessibilityId(name);
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.MoveToElement(canvas, 0, 0)
                  .MoveByOffset((int)((X * 1.25)), (int)((Y * 1.25)))
                  .ClickAndHold()
                  .MoveByOffset((int)((W * 1.25)), (int)((H * 1.25)))
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
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string shapeName, int x, int y, int width, int height)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            Assert.AreEqual(shapeName, rowDatas[3].Text);
            Assert.AreEqual(x, int.Parse(rowDatas[5].Text));
            Assert.AreEqual(y, int.Parse(rowDatas[6].Text));
            Assert.AreEqual(width, int.Parse(rowDatas[7].Text));
            Assert.AreEqual(height, int.Parse(rowDatas[8].Text));
        }
        public void AssertDataGridViewRowDataByText(string name, int rowIndex, string Text)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            Assert.AreEqual(Text, rowDatas[4].Text);
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
            if (elementId == "")
            {
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
            catch (Exception)
            {

            }
        }
    }

}