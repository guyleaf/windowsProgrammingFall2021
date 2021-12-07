using DrawingModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml.Controls;

namespace DrawingApp.PresentationModel
{
    public class PresentationModel
    {
        private readonly Model _model;
        private readonly IGraphics _igraphics;

        public PresentationModel(Model model, Canvas canvas)
        {
            _model = model;
            _igraphics = new WindowsStoreGraphicsAdaptor(canvas);
        }

        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_igraphics);
        }
    }
}
