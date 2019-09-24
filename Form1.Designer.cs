namespace Shallow_Learning_Frame
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reseace_button = new System.Windows.Forms.Button();
            this.remain_turn_label = new System.Windows.Forms.Label();
            this.sending_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.red_points = new System.Windows.Forms.Label();
            this.blue_points = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.reseace_button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.remain_turn_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sending_button, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.next_button, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.red_points, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.blue_points, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(879, 131);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // reseace_button
            // 
            this.reseace_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reseace_button.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.reseace_button.Location = new System.Drawing.Point(3, 68);
            this.reseace_button.Name = "reseace_button";
            this.reseace_button.Size = new System.Drawing.Size(287, 60);
            this.reseace_button.TabIndex = 3;
            this.reseace_button.Text = "リセット";
            this.reseace_button.UseVisualStyleBackColor = true;
            this.reseace_button.Click += new System.EventHandler(this.reseace_button_Click);
            // 
            // remain_turn_label
            // 
            this.remain_turn_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remain_turn_label.AutoSize = true;
            this.remain_turn_label.Font = new System.Drawing.Font("MS UI Gothic", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.remain_turn_label.Location = new System.Drawing.Point(3, 0);
            this.remain_turn_label.Name = "remain_turn_label";
            this.remain_turn_label.Size = new System.Drawing.Size(287, 65);
            this.remain_turn_label.TabIndex = 2;
            this.remain_turn_label.Text = "remain_turn_label";
            // 
            // sending_button
            // 
            this.sending_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sending_button.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sending_button.Location = new System.Drawing.Point(296, 68);
            this.sending_button.Name = "sending_button";
            this.sending_button.Size = new System.Drawing.Size(287, 60);
            this.sending_button.TabIndex = 4;
            this.sending_button.Text = "送信";
            this.sending_button.UseVisualStyleBackColor = true;
            this.sending_button.Click += new System.EventHandler(this.sending_button_Click);
            // 
            // next_button
            // 
            this.next_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.next_button.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.next_button.Location = new System.Drawing.Point(589, 68);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(287, 60);
            this.next_button.TabIndex = 5;
            this.next_button.Text = "受信";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // red_points
            // 
            this.red_points.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.red_points.AutoSize = true;
            this.red_points.Font = new System.Drawing.Font("MS UI Gothic", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.red_points.Location = new System.Drawing.Point(589, 0);
            this.red_points.Name = "red_points";
            this.red_points.Size = new System.Drawing.Size(287, 65);
            this.red_points.TabIndex = 1;
            this.red_points.Text = "red_points : タイル : 領域";
            // 
            // blue_points
            // 
            this.blue_points.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blue_points.AutoSize = true;
            this.blue_points.Font = new System.Drawing.Font("MS UI Gothic", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.blue_points.Location = new System.Drawing.Point(296, 0);
            this.blue_points.Name = "blue_points";
            this.blue_points.Size = new System.Drawing.Size(287, 65);
            this.blue_points.TabIndex = 0;
            this.blue_points.Text = "blue_points : タイル : 領域";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 512);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button reseace_button;
        private System.Windows.Forms.Label remain_turn_label;
        private System.Windows.Forms.Button sending_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Label red_points;
        private System.Windows.Forms.Label blue_points;
        private System.Windows.Forms.Button[,] massButtons;
    }
}

