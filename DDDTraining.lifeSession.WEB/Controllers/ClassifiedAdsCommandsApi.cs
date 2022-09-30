using DDDTraining.lifeSession.Application;
using DDDTraining.lifeSession.Application.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.WEB.Controllers
{
    [Route("/ad")]
    public class ClassifiedAdsCommandsApi : Controller
    {
        private readonly ClassifiedAdsApplicationService
       _applicationService;

        public ClassifiedAdsCommandsApi(
        ClassifiedAdsApplicationService applicationService)
        => _applicationService = applicationService;


        [HttpPost]
        public async Task<IActionResult> Post(
                  ClassifiedAds.V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("name")]
        [HttpPut]
        public async Task<IActionResult> Put(ClassifiedAds.V1.SetTitle request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
        [Route("text")]
        [HttpPut]
        public async Task<IActionResult> Put(ClassifiedAds.V1.UpdateText request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
        [Route("price")]
        [HttpPut]
        public async Task<IActionResult> Put(ClassifiedAds.V1.UpdatePrice request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
        [Route("publish")]
        [HttpPut]
        public async Task<IActionResult> Put(ClassifiedAds.V1.RequestToPublish request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
