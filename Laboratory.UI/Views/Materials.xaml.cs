using Laboratory.Shared.ViewModels;
using Laboratory.UI.HttpHelper;
using Laboratory.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratory.UI.Views
{
    /// <summary>
    /// Interaction logic for Materials.xaml
    /// </summary>
    public partial class Materials : UserControl
    {
        public Materials()
        {
            InitializeComponent();
            GetMaterialsAsync();
        }


        private void deletBtn_Click(object sender, RoutedEventArgs e)
        {
            var material = (MaterialViewModel)materialsGrid.SelectedItem;
            var confirmDialog = new ConifrmationDialog(SD.Material_Delete_Confirmation, material.Id, null, null, this,"Materials.png");
            confirmDialog.ShowDialog();
        }

        public void Delete_Material(int Id)
        {
            MaterialHelper.DeleteMaterialAsync(Id);
            GetMaterialsAsync();
            ClearInput();
        }

        public void GetMaterialsAsync()
        {
            Task<List<MaterialViewModel>> materialsTask = MaterialHelper.GetMaterialsAsync();
            List<MaterialViewModel> materials = materialsTask.Result;
            materialsGrid.Items.Clear();
            foreach (var item in materials)
            {
                materialsGrid.Items.Add(new MaterialViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Volume = item.Volume,
                    OpenDate = item.OpenDate,
                    ExpireDate = item.ExpireDate,
                });
            }
        }

        public void ClearInput()
        {
            txtMaterialName.Clear();
            txtMaterialVolume.Clear();
            pickerOpenDate.SelectedDate = null;
            pickerExpireDate.SelectedDate = null;
        }

        private async void addMaterial_Click(object sender, RoutedEventArgs e)
        {
            if ((string)addMaterial.Content == "Add")
            {
                await AddMaterial();
            }
            else if ((string)addMaterial.Content == "Update")
            {
                await Update_Material();
            }
        }

        private async Task AddMaterial()
        {
            MaterialViewModel material = new MaterialViewModel();
            material.Name = txtMaterialName.Text;
            material.Volume = txtMaterialVolume.Text;
            material.OpenDate = Convert.ToDateTime(pickerOpenDate.Text);
            material.ExpireDate = Convert.ToDateTime(pickerExpireDate.Text);
            await MaterialHelper.AddOrUpdateMaterialAsync(material);
            GetMaterialsAsync();
            ClearInput();
        }

        private async Task Update_Material()
        {
            var material = (MaterialViewModel)materialsGrid.SelectedItem;

            material.Volume = txtMaterialVolume.Text;
            material.Name = txtMaterialName.Text;
            material.ExpireDate = Convert.ToDateTime(pickerExpireDate.Text);
            material.OpenDate = Convert.ToDateTime(pickerOpenDate.Text);
            await MaterialHelper.AddOrUpdateMaterialAsync(material);
            GetMaterialsAsync();
            ClearInput();
            addMaterial.Content = "Add";
        }

        private void materialsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addMaterial.Content = "Update";
            var material = (MaterialViewModel)materialsGrid.SelectedItem;
            if (material != null)
            {
                txtMaterialName.Text = material.Name;
                txtMaterialVolume.Text = material.Volume;
                pickerExpireDate.Text = material.ExpireDate.ToString();
                pickerOpenDate.Text = material.OpenDate.ToString();
            }
        }
    }
}
