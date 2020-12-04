using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApi.Model
{
    /// <summary>
    /// 订单子表映射模型
    /// </summary>
    public class OrderItemDTO
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}
