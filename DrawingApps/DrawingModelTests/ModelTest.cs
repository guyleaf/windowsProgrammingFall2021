using DrawingModel;
using DrawingModel.Attributes;
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
        [DataRow("_drawingShapeType", ShapeType.None, DisplayName = "Test _drawingShapeType should be ShapeType.None")]
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
        private void SetUpForSettingRectangle()
        {
            _privateModel.SetField("_drawingShapeType", ShapeType.Rectangle);
            _privateModel.SetField("_drawingShape", new Rectangle());
        }

        /// <summary>
        /// 取得 ShapeTargetAttribute 的指定 Type
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private Type GetShapeClassType(ShapeType shapeType)
        {
            var attribute = shapeType.GetType().GetMember(shapeType.ToString())
                .First()
                .GetCustomAttributes(typeof(ShapeTargetAttribute), false)
                .FirstOrDefault() as ShapeTargetAttribute;
            return attribute.ShapeClassType;
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
        public void TestPressPointerShouldStoreStartPointInDrawingShape(double x, double y)
        {
            SetUpForSettingRectangle();
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
            SetUpForSettingRectangle();
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
        public void TestPressPointerShouldNotChangeDrawingShapeIfPointIsLessThanOne(double x, double y)
        {
            SetUpForSettingRectangle();

            _model.PressPointer(x, y);

            var shape = _privateModel.GetField("_drawingShape") as IShape;
            var isPressed = (bool)_privateModel.GetField("_isPressed");

            Assert.AreEqual(0, shape.X1, 0.0001);
            Assert.AreEqual(0, shape.Y1, 0.0001);
            Assert.IsFalse(isPressed);
        }

        /// <summary>
        /// 測試 PressPointer 當未設定 ShapeType 時應發生 Exception
        /// </summary>
        [TestMethod]
        public void RaiseExceptionWhenCallingPressPointerBeforeSettingShapeType()
        {
            Assert.ThrowsException<Exception>(() => _model.PressPointer(100, 100), DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE);
        }

        /// <summary>
        /// 測試 PressPointer 不應觸發 model changed 事件
        /// </summary>
        [DataTestMethod]
        [DataRow(0, 0, false)]
        [DataRow(50, 50, false)]
        public void TestPressPointerShouldNotTriggerModelChangedEvent(double x, double y, bool shouldTrigged)
        {
            SetUpForSettingRectangle();

            var isTriggered = false;
            _model._modelChanged += () =>
            {
                isTriggered = true;
            };

            _model.PressPointer(x, y);

            Assert.AreEqual(shouldTrigged, isTriggered);
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
        public void TestMovePointerShouldStoreEndPointInDrawingShape(double x, double y)
        {
            SetUpForSettingRectangle();
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
        public void TestMovePointerShouldNotChangeDrawingShapeIfIsPressedIsFalse(double x, double y)
        {
            SetUpForSettingRectangle();
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


        /// <summary>
        /// 測試 MovePointer 應正確地觸發 modelChanged 事件
        /// </summary>
        [DataTestMethod]
        [DataRow(false, false, DisplayName = "When isPressed is false, the event should not be triggered")]
        [DataRow(true, true, DisplayName = "When isPressed is true, the event should be triggered")]
        public void TestMovePointerShouldTriggerModelChangedEventCorrectly(bool isPressed, bool shouldTrigged)
        {
            SetUpForSettingRectangle();
            _privateModel.SetField("_isPressed", isPressed);

            var isTriggered = false;
            _model._modelChanged += () =>
            {
                isTriggered = true;
            };

            _model.MovePointer(100, 100);

            Assert.AreEqual(shouldTrigged, isTriggered);
        }
        #endregion

        #region ReleasePointer 相關單元測試
        /// <summary>
        /// 測試 ReleasePointer 應建立 IShape 物件並儲存至 _shapes
        /// </summary>
        [TestMethod]
        public void TestReleasePointerShouldStoreNewShapeInShapesList()
        {
            SetUpForSettingRectangle();
            _privateModel.SetField("_isPressed", true);
            var releasedPointX = 100;
            var releasedPointY = 80;

            _model.ReleasePointer(releasedPointX, releasedPointY);

            var shapes = _privateModel.GetField("_shapes") as IList<IShape>;
            Assert.AreEqual(1, shapes.Count);

            var shape = shapes.First();
            Assert.AreEqual(typeof(Rectangle), shape.GetType());
            Assert.AreEqual(0, shape.X1, 0.0001);
            Assert.AreEqual(0, shape.Y1, 0.0001);
            Assert.AreEqual(releasedPointX, shape.X2, 0.0001);
            Assert.AreEqual(releasedPointY, shape.Y2, 0.0001);
        }

        /// <summary>
        /// 測試 ReleasePointer 觸發 IsPressed 為 False
        /// </summary>
        [TestMethod]
        public void TestReleasePointerShouldTriggerIsPressedToFalse()
        {
            SetUpForSettingRectangle();
            _privateModel.SetField("_isPressed", true);

            _model.ReleasePointer(100, 100);

            var isPressed = (bool)_privateModel.GetField("_isPressed");
            Assert.IsFalse(isPressed);
        }

        /// <summary>
        /// 測試 ReleasePointer 當 IsPressed 為否時，應不儲存 new shape 至 shapes list
        /// </summary>
        [TestMethod]
        public void TestReleasePointerShouldNotStoreNewShapeInShapesListIfIsPressedIsFalse()
        {
            SetUpForSettingRectangle();
            _privateModel.SetField("_isPressed", false);

            _model.ReleasePointer(100, 100);

            var shapes = _privateModel.GetField("_shapes") as IList<IShape>;
            Assert.AreEqual(0, shapes.Count);
        }

        /// <summary>
        /// 測試 ReleasePointer 當未設定 ShapeType 時應發生 Exception
        /// </summary>
        [TestMethod]
        public void RaiseExceptionWhenCallingReleasePointerBeforeSettingShapeType()
        {
            Assert.ThrowsException<Exception>(() => _model.ReleasePointer(100, 100), DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE);
        }

        /// <summary>
        /// 測試 ReleasePointer 應正確地觸發 modelChanged 事件
        /// </summary>
        [DataTestMethod]
        [DataRow(false, false, DisplayName = "When isPressed is false, the event should not be triggered")]
        [DataRow(true, true, DisplayName = "When isPressed is true, the event should be triggered")]
        public void TestReleasePointerShouldTriggerModelChangedEventCorrectly(bool isPressed, bool shouldTrigged)
        {
            SetUpForSettingRectangle();
            _privateModel.SetField("_isPressed", isPressed);

            var isTriggered = false;
            _model._modelChanged += () =>
            {
                isTriggered = true;
            };

            _model.MovePointer(100, 100);

            Assert.AreEqual(shouldTrigged, isTriggered);
        }
        #endregion

        #region SetShapeType 相關測試
        /// <summary>
        /// 測試 SetShapeType 輸入 ShapeType 應建構對應物件
        /// </summary>
        [DataTestMethod]
        [DataRow(ShapeType.Ellipse)]
        [DataRow(ShapeType.Rectangle)]
        public void TestSetShapeTypeShouldStoreCorrectShapeObject(ShapeType shapeType)
        {
            _model.SetShapeType(shapeType);

            var shape = _privateModel.GetField("_drawingShape") as IShape;
            var drawingShapeType = (ShapeType)_privateModel.GetField("_drawingShapeType");

            Assert.AreEqual(shapeType, drawingShapeType);
            Assert.AreEqual(GetShapeClassType(shapeType), shape.GetType());
        }

        /// <summary>
        /// 測試 SetShapeType 應正確地觸發 modelChanged 事件
        /// </summary>
        [DataTestMethod]
        [DataRow(ShapeType.Ellipse, DisplayName = "When shapeType is Rectangle")]
        [DataRow(ShapeType.Rectangle, DisplayName = "When shapeType is Ellipse")]
        public void TestSetShapeTypeShouldBeAlwaysTriggerModelChangedEvent(ShapeType shapeType)
        {
            var isTriggered = false;
            _model._modelChanged += () =>
            {
                isTriggered = true;
            };

            _model.SetShapeType(shapeType);

            Assert.IsTrue(isTriggered);
        }
        #endregion

        #region Clear 相關測試
        /// <summary>
        /// 測試 Clear 應清除所有資料
        /// </summary>
        [TestMethod]
        public void TestClearShouldWorkAsExpected()
        {
            SetUpForSettingRectangle();
            _privateModel.SetField("_isPressed", true);
            _privateModel.SetField("_shapes", new List<IShape>() { new Rectangle(), new Ellipse() });

            _model.Clear();

            var shape = _privateModel.GetField("_drawingShape") as IShape;
            var shapeType = (ShapeType)_privateModel.GetField("_drawingShapeType");
            var isPressed = (bool)_privateModel.GetField("_isPressed");
            Assert.IsNull(shape);
            Assert.AreEqual(ShapeType.None, shapeType);
            Assert.IsFalse(isPressed);

            var shapes = _privateModel.GetField("_shapes") as IList<IShape>;
            Assert.AreEqual(0, shapes.Count);
        }

        /// <summary>
        /// 測試 Clear 應正確地觸發 modelChanged 事件
        /// </summary>
        [TestMethod]
        public void TestClearShouldBeAlwaysTriggerModelChangedEvent()
        {
            var isTriggered = false;
            _model._modelChanged += () =>
            {
                isTriggered = true;
            };

            _model.Clear();

            Assert.IsTrue(isTriggered);
        }
        #endregion

        #region Draw 相關測試
        /// <summary>
        /// 測試 Draw 應正確地呼叫 graphics.ClearAll
        /// </summary>
        [TestMethod]
        public void TestDrawShouldTriggerClearAll()
        {
            var graphics = new FakeGraphics();

            _model.Draw(graphics);

            Assert.IsTrue(graphics.IsClearAllTriggered);
        }

        /// <summary>
        /// 測試 Draw 當 shapes list 有 Rectangle 與 Ellipse 應正確地呼叫 Draw graphics
        /// </summary>
        [TestMethod]
        public void TestDrawWithNonEmptyShapesListShouldTriggerDrawGraphics()
        {
            var graphics = new FakeGraphics();
            _privateModel.SetField("_isPressed", false);
            _privateModel.SetField("_shapes", new List<IShape>() { new Rectangle(), new Ellipse() });

            _model.Draw(graphics);

            Assert.IsTrue(graphics.IsDrawEllipseTriggered);
            Assert.IsTrue(graphics.IsDrawRectangleTriggered);
            Assert.AreEqual(1, graphics.CountForDrawEllipise);
            Assert.AreEqual(1, graphics.CountForDrawRectangle);
        }

        /// <summary>
        /// 測試 Draw 當 shapes list 為空時，應不呼叫任何 Draw graphics
        /// </summary>
        [TestMethod]
        public void TestDrawWithEmptyShapesListShouldNotTriggerAnyDrawGraphics()
        {
            var graphics = new FakeGraphics();
            _privateModel.SetField("_isPressed", false);
            _privateModel.SetField("_shapes", new List<IShape>());

            _model.Draw(graphics);

            Assert.IsFalse(graphics.IsDrawEllipseTriggered);
            Assert.IsFalse(graphics.IsDrawRectangleTriggered);
        }

        /// <summary>
        /// 測試 Draw 當 IsPressed 為 true 時，應正確地呼叫對應 Draw graphics
        /// </summary>
        [DataTestMethod]
        [DataRow(typeof(Rectangle), false, true)]
        [DataRow(typeof(Ellipse), true, false)]
        public void TestDrawShouldTriggerDrawGraphicIfIsPressedIsTrue(Type shapeType, bool isDrawEllipseTriggered, bool isDrawRectangleTriggered)
        {
            var graphics = new FakeGraphics();
            _privateModel.SetField("_isPressed", true);
            _privateModel.SetField("_drawingShape", Activator.CreateInstance(shapeType));

            _model.Draw(graphics);

            Assert.AreEqual(isDrawEllipseTriggered, graphics.IsDrawEllipseTriggered);
            Assert.AreEqual(isDrawRectangleTriggered, graphics.IsDrawRectangleTriggered);
        }
        #endregion
    }
}
