using LepskyiSystem.Api.Services;
using LepskyiSystem.Dto.RawDataDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LepskyiSystem.Api.Controllers
{
    [Route("api/crane")]
    [ApiController]
    public class CraneController : ControllerBase
    {
        private readonly AnomalyDetectionService _anomalyDetectionService;
        private readonly CraneDataAccountingService _craneDataAccountingService;

        public CraneController(AnomalyDetectionService anomalyDetectionService, 
               CraneDataAccountingService craneDataAccountingService)
        {

            _anomalyDetectionService = anomalyDetectionService;
            _craneDataAccountingService = craneDataAccountingService;
        }

        [HttpPost()]
        public ActionResult PostCrateData([FromBody] CraneSensorRawDataDto sensorDataDto)
        {
            var data = _anomalyDetectionService.AnalyzeCraneData(sensorDataDto);
            _craneDataAccountingService.AddData(data);

            return Ok();
        }
    }
}
