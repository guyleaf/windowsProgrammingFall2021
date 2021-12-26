using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interactions;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace DrawingFormUITests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:8000";
        private const double TIME_FOR_MOVING_POINTER = 1;

        // constructor
        public Robot(string targetAppPath, string root)
        {
            Initialize(targetAppPath, root);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="targetAppPath"></param>
        /// <param name="root"></param>
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
                { 
                    _root, _driver.CurrentWindowHandle } };
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        /// <summary>
        /// 切換畫面
        /// </summary>
        /// <param name="formName"></param>
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

        /// <summary>
        /// Delay
        /// </summary>
        /// <param name="time"></param>
        public void Sleep(double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        /// <summary>
        /// 點擊按鈕
        /// </summary>
        /// <param name="name"></param>
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        /// <summary>
        /// 關閉視窗
        /// </summary>
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        /// <summary>
        /// 按住並拖曳
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DragAndDrop(string name, int x1, int y1, int x2, int y2)
        {
            var canvas = _driver.FindElementByName(name);
            int halfWidth = canvas.Size.Width / 2;
            int halfHeight = canvas.Size.Height / 2;

            x1 -= halfWidth;
            y1 -= halfHeight;
            x2 -= halfWidth;
            y2 -= halfHeight;

            List<ActionSequence> actionSequencesList = new List<ActionSequence>();
            var touchContact = new OpenQA.Selenium.Appium.Interactions.PointerInputDevice(PointerKind.Touch);
            var touchSequence = new ActionSequence(touchContact, 0);
            touchSequence.AddAction(touchContact.CreatePointerMove(canvas, x1, y1, TimeSpan.Zero));
            touchSequence.AddAction(touchContact.CreatePointerDown(PointerButton.LeftMouse));
            touchSequence.AddAction(touchContact.CreatePointerMove(canvas, x2, y2, TimeSpan.FromSeconds(TIME_FOR_MOVING_POINTER)));
            touchSequence.AddAction(touchContact.CreatePointerUp(PointerButton.LeftMouse));
            actionSequencesList.Add(touchSequence);

            _driver.PerformActions(actionSequencesList);
        }

        /// <summary>
        /// 取得元件寬度
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetElementWidth(string name)
        {
            var element = _driver.FindElementByName(name);
            return element.Size.Width;
        }

        /// <summary>
        /// 取得元件高度
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetElementHeight(string name)
        {
            var element = _driver.FindElementByName(name);
            return element.Size.Height;
        }
    }
}
