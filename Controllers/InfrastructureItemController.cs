using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudControl.DataContexts;
using CloudControl.Services;
using CloudControl.Models;
using CloudControl.ViewModels;
using Microsoft.Extensions.Logging;

namespace CloudControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfrastructureItemController : ControllerBase
    {

        private readonly CloudContext _context;
        private readonly CloudService _cloudService;
        public InfrastructureItemController(CloudContext context, CloudService cloudService)
        {
            _context = context;
            _cloudService = cloudService;
                      
        }

        [Route("/api/[controller]/AddInfrastructureItem")]
        [HttpPost]
        public async Task<ActionResult> AddInfrastructureItem(ViewModels.VmInfrastructureItem vmInfrastructureItem)
        {
            try
            {
             
                long res =  await _cloudService.AddInfrastructureItem(vmInfrastructureItem);
                if (res > 0)
                {
                    return Ok("Succesded, new InfrastructureItemID = " + res);
                }
                else
                {
                    return Problem("Problem on creating new InfrastructureItem");
                }

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        // call this api to create folder and json files on harddisk
        [Route("/api/[controller]/SyncFolder")]
        [HttpPost]
        public async Task<ActionResult> SyncFolder()
        {
            try
            {
                
                bool res = await _cloudService.SyncFolder();
                if (res )
                {
                    return Ok("Succesded.");
                }
                else
                {
                    return Problem("Problem on sync folder");
                }

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }


}
