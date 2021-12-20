using System.Windows.Forms;

namespace DrawingForm
{
    public partial class Canvas : UserControl
    {
        public Canvas()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
    }
}
