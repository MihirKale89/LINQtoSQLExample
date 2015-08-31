using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInterface
{
    public partial class UserInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("DisplayInput.aspx");

        }

        protected void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            if (TextBoxID.Text.Equals("") || TextBoxName.Text.Equals("") || TextBoxAge.Text.Equals("") || TextBoxUniversity.Text.Equals(""))
            {
                Response.Write("<script language='javascript'>alert('Please fill all the fields.');</script>");
            }
            else
            {
                Student stu = new Student();
                stu.Student_Age = Convert.ToInt32(TextBoxAge.Text);
                stu.Student_Name = TextBoxName.Text;
                stu.Student_Id = TextBoxID.Text;
                stu.Student_University = TextBoxUniversity.Text;
                StudentsDBDataClassesDataContext db = new StudentsDBDataClassesDataContext();
                db.Students.InsertOnSubmit(stu);
                db.SubmitChanges();
                TextBoxID.Text = "";
                TextBoxAge.Text = "";
                TextBoxName.Text = "";
                TextBoxUniversity.Text = "";
                
            }

        }
    }
}