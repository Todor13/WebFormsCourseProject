using System;

namespace Forum.Controls
{
    public partial class Reply : System.Web.UI.UserControl
    {
        public event EventHandler<PublishEventArgs> PublishButtonClick;
        public event EventHandler CancelButtonClick;

        protected void PublishButton_Click(object sender, EventArgs e)
        {
            if (PublishButtonClick != null)
            {
                this.PublishButtonClick(this, new PublishEventArgs(this.TextBoxReply.Text));
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClick != null)
            {
                this.CancelButtonClick(this, e);
            }
        }
    }
}