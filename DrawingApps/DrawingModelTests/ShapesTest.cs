using DrawingModel.Shapes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModelTests
{
    [TestClass]
    public class ShapesTest
    {
        private Rectangle _rectangle;
        private Ellipse _ellipse;

        public ShapesTest()
        {
        }

        /// <summary>
        /// 測試初始化
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _rectangle = new Rectangle();
            _ellipse = new Ellipse();
        }

        /// <summary>
        /// 測試 Rectangle 應正確地儲存座標
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        [DataTestMethod]
        [DataRow(0, 0, 100, 100)]
        [DataRow(23, 67.2, 99, 134.6)]
        [DataRow(87.1, 22, 12.2, 55)]
        public void TestRectangleStoreNormalCoordinatesCorrectly(double x1, double y1, double x2, double y2)
        {
            _rectangle.X1 = x1;
            _rectangle.Y1 = y1;
            _rectangle.X2 = x2;
            _rectangle.Y2 = y2;

            Assert.AreEqual(x1, _rectangle.X1);
            Assert.AreEqual(y1, _rectangle.Y1);
            Assert.AreEqual(x2, _rectangle.X2);
            Assert.AreEqual(y2, _rectangle.Y2);
        }

        /// <summary>
        /// 測試 Ellipse 應正確地儲存座標
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        [DataTestMethod]
        [DataRow(1, 1, 100, 100)]
        [DataRow(23, 67.2, 99, 134.6)]
        [DataRow(87.1, 22, 12.2, 55)]
        public void TestEllipseStoreNormalCoordinatesCorrectly(double x1, double y1, double x2, double y2)
        {
            _ellipse.X1 = x1;
            _ellipse.Y1 = y1;
            _ellipse.X2 = x2;
            _ellipse.Y2 = y2;

            Assert.AreEqual(x1, _ellipse.X1);
            Assert.AreEqual(y1, _ellipse.Y1);
            Assert.AreEqual(x2, _ellipse.X2);
            Assert.AreEqual(y2, _ellipse.Y2);
        }

        /// <summary>
        /// 測試 Rectangle 呼叫對應的 DrawShapes 之前，如果所儲存的座標為反，應該反轉座標輸入進去
        /// </summary>
        [DataTestMethod]
        [DataRow(100, 100, 1, 1)]
        [DataRow(2, 100, 1, 1)]
        [DataRow(100, 2, 1, 1)]
        public void TestRectangleShouldReverseCoordinatesIfXYIsReversed(double x1, double y1, double x2, double y2)
        {
            var graphics = new FakeGraphics();

            _rectangle.X1 = x1;
            _rectangle.Y1 = y1;
            _rectangle.X2 = x2;
            _rectangle.Y2 = y2;

            _rectangle.Draw(graphics);

            Assert.AreEqual(x2, graphics.TopLeftX);
            Assert.AreEqual(y2, graphics.TopLeftY);
            Assert.AreEqual(x1, graphics.BottomRightX);
            Assert.AreEqual(y1, graphics.BottomRightY);
        }

        /// <summary>
        /// 測試 Ellipse 呼叫對應的 DrawShapes 之前，如果所儲存的座標為反，應該反轉座標輸入進去
        /// </summary>
        [DataTestMethod]
        [DataRow(100, 100, 1, 1)]
        [DataRow(2, 100, 1, 1)]
        [DataRow(100, 2, 1, 1)]
        public void TestEllipseShouldReverseCoordinatesIfXYIsReversed(double x1, double y1, double x2, double y2)
        {
            var graphics = new FakeGraphics();

            _ellipse.X1 = x1;
            _ellipse.Y1 = y1;
            _ellipse.X2 = x2;
            _ellipse.Y2 = y2;

            _ellipse.Draw(graphics);

            Assert.AreEqual(x2, graphics.TopLeftX);
            Assert.AreEqual(y2, graphics.TopLeftY);
            Assert.AreEqual(x1, graphics.BottomRightX);
            Assert.AreEqual(y1, graphics.BottomRightY);
        }
    }
}
