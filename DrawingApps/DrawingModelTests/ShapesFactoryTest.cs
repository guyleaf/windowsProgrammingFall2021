using DrawingModel;
using DrawingModel.Enums;
using DrawingModel.Shapes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace DrawingModelTests
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
        /// 測試 Factory CreateShape 正確性
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="returnType"></param>
        [DataTestMethod]
        [DataRow(ShapeType.Rectangle, typeof(Rectangle), DisplayName = "Test Reactangle")]
        [DataRow(ShapeType.Ellipse, typeof(Ellipse), DisplayName = "Test Ellipse")]
        public void TestCorrectionForCreateShape(ShapeType shapeType, Type returnType)
        {
            var result = ShapesFactory.CreateShape(shapeType);
            Assert.AreEqual(returnType, result.GetType());
        }

        /// <summary>
        /// 測試 Factory CreateShape 不正確性
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="returnType"></param>
        [DataTestMethod]
        [DataRow(ShapeType.Rectangle, typeof(Ellipse), DisplayName = "Test Reactangle")]
        [DataRow(ShapeType.Ellipse, typeof(Rectangle), DisplayName = "Test Ellipse")]
        public void TestInCorrectionForCreateShape(ShapeType shapeType, Type returnType)
        {
            var result = ShapesFactory.CreateShape(shapeType);
            Assert.AreNotEqual(returnType, result.GetType());
        }

        /// <summary>
        /// 測試當 ShapeType 為 Unknown 時，需發生例外
        /// </summary>
        [TestMethod]
        public void RaiseExceptionIfShapeTypeIsUnknown()
        {
            var shapeType = ShapeType.Unknown;
            Assert.ThrowsException<Exception>(() => ShapesFactory.CreateShape(shapeType), "Unknown shape type.");
        }
    }
}