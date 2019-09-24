namespace Shallow_Learning_Frame
{
    partial class Input_UC
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.GB_dir = new System.Windows.Forms.GroupBox();
            this.BR = new System.Windows.Forms.RadioButton();
            this.Right = new System.Windows.Forms.RadioButton();
            this.Buttom = new System.Windows.Forms.RadioButton();
            this.Center = new System.Windows.Forms.RadioButton();
            this.UR = new System.Windows.Forms.RadioButton();
            this.Upper = new System.Windows.Forms.RadioButton();
            this.BL = new System.Windows.Forms.RadioButton();
            this.Left = new System.Windows.Forms.RadioButton();
            this.UL = new System.Windows.Forms.RadioButton();
            this.GB_type = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.RB_move = new System.Windows.Forms.RadioButton();
            this.RB_remove = new System.Windows.Forms.RadioButton();
            this.RB_stay = new System.Windows.Forms.RadioButton();
            this.GB_dir.SuspendLayout();
            this.GB_type.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_dir
            // 
            this.GB_dir.Controls.Add(this.BR);
            this.GB_dir.Controls.Add(this.Right);
            this.GB_dir.Controls.Add(this.Buttom);
            this.GB_dir.Controls.Add(this.Center);
            this.GB_dir.Controls.Add(this.UR);
            this.GB_dir.Controls.Add(this.Upper);
            this.GB_dir.Controls.Add(this.BL);
            this.GB_dir.Controls.Add(this.Left);
            this.GB_dir.Controls.Add(this.UL);
            this.GB_dir.Location = new System.Drawing.Point(3, 3);
            this.GB_dir.Name = "GB_dir";
            this.GB_dir.Size = new System.Drawing.Size(270, 290);
            this.GB_dir.TabIndex = 0;
            this.GB_dir.TabStop = false;
            this.GB_dir.Text = "agentID";
            // 
            // BR
            // 
            this.BR.Appearance = System.Windows.Forms.Appearance.Button;
            this.BR.Location = new System.Drawing.Point(178, 210);
            this.BR.Name = "BR";
            this.BR.Size = new System.Drawing.Size(80, 80);
            this.BR.TabIndex = 0;
            this.BR.TabStop = true;
            this.BR.Text = "↘";
            this.BR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BR.UseVisualStyleBackColor = true;
            // 
            // Right
            // 
            this.Right.Appearance = System.Windows.Forms.Appearance.Button;
            this.Right.Location = new System.Drawing.Point(178, 124);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(80, 80);
            this.Right.TabIndex = 0;
            this.Right.TabStop = true;
            this.Right.Text = "→";
            this.Right.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Right.UseVisualStyleBackColor = true;
            // 
            // Buttom
            // 
            this.Buttom.Appearance = System.Windows.Forms.Appearance.Button;
            this.Buttom.Location = new System.Drawing.Point(92, 210);
            this.Buttom.Name = "Buttom";
            this.Buttom.Size = new System.Drawing.Size(80, 80);
            this.Buttom.TabIndex = 0;
            this.Buttom.TabStop = true;
            this.Buttom.Text = "↓";
            this.Buttom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Buttom.UseVisualStyleBackColor = true;
            // 
            // Center
            // 
            this.Center.Appearance = System.Windows.Forms.Appearance.Button;
            this.Center.Location = new System.Drawing.Point(92, 124);
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(80, 80);
            this.Center.TabIndex = 0;
            this.Center.TabStop = true;
            this.Center.Text = "〇";
            this.Center.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Center.UseVisualStyleBackColor = true;
            // 
            // UR
            // 
            this.UR.Appearance = System.Windows.Forms.Appearance.Button;
            this.UR.Location = new System.Drawing.Point(178, 38);
            this.UR.Name = "UR";
            this.UR.Size = new System.Drawing.Size(80, 80);
            this.UR.TabIndex = 0;
            this.UR.TabStop = true;
            this.UR.Text = "↗";
            this.UR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UR.UseVisualStyleBackColor = true;
            // 
            // Upper
            // 
            this.Upper.Appearance = System.Windows.Forms.Appearance.Button;
            this.Upper.Location = new System.Drawing.Point(92, 38);
            this.Upper.Name = "Upper";
            this.Upper.Size = new System.Drawing.Size(80, 80);
            this.Upper.TabIndex = 0;
            this.Upper.TabStop = true;
            this.Upper.Text = "↑";
            this.Upper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Upper.UseVisualStyleBackColor = true;
            // 
            // BL
            // 
            this.BL.Appearance = System.Windows.Forms.Appearance.Button;
            this.BL.Location = new System.Drawing.Point(6, 210);
            this.BL.Name = "BL";
            this.BL.Size = new System.Drawing.Size(80, 80);
            this.BL.TabIndex = 0;
            this.BL.TabStop = true;
            this.BL.Text = "↙";
            this.BL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BL.UseVisualStyleBackColor = true;
            // 
            // Left
            // 
            this.Left.Appearance = System.Windows.Forms.Appearance.Button;
            this.Left.Location = new System.Drawing.Point(6, 124);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(80, 80);
            this.Left.TabIndex = 0;
            this.Left.TabStop = true;
            this.Left.Text = "←";
            this.Left.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Left.UseVisualStyleBackColor = true;
            // 
            // UL
            // 
            this.UL.Appearance = System.Windows.Forms.Appearance.Button;
            this.UL.Location = new System.Drawing.Point(6, 38);
            this.UL.Name = "UL";
            this.UL.Size = new System.Drawing.Size(80, 80);
            this.UL.TabIndex = 0;
            this.UL.TabStop = true;
            this.UL.Text = "↖";
            this.UL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UL.UseVisualStyleBackColor = true;
            // 
            // GB_type
            // 
            this.GB_type.Controls.Add(this.RB_stay);
            this.GB_type.Controls.Add(this.RB_remove);
            this.GB_type.Controls.Add(this.RB_move);
            this.GB_type.Location = new System.Drawing.Point(279, 3);
            this.GB_type.Name = "GB_type";
            this.GB_type.Size = new System.Drawing.Size(89, 290);
            this.GB_type.TabIndex = 1;
            this.GB_type.TabStop = false;
            this.GB_type.Text = "type";
            // 
            // RB_move
            // 
            this.RB_move.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_move.Location = new System.Drawing.Point(6, 38);
            this.RB_move.Name = "RB_move";
            this.RB_move.Size = new System.Drawing.Size(80, 80);
            this.RB_move.TabIndex = 1;
            this.RB_move.TabStop = true;
            this.RB_move.Text = "move";
            this.RB_move.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_move.UseVisualStyleBackColor = true;
            // 
            // RB_remove
            // 
            this.RB_remove.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_remove.Location = new System.Drawing.Point(6, 124);
            this.RB_remove.Name = "RB_remove";
            this.RB_remove.Size = new System.Drawing.Size(80, 80);
            this.RB_remove.TabIndex = 2;
            this.RB_remove.TabStop = true;
            this.RB_remove.Text = "remove";
            this.RB_remove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_remove.UseVisualStyleBackColor = true;
            // 
            // RB_stay
            // 
            this.RB_stay.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_stay.Location = new System.Drawing.Point(6, 210);
            this.RB_stay.Name = "RB_stay";
            this.RB_stay.Size = new System.Drawing.Size(80, 80);
            this.RB_stay.TabIndex = 3;
            this.RB_stay.TabStop = true;
            this.RB_stay.Text = "stay";
            this.RB_stay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_stay.UseVisualStyleBackColor = true;
            // 
            // Input_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GB_type);
            this.Controls.Add(this.GB_dir);
            this.Name = "Input_UC";
            this.Size = new System.Drawing.Size(384, 303);
            this.GB_dir.ResumeLayout(false);
            this.GB_type.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox GB_dir;
        public System.Windows.Forms.RadioButton BR;
        public System.Windows.Forms.RadioButton Right;
        public System.Windows.Forms.RadioButton Buttom;
        public System.Windows.Forms.RadioButton Center;
        public System.Windows.Forms.RadioButton UR;
        public System.Windows.Forms.RadioButton Upper;
        public System.Windows.Forms.RadioButton BL;
        public System.Windows.Forms.RadioButton Left;
        public System.Windows.Forms.RadioButton UL;
        public System.Windows.Forms.GroupBox GB_type;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.RadioButton RB_stay;
        public System.Windows.Forms.RadioButton RB_remove;
        public System.Windows.Forms.RadioButton RB_move;
    }
}
