using Device.Management.Common.Model;
using Device.Management.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Device.Management.Api.Controllers
{
    public class DeviceController : ControllerBase
    {
        private readonly IDevicesService _devicesService;

        public DeviceController(IDevicesService devicesService)
        {
            _devicesService = devicesService;
        }

        [HttpGet]
        [Route("get")]
        [SwaggerResponse(statusCode: 200, type: typeof(IEnumerable<Devices>))]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 500, description: "Internal Server Error")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _devicesService.GetAll();

            if(result == null || !result.Any())
                return NotFound("No devices founded");

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{deviceId}")]
        [SwaggerResponse(statusCode: 200, type: typeof(IEnumerable<Devices>))]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 500, description: "Internal Server Error")]
        public async Task<IActionResult> GetById([FromRoute] Guid deviceId)
        {
            var result = await _devicesService.GetDeviceById(deviceId);

            if (result == null )
                return NotFound("No device founded");

            return Ok(result);
        }

        [HttpGet]
        [Route("getbybrand/{brandName}")]
        [SwaggerResponse(statusCode: 200, type: typeof(IEnumerable<Devices>))]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 500, description: "Internal Server Error")]
        public async Task<IActionResult> GetByBrand([FromRoute] string brandName)
        {            
            var result = await _devicesService.GetDeviceByBrand(brandName);

            if (result == null)
                return NotFound("No devices founded");

            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        [SwaggerResponse(statusCode: 200, type: typeof(Devices))]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 500, description: "Internal Server Error")]
        public async Task<IActionResult> Add([FromBody] Devices request)
        {
            var result = await _devicesService.CreateDevice(request);

            if (result.Contains("fail"))
                return StatusCode(500, result);

            return Ok(result);            
        }

        [HttpPut]
        [Route("update")]
        [SwaggerResponse(statusCode: 200, type: typeof(Devices))]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 500, description: "Internal Server Error")]
        public async Task<IActionResult> Update([FromBody] Devices request)
        {
            var result = await _devicesService.UpdateDevice(request);

            if (result.Contains("fail"))
                return StatusCode(500, result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{deviceId}")]
        [SwaggerResponse(statusCode: 200, type: typeof(Devices))]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 500, description: "Internal Server Error")]
        public async Task<IActionResult> Delete([FromRoute] Guid deviceId)
        {
            var result = await _devicesService.DeleteDevice(deviceId);

            if (result.Contains("fail"))
                return StatusCode(500, result);

            return Ok(result);
        }
    }
}
