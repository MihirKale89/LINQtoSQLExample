using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button_Back_To_User_Input_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInput.aspx");
        }

        protected void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBoxID.Text.Equals("") || TextBoxName.Text.Equals("") || TextBoxAge.Text.Equals("") || TextBoxUniversity.Text.Equals(""))
            {
                Response.Write("<script language='javascript'>alert('Please fill all the fields.');</script>");
            }
            else
            {
                String stu_Id = TextBoxID.Text;
                StudentsDBDataClassesDataContext db = new StudentsDBDataClassesDataContext();
                Student stu = db.Students.Single(u => u.Student_Id == stu_Id);
                stu.Student_Age = Convert.ToInt32(TextBoxAge.Text);
                stu.Student_Name = TextBoxName.Text;
                stu.Student_University = TextBoxUniversity.Text;
                db.SubmitChanges();
                TextBoxID.Text = "";
                TextBoxAge.Text = "";
                TextBoxName.Text = "";
                TextBoxUniversity.Text = "";
                GridView1.DataBind();
            }

        }

        protected void DeleteStudent_Click(object sender, EventArgs e)
        {
            if (TextBoxDeleteId.Text.Equals("") )
            {
                Response.Write("<script language='javascript'>alert('Please fill the Delete Id field.');</script>");
            }
            else
            {
                String stu_Id = TextBoxDeleteId.Text;
                StudentsDBDataClassesDataContext db = new StudentsDBDataClassesDataContext();
                Student stu = db.Students.Single(u => u.Student_Id == stu_Id);
                db.Students.DeleteOnSubmit(stu);
                db.SubmitChanges();
                TextBoxDeleteId.Text = "";
                GridView1.DataBind();
            }
        }
    }
}