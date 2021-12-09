using DrawingModel;
using DrawingModel.Enums;
using DrawingModel.Shapes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace DrawingModelTest
{
    /// <summary>
    /// ShapesFactoryTest 的摘要說明
    /// </summary>
    [TestClass]
    public class ShapesFactoryTest
    {
        public ShapesFactoryTest()
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

        /// <summary>
        /// 測試當 ShapeType 為 Unknown 時，需發生例外
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception), "Unknown shape type.")]
        public void RaiseExceptionIfShapeTypeIsUnknown()
        {
            _ = ShapesFactory.CreateShape(ShapeType.Unknown);
        }
    }
}