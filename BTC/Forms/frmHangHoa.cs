using BTC.Entity;
using BTC.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTC.Forms
{
    public partial class frmHangHoa : Form
    {
        private HangTon currentPro;
        string flagAction = "add";

        public frmHangHoa()
        {
            InitializeComponent();
            lockControl();
        }

        void lockControl()
        {
            btnLuu.Enabled = false;
            btnReset.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        void unlockControl()
        {
            btnLuu.Enabled = true;
            btnReset.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private PhamMinhDuc_BTC_17Entities db = new PhamMinhDuc_BTC_17Entities();

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            loadDataGridView();
            loadID();
            btnLuu.Enabled = true;
            btnReset.Enabled = true;
        }

        private void loadDataGridView()
        {
            dgvHang.DataSource = db.HangTons.ToList();
            dgvHang.Columns[6].Visible = false;
            dgvHang.Columns[7].Visible = false;
        }

        private void loadID()
        {
            HangTon lastProduct = db.HangTons.OrderByDescending(x => x.Idhang).FirstOrDefault();
            string lastID = lastProduct != null ? lastProduct.Idhang : "";
            string nextID = IdGenerate.genId(lastID, "Produc");
            txtID.Text = nextID;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flagAction == "add")
            {
                HangTon hang = new HangTon();
                hang.Idhang = txtID.Text;
                hang.Tenhang = txtTenHang.Text;
                hang.Dvt = txtDonViTinh.Text;
                db.HangTons.Add(hang);
                db.SaveChanges();
            }
            if(flagAction == "update")
            {
                if (currentPro != null)
                {
                    HangTon hang = db.HangTons.Where(x => x.Idhang == currentPro.Idhang).FirstOrDefault();
                    if (hang != null)
                    {
                        hang.Idhang = txtID.Text;
                        hang.Tenhang = txtTenHang.Text;
                        hang.Dvt = txtDonViTinh.Text;
                        db.SaveChanges();
                        currentPro = null;
                    }
                    flagAction = "add";
                    lockControl();
                    btnLuu.Enabled = true;
                    btnReset.Enabled = true;
                }
            }
            reset();
            loadID();
            loadDataGridView();
        }

        private void dgvHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currentPro = (dgvHang.DataSource as List<HangTon>).Skip(e.RowIndex).FirstOrDefault();
            bindToTextbox();
            unlockControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentPro != null)
            {
                db.HangTons.Remove(currentPro);
                db.SaveChanges();
                loadDataGridView();
                loadID();
                reset();
                currentPro = null;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(currentPro != null)
            {
                btnReset.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                flagAction = "update";
            }
           
        }

        private void bindToTextbox()
        {
            txtID.Text = currentPro.Idhang;
            txtTenHang.Text = currentPro.Tenhang;
            txtDonViTinh.Text = currentPro.Dvt;
        }

        private void reset()
        {
            txtTenHang.Text = "";
            txtDonViTinh.Text = "";
            lockControl();
            btnLuu.Enabled = true;
            btnReset.Enabled = true;
            loadID();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}