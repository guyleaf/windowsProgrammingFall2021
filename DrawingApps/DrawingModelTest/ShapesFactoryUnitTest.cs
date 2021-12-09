using DrawingModel;
using DrawingModel.Enums;
using DrawingModel.Shapes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace DrawingModelTest
{
    /// <summary>
    /// ShapesFactoryUnitTest 的摘要說明
    /// </summary>
    [TestClass]
    public class ShapesFactoryUnitTest
    {
        public ShapesFactoryUnitTest()
        {
        }

        /// <summary>
        /// 測試 Factory CreateShape
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="implementType"></param>
        [TestMethod()]
        [DataRow(ShapeType.Rectangle, typeof(Rectangle), DisplayName = "Test Reactangle")]
        [DataRow(ShapeType.Ellipse, typeof(Ellipse), DisplayName = "Test Ellipse")]
        public void TestCreateShape(ShapeType shapeType, Type implementType)
        {
            var result = ShapesFactory.CreateShape(shapeType);
            Assert.AreEqual(implementType, result.GetType());
        }
    }
}