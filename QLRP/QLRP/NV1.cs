﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLRP.DTO;
using QLRP.BLL;

namespace QLRP
{
    public partial class NV1 : Form
    {
        public NV1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }
        private NV GetNVOnForm()
        {
            NV a = new NV();
            a.ChucVu = txtChucVu.Text;
            a.DiaChi = txtDiaChi.Text;
            if (radioButton1.Checked == true) a.GioiTinh = true;
            else a.GioiTinh = false;
            a.MaNhanVien = txtMa.Text;
            a.MK = txtMk.Text;
            a.NgaySinh = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            a.SDT = txtSDT.Text;
            a.SoCC = txtSCC.Text;
            a.TenNhanVien = txtName.Text;
            a.TK = txtTk.Text;

            return a;
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            if ((GetNVOnForm().ChucVu == "Quan Ly") && (GetNVOnForm().TK == "" || GetNVOnForm().MK == ""))
            {
                MessageBox.Show("Chức vụ quản lý phải có tài khoản đăng nhập!!!");
            }
            else
                if (GetNVOnForm().MaNhanVien == "" || GetNVOnForm().TenNhanVien == "" || GetNVOnForm().SoCC == "") MessageBox.Show("Thông tin chưa đầy đủ!!!");
                else
                {
                    string query = "Select * from NHANVIEN where MaNhanVien =N'" + GetNVOnForm().MaNhanVien +"'";
                    string query2 = "Select * from NHANVIEN where SoCC =N'" + GetNVOnForm().SoCC + "'";
                    if (Login_BLL.Instance.Check_BLL(query) == true) MessageBox.Show("Đã tồn tại mã nhân viên này!!!");
                    else if (Login_BLL.Instance.Check_BLL(query2) == true) MessageBox.Show("Đã tồn tại nhân viên này!!!");
                    else if (QLNV_BLL.Instance.AddNV_BLL(GetNVOnForm())) MessageBox.Show("Thêm thành công!!!");
                    else MessageBox.Show("Gặp lỗi khi thêm!!!");
                }
        }
        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NV1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) butOK.PerformClick();
            else if (e.KeyCode == Keys.Escape) butExit.PerformClick();
        }

      
        }

    }

