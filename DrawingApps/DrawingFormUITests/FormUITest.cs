using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFormUITests
{
    [TestClass]
    public class FormUITest
    {
        private const string FORM_PROJECT_NAME = "DrawingForm";
        private const string FORM_TITLE = "DrawingForm";
        private const string RECTANGLE_BUTTON_NAME = "Rectangle";
        private const string ELLIPSE_BUTTON_NAME = "Ellipse";
        private const string CLEAR_BUTTON_NAME = "Clear";
        private const string CANVAS_NAME = "Canvas";

        private Robot _robot;

        public FormUITest()
        {

        }

        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            var solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var formExePath = Path.Combine(solutionPath, FORM_PROJECT_NAME, "bin", "Debug", FORM_PROJECT_NAME + ".exe");
            _robot = new Robot(formExePath, FORM_TITLE);
        }

        /// <summary>
        /// 畫圖形
        /// </summary>
        [DataTestMethod]
        [DataRow(RECTANGLE_BUTTON_NAME, DisplayName = "Draw a rectangle")]
        [DataRow(ELLIPSE_BUTTON_NAME, DisplayName = "Draw an ellipse")]
        public void TestDrawingShapes(string buttonName)
        {
            _robot.ClickButton(buttonName);
            _robot.DragAndDrop(CANVAS_NAME, 50, 50, 300, 400);
            _robot.Sleep(1);
        }

        /// <summary>
        /// 測試 Clear 功能
        /// </summary>
        [TestMethod]
        public void TestClear()
        {
            TestDrawingShapes(RECTANGLE_BUTTON_NAME);
            _robot.ClickButton(RECTANGLE_BUTTON_NAME);
            _robot.Sleep(1);
            _robot.ClickButton(CLEAR_BUTTON_NAME);
            _robot.Sleep(1);
        }

        /// <summary>
        /// 測試畫出一個雪人
        /// </summary>
        [TestMethod]
        public void TestDrawingASnowMan()
        {
            var canvasHalfWidth = _robot.GetElementWidth(CANVAS_NAME) / 2;
            var canvasHalfHeight = _robot.GetElementHeight(CANVAS_NAME) / 2;

            DrawEllipsesForSnowMan(canvasHalfWidth, canvasHalfHeight);
            DrawRectanglesForSnowMan(canvasHalfWidth, canvasHalfHeight);
            _robot.Sleep(2);
        }

        /// <summary>
        /// 畫雪人的橢圓形
        /// </summary>
        /// <param name="canvasHalfWidth"></param>
        /// <param name="canvasHalfHeight"></param>
        private void DrawEllipsesForSnowMan(int canvasHalfWidth, int canvasHalfHeight)
        {
            _robot.ClickButton(ELLIPSE_BUTTON_NAME);

            var diameter = 300;
            var topLeftX = canvasHalfWidth - diameter / 2;
            var topLeftY = canvasHalfHeight - diameter / 2;
            var bottomRightX = topLeftX + diameter;
            var bottomRightY = topLeftY + diameter;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);

            topLeftX += diameter / 2;
            topLeftY += diameter / 2;
            diameter = 40;
            topLeftX -= diameter / 2;
            topLeftY -= diameter / 2;
            bottomRightX = topLeftX + diameter;
            bottomRightY = topLeftY + diameter;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);

            topLeftY -= (int)(diameter * 1.5);
            bottomRightY = topLeftY + diameter;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);

            topLeftX += diameter / 2;
            topLeftY -= diameter / 2;
            diameter = 180;
            topLeftX -= diameter / 2;
            topLeftY -= diameter;
            bottomRightX = topLeftX + diameter;
            bottomRightY = topLeftY + diameter;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);

            topLeftX += diameter / 2;
            topLeftY += diameter / 5;
            DrawEyeForSnowMan(topLeftX - 50, topLeftY);
            DrawEyeForSnowMan(topLeftX + 20, topLeftY);
        }

        /// <summary>
        /// 畫雪人的眼睛
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="diameter"></param>
        private void DrawEyeForSnowMan(int topLeftX, int topLeftY)
        {
            var diameter = 30;
            var bottomRightX = topLeftX + diameter;
            var bottomRightY = topLeftY + diameter;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);
        }

        /// <summary>
        /// 畫雪人的長方形
        /// </summary>
        /// <param name="canvasHalfWidth"></param>
        /// <param name="canvasHalfHeight"></param>
        private void DrawRectanglesForSnowMan(int canvasHalfWidth, int canvasHalfHeight)
        {
            _robot.ClickButton(RECTANGLE_BUTTON_NAME);

            var topLeftX = canvasHalfWidth - 80;
            var topLeftY = 30;
            var bottomRightX = topLeftX + 160;
            var bottomRightY = topLeftY + 50;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);

            topLeftX -= 30;
            topLeftY = bottomRightY;
            bottomRightX += 30;
            bottomRightY += 20;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);

            var squareWidth = 32;
            topLeftX = canvasHalfWidth - squareWidth / 2;
            topLeftY += 90;
            bottomRightX = topLeftX + squareWidth;
            bottomRightY = topLeftY + squareWidth;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);

            var handWidth = 15;
            var handHeight = 200;
            topLeftX = canvasHalfWidth - 150 - handWidth;
            topLeftY = canvasHalfHeight - handHeight;
            bottomRightX = topLeftX + handWidth;
            bottomRightY = canvasHalfHeight;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);

            topLeftX = canvasHalfWidth + 150;
            bottomRightX = topLeftX + handWidth;

            _robot.DragAndDrop(
                CANVAS_NAME, topLeftX, topLeftY, bottomRightX, bottomRightY);
            _robot.Sleep(0.3);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }
    }
}
