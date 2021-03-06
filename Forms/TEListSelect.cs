﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEPlugin.Forms
{
    public partial class TEListSelect : Form
    {

        public int SelectedIndex
        {
            internal set;
            get;
        }
        public TEListSelect(List<string> list)
        {
            InitializeComponent();
            this.SelectedIndex = -1;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.HandledEnhancedListView(list);
        }


        private void HandledEnhancedListView(List<string> list)
        {
            ColumnHeader[] headers = new ColumnHeader[7];
            for (int i = 0; i < headers.Length; i++)
            {
                headers[i] = new ColumnHeader();
            }
            this.enhancedListView1.BeginUpdate();
            this.enhancedListView1.Dock = System.Windows.Forms.DockStyle.None;
            this.enhancedListView1.Sortable = true;
            this.enhancedListView1.FullRowSelect = true;
            this.enhancedListView1.HideSelection = false;
            this.enhancedListView1.MultiSelect = false;
            this.enhancedListView1.Columns.AddRange(headers);
            this.enhancedListView1.View = System.Windows.Forms.View.Details;
            headers[0].Text = "Cert. Subject";
            headers[1].Text = "Cert. Label";
            headers[2].Text = "Token Label";
            headers[3].Text = "Token Manufacturer ID";
            headers[4].Text = "Token Model";
            headers[5].Text = "Token Serial";
            headers[6].Text = "time";
            enhancedListView1.Columns[0].DisplayIndex = 1;
            enhancedListView1.Columns[1].DisplayIndex = 2;
            enhancedListView1.Columns[2].DisplayIndex = 0;
            enhancedListView1.Columns[3].DisplayIndex = 4;
            enhancedListView1.Columns[4].DisplayIndex = 5;
            enhancedListView1.Columns[5].DisplayIndex = 3;
            enhancedListView1.Columns[6].DisplayIndex = 6;




            this.enhancedListView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            for (int i = 0; i < list.Count; i++)
            {
                string entry = list[i];
                ListViewItem listViewItem = new ListViewItem(entry.Split(new string[] { " / " }, StringSplitOptions.None));
                listViewItem.Tag = i;
                enhancedListView1.Items.Add(listViewItem);
            }
            for (int i = 0; i < headers.Length - 1; i++)
            {
                enhancedListView1.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            enhancedListView1.Columns[headers.Length - 1].Width = 0;

            this.enhancedListView1.EndUpdate();


        }


        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (enhancedListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a key!");
                return;
            }
            this.SelectedIndex = (int)enhancedListView1.SelectedItems[0].Tag;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            this.SelectedIndex = -1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TEListSelect_Load(object sender, EventArgs e)
        {

        }
    }
}
