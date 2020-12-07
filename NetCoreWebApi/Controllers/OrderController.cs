using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.IService;
using NetCoreWebApi.Model;
using NetCoreWebApi.Model.DBModel;

namespace NetCoreWebApi.Controllers
{
    /// <summary>
    /// 订单
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService _service)
        {
            service = _service;
        }

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<OrderDTO>> Query()
        {
            return await service.Query();
        }

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<OrderItemDTO>> QueryItem()
        {
            return await service.QueryItem();
        }

        /// <summary>
        /// 订单查询--动态映射
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<OrderBatchDTO>> QueryBatch()
        {
            return await service.QueryBatch();
        }

        /// <summary>
        /// 子订单查询--动态映射
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<OrderItemBatchDTO>> QueryItemBatch()
        {
            return await service.QueryItemBatch();
        }
    }
}
