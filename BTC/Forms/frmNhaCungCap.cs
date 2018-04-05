using BTC.Entity;
using BTC.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTC.Forms
{
    public partial class frmNhaCungCap : Form
    {
        PhamMinhDuc_BTC_17Entities db = new PhamMinhDuc_BTC_17Entities();
        private NCC currentNCC;
        string flagAction = "add";
        public frmNhaCungCap()
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

        private void loadID()
        {
            NCC lastNCC = db.NCCs.OrderByDescending(x => x.Idncc).FirstOrDefault();
            string lastID = lastNCC != null ? lastNCC.Idncc : "";
            string nextID = IdGenerate.genId(lastID, "NCC000");
            txtIDNCC.Text = nextID;
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            loadDataGridView();
            loadID();
            btnLuu.Enabled = true;
            btnReset.Enabled = true;
        }

        private void loadDataGridView()
        {
            dgvNCC.DataSource = db.NCCs.ToList();
            dgvNCC.Columns[4].Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flagAction == "add")
            {
                NCC ncc = new NCC();
                ncc.Idncc = txtIDNCC.Text;
                ncc.Sdt = txtSoDienThoai.Text;
                ncc.Tenncc = txtTenNCC.Text;
                ncc.DiaChi = txtDiaChi.Text;
                db.NCCs.Add(ncc);
                db.SaveChanges();
            }
            if (flagAction == "update")
            {
                if (currentNCC != null)
                {
                    NCC ncc = db.NCCs.Where(x => x.Idncc == currentNCC.Idncc).FirstOrDefault();
                    if (ncc != null)
                    {
                        ncc.Idncc = txtIDNCC.Text;
                        ncc.Sdt = txtSoDienThoai.Text;
                        ncc.Tenncc = txtTenNCC.Text;
                        ncc.DiaChi = txtDiaChi.Text;
                        db.SaveChanges();
                        currentNCC = null;
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

        private void dgvNCC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currentNCC = (dgvNCC.DataSource as List<NCC>).Skip(e.RowIndex).FirstOrDefault();
            bindToTextbox();
            unlockControl();
        }

        void bindToTextbox()
        {
            txtIDNCC.Text = currentNCC.Idncc;
            txtDiaChi.Text = currentNCC.DiaChi;
            txtSoDienThoai.Text = currentNCC.Sdt;
            txtTenNCC.Text = currentNCC.Tenncc;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentNCC != null)
            {
                db.NCCs.Remove(currentNCC);
                db.SaveChanges();
                loadDataGridView();
                loadID();
                reset();
                currentNCC = null;
            }
        }

        void reset()
        {
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            lockControl();
            btnLuu.Enabled = true;
            btnReset.Enabled = true;
            loadID();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentNCC != null)
            {
                btnReset.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                flagAction = "update";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
