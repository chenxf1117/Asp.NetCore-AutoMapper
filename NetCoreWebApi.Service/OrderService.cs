using NetCoreWebApi.IService;
using NetCoreWebApi.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreWebApi.Model.DBModel;
using NetCoreWebApi.Common.DBContext;
using AutoMapper;

namespace NetCoreWebApi.Service
{
    public class OrderService : IOrderService
    {
        private readonly IDBContext dBContext;
        private readonly IMapper mapper;
        /// <summary>
        /// 构造函数注入Mapper
        /// </summary>
        /// <param name="_dBContext"></param>
        /// <param name="_mapper"></param>
        public OrderService(IDBContext _dBContext, IMapper _mapper)
        {
            dBContext = _dBContext;
            mapper = _mapper;
        }
        /// <summary>
        /// 名称不一致  映射
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderDTO>> Query()
        {
            var orderList = await dBContext.DB.Queryable<Order>().ToListAsync();
            var orderDtoList = mapper.Map<List<OrderDTO>>(orderList);
            return await Task.FromResult(orderDtoList);
        }

        /// <summary>
        /// 数据类型/展现形式不一致 映射
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderItemDTO>> QueryItem()
        {
            var orderList = await dBContext.DB.Queryable<OrderItem>().ToListAsync();
            var orderDtoList = mapper.Map<List<OrderItemDTO>>(orderList);
            return await Task.FromResult(orderDtoList);
        }

        public async Task<List<OrderBatchDTO>> QueryBatch()
        {
            var orderList = await dBContext.DB.Queryable<Order>().ToListAsync();
            var orderDtoList = mapper.Map<List<OrderBatchDTO>>(orderList);
            return await Task.FromResult(orderDtoList);
        }
    }
}
