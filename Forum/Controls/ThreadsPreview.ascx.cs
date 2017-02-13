using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.Controls
{
    public partial class ThreadsPreview : System.Web.UI.UserControl
    {
        private IEnumerable<Thread> threadsDataSource;
        private IEnumerable<int> pagerSize;

        public event EventHandler SearchButtonClick;

        public IEnumerable<Thread> ThreadsDataSource
        {
            get
            {
                return this.threadsDataSource;
            }
            set
            {
                this.threadsDataSource = value;
            }
        }

        public IEnumerable<int> PagerSize
        {
            get
            {
                return this.pagerSize;
            }
            set
            {
                this.pagerSize = value;
                this.ListViewFake.DataSource = this.pagerSize;
            }
        }

        public string SearchTerm { get; set; }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (this.SearchButtonClick != null)
            {
                this.SearchTerm = this.TextBoxSearch.Text;
                this.SearchButtonClick(this, e);
            }    
        }
    }
}