private void BindGridView()
        {
            string contractCode = txtContractCode.Text.Trim();
            byte[] binaryData = Encoding.UTF8.GetBytes("");
            dt = bll.sprExportContactEntryTableAdapter(17, "", contractCode, 0, 0, 0, 0, 0.0M, 0.0M, 0, 0, 0, "", 0, 0, binaryData, "", "", "", "", DateTime.Now, DateTime.Now, "", "");
            assetGridviewID.DataSource = dt;
            assetGridviewID.DataBind();
        }
        private DataTable GetCountData()
        {
            byte[] binaryData = Encoding.UTF8.GetBytes("");
            return bll.sprExportContactEntryTableAdapter(15, "", "", 0, 0, 0, 0, 0.0M, 0.0M, 0, 0, 0, "", 0, 0, binaryData, "", "", "", "", DateTime.Now, DateTime.Now, "", "");
        }

        private DataTable GetQualityData()
        {
            byte[] binaryData = Encoding.UTF8.GetBytes("");
            return bll.sprExportContactEntryTableAdapter(16, "", "", 0, 0, 0, 0, 0.0M, 0.0M, 0, 0, 0, "", 0, 0, binaryData, "", "", "", "", DateTime.Now, DateTime.Now, "", "");
        }

        private void GetCount(int intCountID, DropDownList ddl)
        {
            DataTable countData = GetCountData();
            ddl.DataSource = countData;
            ddl.DataValueField = "intCountID";
            ddl.DataTextField = "strCountName";
            ddl.DataBind();

            ddl.SelectedValue = intCountID.ToString();
        }

        private void GetQuality(int intQualityID, DropDownList ddl)
        {
            DataTable qualityData = GetQualityData();
            ddl.DataSource = qualityData;
            ddl.DataValueField = "intQualityID";
            ddl.DataTextField = "strQuality";
            ddl.DataBind();

            ddl.SelectedValue = intQualityID.ToString();
        }

        protected void assetGridviewID_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList countDropDown = (DropDownList)e.Row.FindControl("countID");
                int intCount = int.Parse(dt.Rows[e.Row.RowIndex]["countID"].ToString());
                GetCount(intCount, countDropDown);

                DropDownList qualityDropDown = (DropDownList)e.Row.FindControl("qualityID");
                int intQuality = int.Parse(dt.Rows[e.Row.RowIndex]["qualityID"].ToString());
                GetQuality(intQuality, qualityDropDown);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridView();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something wrong! Please try again');", true);
            }
        }
        protected void calculatePrice(object sender, EventArgs e)
        {

            try
            {
                foreach (GridViewRow row in assetGridviewID.Rows)
                {
                    // Find controls in the GridView row
                    TextBox quantityTextBox = (TextBox)row.FindControl("quantity");
                    TextBox unitPriceTextBox = (TextBox)row.FindControl("untPrice");
                    Label totalPriceLabel = (Label)row.FindControl("totalPrice");

                    // Perform calculation if both Quantity and Unit Price are not empty
                    if (!string.IsNullOrEmpty(quantityTextBox.Text) && !string.IsNullOrEmpty(unitPriceTextBox.Text))
                    {
                        // Parse values from TextBoxes
                        int quantity = int.Parse(quantityTextBox.Text);
                        decimal unitPrice = decimal.Parse(unitPriceTextBox.Text);

                        // Calculate total amount and update the Label
                        decimal totalPrice = quantity * unitPrice;
                        totalPriceLabel.Text = totalPrice.ToString();
                    }
                }

            }
            catch { }
        }
        protected void btnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                string clickHist = ((Button)sender).ClientID.ToString();
                string[] chars;
                chars = clickHist.Split('_');
                int clickedRow = int.Parse(chars[2]);

                int srid = int.Parse(((Button)sender).CommandArgument.ToString());

                DropDownList count = (DropDownList)assetGridviewID.Rows[clickedRow].FindControl("countID");
                int countId = int.Parse(count.SelectedValue.Trim());

                DropDownList quality = (DropDownList)assetGridviewID.Rows[clickedRow].FindControl("qualityID");
                int qualityId = int.Parse(quality.SelectedValue.Trim());

                TextBox quan = (TextBox)assetGridviewID.Rows[clickedRow].FindControl("quantity");
                decimal quantityId = Convert.ToDecimal(quan.Text.Trim());

                TextBox untPric = (TextBox)assetGridviewID.Rows[clickedRow].FindControl("untPrice");
                decimal unitPriceID = Convert.ToDecimal(untPric.Text.Trim());

                byte[] binaryData = Encoding.UTF8.GetBytes("");
                dt = bll.sprExportContactEntryTableAdapter(18, "", "", 0, 0, countId, qualityId, quantityId, unitPriceID, srid, 0, 0, "", 0, 0, binaryData, "", "", "", "", DateTime.Now, DateTime.Now, "", "");
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Updated Successfully!');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something wrong! Please try again');", true);
            }
        }
