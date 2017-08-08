using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThailandAddress.Initializer.Model;

namespace ThailandAddress.Initializer
{
    public partial class AppForm : Form
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public AppForm()
        {
            InitializeComponent();
        }

        private void Area()
        {
            var items = GetTemplate<List<AreaTemplate>>(@"Template\districts.json");

            foreach (var item in items)
            {
                try
                {
                    var info = new AreaInfo();
                    info.Code = item.DISTRICT_CODE;
                    info.Id = item.DISTRICT_ID;
                    info.Name = item.DISTRICT_NAME;
                    info.ProvinceId = item.PROVINCE_ID;

                    using (var context = new ThailandAddressMsSqlEntities())
                    {
                        context.AreaInfoes.Add(info);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Area || {ex}");
                }
            }
        }

        private void Geography()
        {
            var items = GetTemplate<List<GeographyTemplate>>(@"Template\geography.json");

            foreach(var item in items)
            {
                try
                {
                    var info = new GeographyInfo();
                    info.Id = item.GEO_ID;
                    info.Name = item.GEO_NAME;

                    using (var context = new ThailandAddressMsSqlEntities())
                    {
                        context.GeographyInfoes.Add(info);
                        context.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    _logger.Error($"Geography || {ex}");
                }
            }
        }

        private T GetTemplate<T>(string path) where T : new()
        {
            var item = new T();

            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                item = JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                _logger.Warn($"GetTemplate || Path '{path}' was not found.");
            }
            return item;
        }

        private void PostalCode()
        {
            var items = GetTemplate<List<PostalCodeTemplate>>(@"Template\zipcodes.json");

            foreach(var item in items)
            {
                try
                {
                    var info = new PostalCodeInfo();
                    info.Code = item.ZIPCODE;
                    info.Id = item.ZIPCODE_ID;
                    info.SubAreaId = Convert.ToInt32(item.SUB_DISTRICT_ID);

                    using (var context = new ThailandAddressMsSqlEntities())
                    {
                        context.PostalCodeInfoes.Add(info);
                        context.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    _logger.Error($"PostalCode || {ex}");
                }
            }
        }

        private void Province()
        {
            var items = GetTemplate<List<ProvinceTemplate>>(@"Template\provinces.json");

            foreach(var item in items)
            {
                try
                {
                    var info = new ProvinceInfo();
                    info.Code = item.PROVINCE_CODE;
                    info.GeographyId = item.GEO_ID;
                    info.Id = item.PROVINCE_ID;
                    info.Name = item.PROVINCE_NAME;

                    using (var context = new ThailandAddressMsSqlEntities())
                    {
                        context.ProvinceInfoes.Add(info);
                        context.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    _logger.Error($"Province || {ex}");
                }
            }
        }

        private void SubArea()
        {
            var items = GetTemplate<List<SubAreaTemplate>>(@"Template\subDistricts.json");

            foreach(var item in items)
            {
                try
                {
                    var info = new SubAreaInfo();
                    info.AreaId = item.DISTRICT_ID;
                    info.Code = item.SUB_DISTRICT_CODE;
                    info.Id = item.SUB_DISTRICT_ID;
                    info.Name = item.SUB_DISTRICT_NAME;

                    using (var context = new ThailandAddressMsSqlEntities())
                    {
                        context.SubAreaInfoes.Add(info);
                        context.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    _logger.Error($"SubArea || {ex}");
                }
            }
        }
    }
}
