using System.Windows.Forms;

namespace Photo_Selection_Assistant
{
    class MyFlowLayoutPanel : FlowLayoutPanel
    {
        public MyFlowLayoutPanel()
        {
            this.DoubleBuffered = true;
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();
            base.OnScroll(se);
        }
    }
}
