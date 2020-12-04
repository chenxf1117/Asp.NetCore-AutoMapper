using NetCoreWebApi.Model;
using NetCoreWebApi.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreWebApi.IService
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> Query();

        Task<List<OrderItemDTO>> QueryItem();

        Task<List<OrderBatchDTO>> QueryBatch();
    }
}
