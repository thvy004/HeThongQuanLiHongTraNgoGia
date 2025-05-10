using System.Windows.Forms;

namespace HeThongQuanLiHongTraNgoGia
{
    partial class LapHoaDonForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cashierOrderForm_menuTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cashierOrderForm_clearBtn = new System.Windows.Forms.Button();
            this.cashierOrderForm_removeBtn = new System.Windows.Forms.Button();
            this.cashierOrderForm_addBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cashierOrderForm_price = new System.Windows.Forms.Label();
            this.cashierOrderForm_prodName = new System.Windows.Forms.Label();
            this.cashierOrderForm_SoLuong = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cashierOrderForm_productID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cashierOrderForm_Type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cashierOrderForm_orderTable = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cashierOrderForm_payBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cashierOrderForm_change = new System.Windows.Forms.Label();
            this.cashierOrderForm_amount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cashierOrderForm_orderPrice = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierOrderForm_menuTable)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierOrderForm_SoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierOrderForm_orderTable)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cashierOrderForm_menuTable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(17, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 336);
            this.panel1.TabIndex = 0;
            // 
            // cashierOrderForm_menuTable
            // 
            this.cashierOrderForm_menuTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cashierOrderForm_menuTable.Location = new System.Drawing.Point(17, 49);
            this.cashierOrderForm_menuTable.Name = "cashierOrderForm_menuTable";
            this.cashierOrderForm_menuTable.RowHeadersWidth = 62;
            this.cashierOrderForm_menuTable.Size = new System.Drawing.Size(625, 270);
            this.cashierOrderForm_menuTable.TabIndex = 2;
            this.cashierOrderForm_menuTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cashierOrderForm_menuTable_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cashierOrderForm_clearBtn);
            this.panel2.Controls.Add(this.cashierOrderForm_removeBtn);
            this.panel2.Controls.Add(this.cashierOrderForm_addBtn);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cashierOrderForm_price);
            this.panel2.Controls.Add(this.cashierOrderForm_prodName);
            this.panel2.Controls.Add(this.cashierOrderForm_SoLuong);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cashierOrderForm_productID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cashierOrderForm_Type);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(680, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 336);
            this.panel2.TabIndex = 2;
            // 
            // cashierOrderForm_clearBtn
            // 
            this.cashierOrderForm_clearBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cashierOrderForm_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrderForm_clearBtn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.cashierOrderForm_clearBtn.ForeColor = System.Drawing.Color.White;
            this.cashierOrderForm_clearBtn.Location = new System.Drawing.Point(190, 224);
            this.cashierOrderForm_clearBtn.Name = "cashierOrderForm_clearBtn";
            this.cashierOrderForm_clearBtn.Size = new System.Drawing.Size(93, 39);
            this.cashierOrderForm_clearBtn.TabIndex = 27;
            this.cashierOrderForm_clearBtn.Text = "LÀM MỚI";
            this.cashierOrderForm_clearBtn.UseVisualStyleBackColor = false;
            // 
            // cashierOrderForm_removeBtn
            // 
            this.cashierOrderForm_removeBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cashierOrderForm_removeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrderForm_removeBtn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.cashierOrderForm_removeBtn.ForeColor = System.Drawing.Color.White;
            this.cashierOrderForm_removeBtn.Location = new System.Drawing.Point(99, 224);
            this.cashierOrderForm_removeBtn.Name = "cashierOrderForm_removeBtn";
            this.cashierOrderForm_removeBtn.Size = new System.Drawing.Size(65, 39);
            this.cashierOrderForm_removeBtn.TabIndex = 26;
            this.cashierOrderForm_removeBtn.Text = "XÓA";
            this.cashierOrderForm_removeBtn.UseVisualStyleBackColor = false;
            // 
            // cashierOrderForm_addBtn
            // 
            this.cashierOrderForm_addBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cashierOrderForm_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrderForm_addBtn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.cashierOrderForm_addBtn.ForeColor = System.Drawing.Color.White;
            this.cashierOrderForm_addBtn.Location = new System.Drawing.Point(12, 224);
            this.cashierOrderForm_addBtn.Name = "cashierOrderForm_addBtn";
            this.cashierOrderForm_addBtn.Size = new System.Drawing.Size(65, 39);
            this.cashierOrderForm_addBtn.TabIndex = 25;
            this.cashierOrderForm_addBtn.Text = "THÊM";
            this.cashierOrderForm_addBtn.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Giá ($): ";
            // 
            // cashierOrderForm_price
            // 
            this.cashierOrderForm_price.AutoSize = true;
            this.cashierOrderForm_price.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrderForm_price.Location = new System.Drawing.Point(114, 146);
            this.cashierOrderForm_price.Name = "cashierOrderForm_price";
            this.cashierOrderForm_price.Size = new System.Drawing.Size(34, 16);
            this.cashierOrderForm_price.TabIndex = 22;
            this.cashierOrderForm_price.Text = "100";
            // 
            // cashierOrderForm_prodName
            // 
            this.cashierOrderForm_prodName.AutoSize = true;
            this.cashierOrderForm_prodName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrderForm_prodName.Location = new System.Drawing.Point(114, 67);
            this.cashierOrderForm_prodName.Name = "cashierOrderForm_prodName";
            this.cashierOrderForm_prodName.Size = new System.Drawing.Size(108, 16);
            this.cashierOrderForm_prodName.TabIndex = 20;
            this.cashierOrderForm_prodName.Text = "Sản phẩm thử";
            // 
            // cashierOrderForm_SoLuong
            // 
            this.cashierOrderForm_SoLuong.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cashierOrderForm_SoLuong.Location = new System.Drawing.Point(117, 187);
            this.cashierOrderForm_SoLuong.Name = "cashierOrderForm_SoLuong";
            this.cashierOrderForm_SoLuong.Size = new System.Drawing.Size(94, 24);
            this.cashierOrderForm_SoLuong.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tên SP:";
            // 
            // cashierOrderForm_productID
            // 
            this.cashierOrderForm_productID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrderForm_productID.FormattingEnabled = true;
            this.cashierOrderForm_productID.Items.AddRange(new object[] {
            "Quản trị viên",
            "Thu ngân"});
            this.cashierOrderForm_productID.Location = new System.Drawing.Point(117, 101);
            this.cashierOrderForm_productID.Name = "cashierOrderForm_productID";
            this.cashierOrderForm_productID.Size = new System.Drawing.Size(95, 24);
            this.cashierOrderForm_productID.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã SP:";
            // 
            // cashierOrderForm_Type
            // 
            this.cashierOrderForm_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrderForm_Type.FormattingEnabled = true;
            this.cashierOrderForm_Type.Items.AddRange(new object[] {
            "Quản trị viên",
            "Thu ngân"});
            this.cashierOrderForm_Type.Location = new System.Drawing.Point(117, 18);
            this.cashierOrderForm_Type.Name = "cashierOrderForm_Type";
            this.cashierOrderForm_Type.Size = new System.Drawing.Size(167, 24);
            this.cashierOrderForm_Type.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Loại:";
            // 
            // cashierOrderForm_orderTable
            // 
            this.cashierOrderForm_orderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cashierOrderForm_orderTable.Location = new System.Drawing.Point(21, 20);
            this.cashierOrderForm_orderTable.Name = "cashierOrderForm_orderTable";
            this.cashierOrderForm_orderTable.RowHeadersWidth = 62;
            this.cashierOrderForm_orderTable.Size = new System.Drawing.Size(617, 262);
            this.cashierOrderForm_orderTable.TabIndex = 3;
            this.cashierOrderForm_orderTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cashierOrderForm_orderTable_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.cashierOrderForm_payBtn);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.cashierOrderForm_change);
            this.panel3.Controls.Add(this.cashierOrderForm_amount);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cashierOrderForm_orderPrice);
            this.panel3.Controls.Add(this.cashierOrderForm_orderTable);
            this.panel3.Location = new System.Drawing.Point(17, 363);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(962, 292);
            this.panel3.TabIndex = 1;
            // 
            // cashierOrderForm_payBtn
            // 
            this.cashierOrderForm_payBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cashierOrderForm_payBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashierOrderForm_payBtn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrderForm_payBtn.ForeColor = System.Drawing.Color.White;
            this.cashierOrderForm_payBtn.Location = new System.Drawing.Point(691, 186);
            this.cashierOrderForm_payBtn.Name = "cashierOrderForm_payBtn";
            this.cashierOrderForm_payBtn.Size = new System.Drawing.Size(239, 43);
            this.cashierOrderForm_payBtn.TabIndex = 41;
            this.cashierOrderForm_payBtn.Text = "THANH TOÁN";
            this.cashierOrderForm_payBtn.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(687, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 16);
            this.label12.TabIndex = 40;
            this.label12.Text = "Tiền thối ($): ";
            // 
            // cashierOrderForm_change
            // 
            this.cashierOrderForm_change.AutoSize = true;
            this.cashierOrderForm_change.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrderForm_change.Location = new System.Drawing.Point(834, 122);
            this.cashierOrderForm_change.Name = "cashierOrderForm_change";
            this.cashierOrderForm_change.Size = new System.Drawing.Size(16, 16);
            this.cashierOrderForm_change.TabIndex = 39;
            this.cashierOrderForm_change.Text = "0";
            // 
            // cashierOrderForm_amount
            // 
            this.cashierOrderForm_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrderForm_amount.Location = new System.Drawing.Point(819, 85);
            this.cashierOrderForm_amount.Name = "cashierOrderForm_amount";
            this.cashierOrderForm_amount.Size = new System.Drawing.Size(85, 22);
            this.cashierOrderForm_amount.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(687, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "Thành tiền ($): ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(687, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "Giá ($): ";
            // 
            // cashierOrderForm_orderPrice
            // 
            this.cashierOrderForm_orderPrice.AutoSize = true;
            this.cashierOrderForm_orderPrice.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierOrderForm_orderPrice.Location = new System.Drawing.Point(815, 49);
            this.cashierOrderForm_orderPrice.Name = "cashierOrderForm_orderPrice";
            this.cashierOrderForm_orderPrice.Size = new System.Drawing.Size(34, 16);
            this.cashierOrderForm_orderPrice.TabIndex = 35;
            this.cashierOrderForm_orderPrice.Text = "100";
            // 
            // LapHoaDonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "LapHoaDonForm";
            this.Size = new System.Drawing.Size(982, 666);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierOrderForm_menuTable)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierOrderForm_SoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashierOrderForm_orderTable)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView cashierOrderForm_menuTable;
        private Panel panel2;
        private Button cashierOrderForm_clearBtn;
        private Button cashierOrderForm_removeBtn;
        private Button cashierOrderForm_addBtn;
        private Label label9;
        private Label cashierOrderForm_price;
        private Label cashierOrderForm_prodName;
        private NumericUpDown cashierOrderForm_SoLuong;
        private Label label4;
        private Label label3;
        private ComboBox cashierOrderForm_productID;
        private Label label2;
        private ComboBox cashierOrderForm_Type;
        private Label label5;
        private DataGridView cashierOrderForm_orderTable;
        private Panel panel3;
        private Button cashierOrderForm_payBtn;
        private Label label12;
        private Label cashierOrderForm_change;
        private TextBox cashierOrderForm_amount;
        private Label label11;
        private Label label8;
        private Label cashierOrderForm_orderPrice;
    }
}
