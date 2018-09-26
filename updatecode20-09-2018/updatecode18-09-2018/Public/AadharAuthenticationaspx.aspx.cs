using nicmp.sch;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Public_AadharAuthenticationaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Visible = false;
    }
    protected void btnCheckAuthentication_Click(object sender, EventArgs e)
    {
        if (Captcha.UserValidated)
        {

            lblmsg.Visible = true;
            if (txtAadhaarNumber.Text == "")
            {
                MessageBox.Show("Enter Aadhaar Number.");
                txtAadhaarNumber.Focus();
                return;
            }

            if (txtname.Text == "")
            {
                MessageBox.Show("Enter Name.");
                txtname.Focus();
                return;
            }

            if (ddlGender.SelectedValue == "0")
            {
                MessageBox.Show("select Gender.");
                ddlGender.Focus();
                return;
            }

            AadharBase.KYC_AADHAAR = txtAadhaarNumber.Text;
            Applicant output_insert =
                new Applicant(System.Configuration.ConfigurationManager.ConnectionStrings["SS8SCHP"].ToString());

            if (AadharBase.isValidAadhaar(txtAadhaarNumber.Text))
            {


                String resp;
                resp = AadharBase.AadhaarAuthentication(txtAadhaarNumber.Text, txtname.Text,
                    ddlGender.SelectedValue.ToString());
                if (resp.Length == 72)
                {
                    output_insert.AuditTrail(txtAadhaarNumber.Text, DateTime.Now.ToString(), "Success");
                    lblmsg.Text = "Authentication Successfull.";
                    lblmsg.ForeColor = Color.Green;

                }
                else
                {
                    output_insert.AuditTrail(txtAadhaarNumber.Text, DateTime.Now.ToString(), "Fail");
                    lblmsg.Text = "Authentication Unsuccessfull.";
                    lblmsg.ForeColor = Color.Maroon;
                }
            }
            else
            {
                lblmsg.Text = "Invalid Aadhaar Card.";
                lblmsg.ForeColor = Color.Maroon;


            }
        }
        else
        {
            MessageBox.Show("ERROR:Please enter the code shown in image ");



        }


    }

    protected void txtAadhaarNumber_TextChanged(object sender, EventArgs e)
    {
          if (AadharBase.isValidAadhaar(txtAadhaarNumber.Text)) {
            txtAadhaarNumber.ForeColor = Color.Green;
            txtname.Focus();

          }
          else
          {
            txtAadhaarNumber.ForeColor = Color.Red;
            txtAadhaarNumber.Focus();
      }
       
    }
}