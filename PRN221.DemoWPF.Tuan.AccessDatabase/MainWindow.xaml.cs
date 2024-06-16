using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN221.DemoWPF.Tuan.AccessDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ManageCategories categories = new ManageCategories();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadCategories();

        private void LoadCategories()
        {
            try
            {
                lvCategories.ItemsSource = categories.GetCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Categories");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category { CategoryName = txtCategoryName.Text };
                categories.InsertCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Category");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category
                {
                    CategoryID = int.Parse(txtCategoryID.Text),
                    CategoryName = txtCategoryName.Text
                };
                categories.UpdateCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Category");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category
                {
                    CategoryID = int.Parse(txtCategoryID.Text)
                };
                categories.DeleteCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Category");
            }
        }
    }

    public record Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
    public class ManageCategories
    {
        SqlConnection connection;
        SqlCommand command;
        string ConnectionString = "Server=(local); uid=sa;pwd=12345; database=MyStore";
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            connection = new SqlConnection(ConnectionString);
            string SQL = "Select CategoryID, CategoryName from Categories";
            command = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                SqlDataReader reader= command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryID = reader.GetInt32("CategoryID"),
                            CategoryName = reader.GetString("CategoryName")
                        });
                    }//end while
                }//end if
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return categories;
        }//end GetCategories
        public void InsertCategory(Category category)
        {
            connection = new SqlConnection(ConnectionString);
            //CategoryID is identity
            command = new SqlCommand("Insert Categories values (@CategoryName)", connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }//end InsertCategory
        public void UpdateCategory(Category category)
        {
            connection = new SqlConnection(ConnectionString);
            string SQL = "Update Categories set CategoryName=@CategoryName where CategoryID=@CategoryID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }//end UpdateCategory
        public void DeleteCategory(Category category)
        {
            connection = new SqlConnection(ConnectionString);
            string SQL = "Delete Categories where CategoryID=@CategoryID";
            command = new SqlCommand(SQL, connection);
            command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }//end DeleteCategory
    }

}