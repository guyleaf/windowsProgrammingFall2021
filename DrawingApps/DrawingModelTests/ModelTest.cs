using DrawingModel;
using DrawingModel.Enums;
using DrawingModel.Interfaces;
using DrawingModel.Shapes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingModelTests
{
    [TestClass]
    public class ModelTest
    {
        private const string DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE = "Drawing Shape Type should be chosen before drawing.";
        private IModel _model;
        private PrivateObject _privateModel;

        public ModelTest()
        {
        }

        /// <summary>
        /// 測試初始化
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _model = new Model();
            _privateModel = new PrivateObject(_model);
        }

        /// <summary>
        /// 檢查 Model 初始狀態
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="target"></param>
        [DataTestMethod]
        [DataRow("_isPressed", false, DisplayName = "Test _isPressed should be false")]
        [DataRow("_drawingShapeType", ShapeType.Unknown, DisplayName = "Test _drawingShapeType should be ShapeType.Unknown")]
        [DataRow("_drawingShape", null, DisplayName = "Test _drawingShape should be null")]
        public void CheckInitialModelState(string fieldName, object target)
        {
            var result = _privateModel.GetField(fieldName);
            Assert.AreEqual(target, result);
        }

        /// <summary>
        /// 檢查 shapes list 初始狀態應為空
        /// </summary>
        [TestMethod]
        public void CheckInitialShapesListEmpty()
        {
            var result = _privateModel.GetField("_shapes") as IList<IShape>;
            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// 供先決條件測試，設定 DrawingShape
        /// </summary>
        private void SetUpForSettingDrawingShape()
        {
            _privateModel.SetField("_drawingShapeType", ShapeType.Rectangle);
            _privateModel.SetField("_drawingShape", new Rectangle());
        }

        #region PressPointer 相關單元測試
        /// <summary>
        /// 測試 PressPointer 應儲存 start point 座標
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(1, 50)]
        [DataRow(50, 1)]
        public void TestPressPointerShouldStoreStartPoint(double x, double y)
        {
            SetUpForSettingDrawingShape();
            _model.PressPointer(x, y);

            var shape = _privateModel.GetField("_drawingShape") as IShape;
            Assert.AreEqual(x, shape.X1, 0.0001);
            Assert.AreEqual(y, shape.Y1, 0.0001);
        }

        /// <summary>
        /// 測試 PressPointer 應觸發 IsPressed 為 True
        /// </summary>
        [TestMethod]
        public void TestPressPointerShouldTriggerIsPressedToTrue()
        {
            SetUpForSettingDrawingShape();
            _model.PressPointer(100, 100);

            var isPressed = _privateModel.GetField("_isPressed");
            Assert.AreEqual(true, isPressed);
        }

        /// <summary>
        /// 測試 PressPointer 當碰上座標小於1的點時，應不被改變狀態
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(-50, 50)]
        [DataRow(50, -50)]
        [DataRow(-1, -1)]
        [DataRow(-10, -1)]
        [DataRow(-1, -10)]
        public void TestPressPointerShouldNotBeChangedIfPointIsLessThanOne(double x, double y)
        {
            SetUpForSettingDrawingShape();
            _model.PressPointer(x, y);

            var shape = _privateModel.GetField("_drawingShape") as IShape;
            var isPressed = _privateModel.GetField("_isPressed");

            Assert.AreEqual(0, shape.X1, 0.0001);
            Assert.AreEqual(0, shape.Y1, 0.0001);
            Assert.AreEqual(false, isPressed);
        }

        /// <summary>
        /// 測試 PressPointer 當未設定 ShapeType 時應發生 Exception
        /// </summary>
        [TestMethod]
        public void RaiseExceptionWhenCallingPressPointerBeforeSettingShapeType()
        {
            Assert.ThrowsException<Exception>(() => _model.PressPointer(100, 100), DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE);
        }
        #endregion

        #region MovePointer 相關單元測試
        /// <summary>
        /// 測試 MovePointer 應儲存 end point 座標
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(1, 50)]
        [DataRow(50, 1)]
        [DataRow(-50, 1)]
        [DataRow(1, -50)]
        [DataRow(-1, -1)]
        public void TestMovePointerShouldStoreEndPoint(double x, double y)
        {
            SetUpForSettingDrawingShape();
            _privateModel.SetField("_isPressed", true);

            _model.MovePointer(x, y);

            var shape = _privateModel.GetField("_drawingShape") as IShape;
            Assert.AreEqual(x, shape.X2, 0.0001);
            Assert.AreEqual(y, shape.Y2, 0.0001);
        }

        /// <summary>
        /// 測試 MovePointer 當 IsPressed 為否時，應不被改變狀態
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(1, 50)]
        [DataRow(50, 1)]
        [DataRow(-50, 1)]
        [DataRow(1, -50)]
        [DataRow(-1, -1)]
        public void TestMovePointerShouldNotBeChangedIfIsPressedIsFalse(double x, double y)
        {
            SetUpForSettingDrawingShape();
            _privateModel.SetField("_isPressed", false);

            _model.MovePointer(x, y);

            var shape = _privateModel.GetField("_drawingShape") as IShape;
            Assert.AreEqual(0, shape.X2, 0.0001);
            Assert.AreEqual(0, shape.Y2, 0.0001);
        }

        /// <summary>
        /// 測試 MovePointer 當未設定 ShapeType 時應發生 Exception
        /// </summary>
        [TestMethod]
        public void RaiseExceptionWhenCallingMovePointerBeforeSettingShapeType()
        {
            Assert.ThrowsException<Exception>(() => _model.MovePointer(100, 100), DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE);
        }
        #endregion

        #region ReleasePointer 相關單元測試
        /// <summary>
        /// 測試 ReleasePointer 應建立 IShape 物件並儲存至 _shapes
        /// </summary>
        [TestMethod]
        public void TestReleasePointerShouldStoreNewShapeInShapesList()
        {
            SetUpForSettingDrawingShape();
            _privateModel.SetField("_isPressed", true);

            _model.ReleasePointer(100, 100);

            var shapes = _privateModel.GetField("_shapes") as IList<IShape>;
            Assert.AreEqual(1, shapes.Count);

            var drawingShape = _privateModel.GetField("_drawingShape") as IShape;
            var shape = shapes.First();
            Assert.AreEqual(drawingShape.GetType(), shape.GetType());
            Assert.AreEqual(drawingShape.X1, shape.X1);
            Assert.AreEqual(drawingShape.Y1, shape.Y1);
            Assert.AreEqual(100, shape.X2);
            Assert.AreEqual(100, shape.Y2);
        }

        /// <summary>
        /// 測試 ReleasePointer 建立 IShape 物件時，應該使用 released point 作為終點
        /// </summary>
        [TestMethod]
        public void TestReleasePointerShouldUseReleasedPointAsNewShapeEndPoint()
        {
            
        }

        /// <summary>
        /// 測試 ReleasePointer 觸發 IsPressed 為 False
        /// </summary>
        [TestMethod]
        public void TestReleasePointerShouldTriggerIsPressedToFalse()
        {

        }

        /// <summary>
        /// 測試 MovePointer 當 IsPressed 為否時，應不儲存 new shape 至 shapes list
        /// </summary>
        [TestMethod]
        public void TestReleasePointerShouldNotStoreNewShapeInShapesListIfIsPressedIsFalse()
        {
        }
        #endregion
    }
}
