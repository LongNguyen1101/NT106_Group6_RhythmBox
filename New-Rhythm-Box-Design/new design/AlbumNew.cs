using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace new_design
{
    public partial class AlbumNew : Form
    {
        ApiService apiService = new ApiService(TokenManager.GetAccessToken());
        public AlbumNew()
        {
            InitializeComponent();
        }

        private async void panel1_Paint(object sender, PaintEventArgs e)
        {
            HttpResponseMessage response = await apiService.AlbumsLib_getAlbumLoad();
            string rawJson = await response.Content.ReadAsStringAsync();
            JArray albumLibData = JArray.Parse(rawJson);

            string name = "";

            foreach( JObject albumLib in albumLibData )
            {
                name = (string)albumLib["Item2"];
            }
            //string name = (string)albumLibData["Item2"];
            bunifuLabel4.Text = name;
        }
    }
}
