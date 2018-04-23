using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			list = new BindingList<MyObject>();

			for(int i = 0; i < 10; i++) {
				list.Add(new MyObject(i.ToString(),(i+10).ToString()));
			}
			bs = new BindingSource();
			bs.DataSource = list;

			gridControl1.DataSource = bs;

		}


		BindingSource bs;
		BindingList<MyObject> list;

		private void simpleButton1_Click(object sender, EventArgs e) {
			listBoxControl1.Items.Clear();
			for(int i = 0; i < gridView1.SelectedRowsCount; i++) {
				int row = (gridView1.GetSelectedRows()[i]);
				MyObject obj = gridView1.GetRow(row) as MyObject;
				if(obj == null) return;
				listBoxControl1.Items.Add(obj.Field2.ToString());
			}
		}

	}
    public class MyObject: INotifyPropertyChanged {
        public MyObject(string str1,string str2) {
            field1 = str1;
			field2 = str2;
        }
        private string field1;
        public string Field1 {
            get { return field1; }
            set {
                field1 = value;
                NotifyPropertyChanged("Field1");
            }
        }

		private string field2;
		public string Field2 {
			get { return field2; }
			set {
				field2 = value;
				NotifyPropertyChanged("Field2");
			}
		}


        #region INotifyPropertyChanged Members

        private void NotifyPropertyChanged(String info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}