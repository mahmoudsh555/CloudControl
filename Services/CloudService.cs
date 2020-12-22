using CloudControl.Common;
using CloudControl.DataContexts;
using CloudControl.Models;
using CloudControl.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IO;
using System.Text.Json;
using System.Text;

namespace CloudControl.Services
{
    public class CloudService
    {
        private readonly CloudContext _context;
        private readonly AppConfiguration _appConfiguration;
        //private readonly ILogger _logger;
        private IHostingEnvironment _env;
        public CloudService(CloudContext context, AppConfiguration appConfiguration, IHostingEnvironment env)
        {
            _context = context;
            _appConfiguration = appConfiguration;
            _env = env;
            //_logger = logger;
        }


        public async Task<long> AddInfrastructureItem(VmInfrastructureItem vmInfrastructureItem)
        {
            //_logger.Information("Start " + nameof(AddMessage));
            try
            {
                InfrastructureItem infrastructureItem = new InfrastructureItem();
                infrastructureItem.InfrastructureID = vmInfrastructureItem.InfrastructureID;
                infrastructureItem.ItemTemplateID = vmInfrastructureItem.ItemTemplateID;
                infrastructureItem.Notes = vmInfrastructureItem.Notes;



                IDbContextTransaction dbContextTransaction = null;
                dbContextTransaction = _context.Database.BeginTransaction();
                _context.InfrastructureItems.Add(infrastructureItem);
                await _context.SaveChangesAsync();
                foreach (VmInfrastructureItemPropertyValue item in vmInfrastructureItem.vwInfrastructureItemPropertyValues)
                {
                    InfrastructureItemPropertyValue infrastructureItemPropertyValue = new InfrastructureItemPropertyValue();
                    infrastructureItemPropertyValue.PropertyTemplateID = item.PropertyTemplateID;
                    infrastructureItemPropertyValue.PropertyValue = item.PropertyValue;
                    infrastructureItemPropertyValue.PropertyTemplateLookupID = item.PropertyTemplateLookupID;
                    infrastructureItemPropertyValue.InfrastructureItemID = infrastructureItem.ID;
                    _context.InfrastructureItemPropertyValues.Add(infrastructureItemPropertyValue);
                }
                await _context.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();

                return infrastructureItem.ID;
            }
            catch (Exception ex)
            {
                //  _logger.LogError(ex, nameof(AddInfrastructureItem));
                return 0;
            }
        }

        public async Task<bool> SyncFolder()
        {
            List<VwInfrastructure> vwInfrastructures = await _context.VwInfrastructures.ToListAsync();
            foreach (var comp in _context.Companies.Include(i => i.Infrastructures).ToList())
            {
                CreateFolder(comp.Name);
                foreach (var infra in comp.Infrastructures)
                {
                    CreateFolder(comp.Name + @"\" + infra.Name);
                    foreach (var subInfra in vwInfrastructures.Where(w => w.CompanyID == comp.ID && w.InfrastructureID == infra.ID && w.InfrastructerParentID is null))
                    {
                        string folderPath = comp.Name + @"\" + infra.Name + @"\" + subInfra.ItemTemplateName;
                        CreateFolder(folderPath);
                        string jsonText = JsonSerializer.Serialize(vwInfrastructures.Where(w =>
                        w.CompanyID == comp.ID && w.InfrastructureID == infra.ID && w.InfrastructerParentID != null)
                            .Select(Configration => new ConfigrationOutput { 
                                ConfigrationName= Configration.ItemTemplateName,
                                ConfigrationType =Configration.PropertyTemplateName, 
                                ConfigrationValue = Configration.PropertyTemplateValue }
                        ));
                        CreateFile(folderPath + @"\Configration.json", jsonText);
                    }
                }
            }

            return true;
        }

        void CreateFolder(string folderName)
        {
            string path = (_appConfiguration.OutputFolderPath ?? _env.ContentRootPath) + @"\" + (_appConfiguration.OutputFolderName ?? @"CloudOutput\");
            path = path + @"\" + folderName;
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
        }

        void CreateFile(string fileName, string fileContent)
        {
            string path = (_appConfiguration.OutputFolderPath ?? _env.ContentRootPath) + @"\" + (_appConfiguration.OutputFolderName ?? @"CloudOutput\");
            fileName = path + @"\" + fileName;
            using (FileStream fs = File.Create(fileName))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(fileContent);
                fs.Write(info, 0, info.Length);
            }

        }

    }
}
